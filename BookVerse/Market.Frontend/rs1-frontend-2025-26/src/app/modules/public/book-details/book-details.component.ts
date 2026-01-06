import { Component, ElementRef, inject, input, signal, ViewChild } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { BooksService } from '../Petar/books.service';
import { AuthorsService } from '../Petar/authors.service';
import { Book } from '../Petar/book/Book';
import { Author } from '../Petar/author/Author';
import { Review } from '../Petar/book/Review';
import { ReviewsService } from '../Petar/reviews.service';
import * as L from 'leaflet';
import { MapComponent } from '../map/map.component';

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
  imports: [HeaderComponent, RouterLink, MapComponent],
})
export class BookDetailsComponent {
  book = signal<Book | null>(null);
  authors = signal<Array<Author>>([]);
  reviews = signal<Array<Review>>([]);

  bookService = inject(BooksService);
  authorService = inject(AuthorsService);
  reviewService = inject(ReviewsService);
  bookId!: string;

  reviewRating = 0;
  reviewNumber = 0;

  reviewRatingsCount = [0, 0, 0, 0, 0];
  reviewRatingsBarWidth = [0, 0, 0, 0, 0];

  constructor(private route: ActivatedRoute) {}

  // updateRatingsBarWidth() {
  //   for(let i=0; i<5;i++)
  //   this.reviewRatingsBarWidth[i] =
  //         (this.reviewRatingsCount[i] / this.reviewNumber) * 180;
  // }

  // Stores info
  storeName = signal('');
  storeWorkTimeMonFri = signal('');
  storeWorkTimeSatSun = signal('');
  storeEmail = signal('');
  storeAddress = signal('');
  storePhone = signal('');

  setCentralBookstore() {
    this.storeName.set('Central Bookstore');
    this.storeWorkTimeMonFri.set('09-19h');
    this.storeWorkTimeSatSun.set('09-14h');
    this.storeEmail.set('centralbookstore@bookverse.ba');
    this.storeAddress.set('Maršala Tita, Mostar');
    this.storePhone.set('061/062-063');
    this.toggleStoreInfo();
  }
  setForticaBooks() {
    this.storeName.set('Fortica Books');
    this.storeWorkTimeMonFri.set('09-19h');
    this.storeWorkTimeSatSun.set('09-14h');
    this.storeEmail.set('forticabooks@bookverse.ba');
    this.storeAddress.set('Maršala Tita, Mostar');
    this.storePhone.set('061/062-063');
    this.toggleStoreInfo();
  }
  setSpaceBookstore() {
    this.storeName.set('Space Bookstore');
    this.storeWorkTimeMonFri.set('09-19h');
    this.storeWorkTimeSatSun.set('09-14h');
    this.storeEmail.set('spacebookstore@bookverse.ba');
    this.storeAddress.set('Maršala Tita, Mostar');
    this.storePhone.set('061/062-063');
    this.toggleStoreInfo();
  }

  storeInfoOpened = false;

  toggleStoreInfo() {
    this.storeInfoOpened = !this.storeInfoOpened;
  }

  ngOnInit() {
    this.bookId = this.route.snapshot.paramMap.get('id')!;

    this.bookService.getBookDetailsFromApi(this.bookId).subscribe((book: any) => {
      this.book.set(book);
      for (let i = 0; i < this.book()!.authorIds.length; i++) {
        this.authorService.getAuthorFromApi(this.book()!.authorIds[i]).subscribe((author: any) => {
          this.authors.update((arr) => [...arr, author]);
        });
      }
      this.reviewService.getReviewsByBookIdFromApi(Number(this.bookId)).subscribe((review: any) => {
        this.reviews.update((arr) => [...arr, review]);

        console.log(this.reviews());
        this.reviewNumber++;
        this.reviewRating += (review.rating - this.reviewRating) / this.reviewNumber;
        this.reviewRatingsCount[review.rating - 1]++;

        this.reviewRatingsBarWidth[review.rating - 1] =
          (this.reviewRatingsCount[review.rating - 1] / this.reviewNumber) * 180;
        console.log(this.reviewRatingsBarWidth);
      });
    });
  }
}
