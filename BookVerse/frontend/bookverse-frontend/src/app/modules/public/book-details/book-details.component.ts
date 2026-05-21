import { Component, inject, OnDestroy, signal } from '@angular/core';
import { Location } from '@angular/common';
import { HeaderComponent } from '../header/header.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewsApiService } from '../../../api-services/reviews/reviews-api.service';
import * as L from 'leaflet';
import { MapComponent } from '../map/map.component';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { ToasterService } from '../../../core/services/toaster.service';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';
import {
  ListReviewsForBookQueryDto,
  ListReviewsResponse,
} from '../../../api-services/reviews/reviews-api.model';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { MatIconModule } from '@angular/material/icon';
import { Subscription } from 'rxjs';
import { SharedModule } from '../../shared/shared-module';
import { AuthorsApiService } from '../../../api-services/authors/authors-api.service';
import { BooksApiService } from '../../../api-services/books/books-api.service';
import { Book } from '../../../api-services/books/books-api.models';
import { Author } from '../../../api-services/authors/authors-api.model';
import { StoresApiService } from '../../../api-services/stores/stores-api.service';
import { ListStoresQueryDto } from '../../../api-services/stores/stores-api.model';
import { getBackendErrorMessage } from '../../../core/services/backend-error-message.helper';

delete (L.Icon.Default.prototype as any)._getIconUrl;

L.Icon.Default.mergeOptions({
  iconRetinaUrl: 'leaflet_images/marker-icon-2x.png',
  iconUrl: 'leaflet_images/marker-icon.png',
  shadowUrl: 'leaflet_images/marker-shadow.png',
});

@Component({
  standalone: true,
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.scss',
  imports: [HeaderComponent, MapComponent, TranslateModule, MatIconModule, SharedModule],
})
export class BookDetailsComponent implements OnDestroy {
  book = signal<Book | null>(null);
  authors = signal<Array<Author>>([]);
  reviews = signal<Array<ListReviewsForBookQueryDto>>([]);

  bookService = inject(BooksApiService);
  authorService = inject(AuthorsApiService);
  reviewService = inject(ReviewsApiService);
  bookId!: string;
  private langChangeSub!: Subscription;
  private loadRequestId = 0;

  reviewRating = 0;
  reviewNumber = 0;

  reviewRatingsCount = [0, 0, 0, 0, 0];
  reviewRatingsBarWidth = [0, 0, 0, 0, 0];

  cartService = inject(CartApiService);
  toaster = inject(ToasterService);
  authFacadeService = inject(AuthFacadeService);
  router = inject(Router);
  private location = inject(Location);
  private translate = inject(TranslateService);

  constructor(private route: ActivatedRoute) {}

  goBack(): void {
    this.location.back();
  }

  // Stores info
  storesService = inject(StoresApiService);
  stores = signal<ListStoresQueryDto[]>([]);
  selectedStore = signal<ListStoresQueryDto | null>(null);
  storeInfoOpened = false;

  selectStore(store: ListStoresQueryDto) {
    this.selectedStore.set(store);
    this.storeInfoOpened = true;
  }

  closeStoreInfo() {
    this.storeInfoOpened = false;
  }

  private loadBookDetails(): void {
    const requestId = ++this.loadRequestId;
    const language = this.translate.currentLang || this.translate.defaultLang || 'bs';
    this.authors.set([]);
    this.bookService.getBookDetailsFromApi(this.bookId, language).subscribe((book: any) => {
      if (requestId !== this.loadRequestId) return;
      this.book.set(book);
      for (let i = 0; i < this.book()!.authorIds.length; i++) {
        this.authorService.getAuthorFromApi(this.book()!.authorIds[i]).subscribe((author: any) => {
          if (requestId !== this.loadRequestId) return;
          this.authors.update((arr) => [...arr, author]);
        });
      }
    });
  }

  ngOnInit() {
    this.bookId = this.route.snapshot.paramMap.get('id')!;
    this.loadBookDetails();

    this.storesService.list().subscribe({
      next: (response) => this.stores.set(response.items),
    });

    this.langChangeSub = this.translate.onLangChange.subscribe(() => {
      this.loadBookDetails();
    });

    this.reviewService.getAllReviewsForBook(Number(this.bookId)).subscribe({
      next: (response: ListReviewsResponse) => {
        const items = response.items;
        this.reviews.set(items);

        this.reviewNumber = items.length;
        this.reviewRating = 0;
        this.reviewRatingsCount = [0, 0, 0, 0, 0];
        this.reviewRatingsBarWidth = [0, 0, 0, 0, 0];

        for (const review of items) {
          this.reviewRating += review.rating;
          this.reviewRatingsCount[review.rating - 1]++;
        }

        if (this.reviewNumber > 0) {
          this.reviewRating = this.reviewRating / this.reviewNumber;
        }

        for (let i = 0; i < 5; i++) {
          this.reviewRatingsBarWidth[i] = (this.reviewRatingsCount[i] / this.reviewNumber) * 180;
        }
      },
      error: (err) => {},
    });
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
  }

  addToCart(bookId: number | undefined) {
    if (!bookId) return;

    if (!this.authFacadeService.isAuthenticated()) {
      sessionStorage.setItem('pendingAddToCart', JSON.stringify({ bookId, quantity: 1 }));
      this.router.navigate(['/auth/login']);
      return;
    }

    this.cartService.addToCart({ bookId: bookId, quantity: 1 }).subscribe({
      next: (response) => {
        this.toaster.success(this.translate.instant('CLIENT.BOOK_DETAILS.ADDED_TO_CART'));
      },
      error: (err) => {
        // Map known backend messages (out-of-stock, book unavailable, etc.) to the localized
        // ERRORS.BACKEND_MESSAGES.* entries; fall back to the generic add-to-cart error.
        const backendMsg = getBackendErrorMessage(err, this.translate);
        this.toaster.error(
          backendMsg ?? this.translate.instant('CLIENT.BOOK_DETAILS.ERROR_ADD_TO_CART'),
        );
      },
    });
  }
}
