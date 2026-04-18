import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { BaseListPagedComponent } from '../../core/components/base-classes/base-list-paged-component';
import { ListMyBooksQueryDto } from '../../../api-services/books/books-api.models';
import {
  CreateReviewCommand,
  ListMyBooksRequest,
  UpdateReviewCommand,
} from '../../../api-services/reviews/reviews-api.model';
import { debounceTime, distinctUntilChanged, Subject, takeUntil } from 'rxjs';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { ToasterService } from '../../core/services/toaster.service';
import { FormControl } from '@angular/forms';
import { ReviewsApiService } from '../../../api-services/reviews/reviews-api.service';
import { BooksApiService } from '../../../api-services/books/books-api.service';
import { CategoriesService } from '../../public/Petar/categories.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
import { Categories } from '../../public/Petar/book/Categories';
import { Location } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'app-my-books',
  standalone: false,
  templateUrl: './user-books.component.html',
  styleUrl: './user-books.component.scss',
})
export class UserBooksComponent
  extends BaseListPagedComponent<ListMyBooksQueryDto, ListMyBooksRequest>
  implements OnInit, OnDestroy
{
  private reviewService = inject(ReviewsApiService);
  private categoriesService = inject(CategoriesService);
  private booksService = inject(BooksApiService);
  private toaster = inject(ToasterService);
  private destroy$ = new Subject<void>();
  private dialogHelper = inject(DialogHelperService);
  private translate = inject(TranslateService);
  public userTimezone = Intl.DateTimeFormat().resolvedOptions().timeZone;
  private location = inject(Location);

  selectedBook: ListMyBooksQueryDto | null = null;

  selectedCategoryIds: number[] = [];
  availableCategories: Categories[] = [];
  filteredCategories: Categories[] = [];

  searchControl = new FormControl('');
  categorySearchControl = new FormControl(''); // Za pretragu kategorija

  // Modal za recenziju
  showReviewModal = false;
  reviewForm = {
    rating: 5,
    comment: '',
  };
  isEditMode = false;
  isSavingReview = false;

  constructor() {
    super();
    this.request = new ListMyBooksRequest();
    this.request.paging.page = 1;
    this.request.paging.pageSize = 10;
  }

  ngOnInit(): void {
    this.initList();
    this.setupSearchDebounce();
    this.setupCategorySearch();
    this.loadCategories();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private setupSearchDebounce(): void {
    this.searchControl.valueChanges
      .pipe(debounceTime(400), distinctUntilChanged(), takeUntil(this.destroy$))
      .subscribe((value) => {
        if (!value || value.length >= 3) {
          this.request.search = value || null;
          this.request.paging.page = 1;
          this.loadPagedData();
        }
      });
  }

  private setupCategorySearch(): void {
    this.categorySearchControl.valueChanges
      .pipe(debounceTime(300), distinctUntilChanged(), takeUntil(this.destroy$))
      .subscribe((searchValue) => {
        if (typeof searchValue === 'string') {
          this.filterCategories(searchValue);
        }
      });
  }

  private filterCategories(searchValue: string): void {
    const search = searchValue.toLowerCase().trim();

    if (!search) {
      this.filteredCategories = this.availableCategoriesToAdd;
    } else {
      this.filteredCategories = this.availableCategoriesToAdd.filter((cat) =>
        cat.name.toLowerCase().includes(search),
      );
    }
  }

  get availableCategoriesToAdd(): { id: number; name: string }[] {
    return this.availableCategories.filter((cat) => !this.selectedCategoryIds.includes(cat.id));
  }

  private loadCategories() {
    this.categoriesService.getCategoriesFromApi().subscribe({
      next: (response) => {
        console.log('Dostupne kategorije:');
        console.log(response);
        this.availableCategories = response;
        this.filteredCategories = response;
      },
      error: (err) => {
        this.toaster.error(this.translate.instant('CLIENT.USER_BOOKS.ERROR_LOAD_CATEGORIES'));
      },
    });
  }

  public override loadPagedData(): void {
    this.startLoading();
    this.booksService.listMyBooks(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: () => {
        this.stopLoading(this.translate.instant('CLIENT.USER_BOOKS.ERROR_LOAD_BOOKS'));
      },
    });
  }

  clearFilters(): void {
    this.searchControl.setValue('', { emitEvent: false });
    this.categorySearchControl.setValue('', { emitEvent: false }); // DODAJ
    this.selectedCategoryIds = [];
    this.request.search = null;
    this.request.categoryIds = [];
    this.request.paging.page = 1;
    this.filteredCategories = [...this.availableCategories]; // DODAJ
    this.loadPagedData();
  }

  selectBook(book: ListMyBooksQueryDto): void {
    this.selectedBook = this.selectedBook?.bookId === book.bookId ? null : book;
  }

  //REVIEW ACTIONS
  openCreateReviewModal(book: ListMyBooksQueryDto): void {
    this.selectedBook = book;
    this.isEditMode = false;
    this.reviewForm = {
      rating: 5,
      comment: '',
    };
    this.showReviewModal = true;
  }

  openEditReviewModal(book: ListMyBooksQueryDto): void {
    if (!book.userReview) return;

    this.selectedBook = book;
    this.isEditMode = true;
    this.reviewForm = {
      rating: book.userReview.rating,
      comment: book.userReview.comment,
    };
    this.showReviewModal = true;
  }

  closeReviewModal(): void {
    this.showReviewModal = false;
    this.selectedBook = null;
    this.reviewForm = { rating: 5, comment: '' };
  }

  saveReview(): void {
    if (!this.selectedBook) return;

    this.isSavingReview = true;

    if (this.isEditMode) {
      // UPDATE
      const command: UpdateReviewCommand = {
        rating: this.reviewForm.rating,
        comment: this.reviewForm.comment,
      };

      this.reviewService.updateReview(this.selectedBook.bookId, command).subscribe({
        next: () => {
          this.isSavingReview = false;
          this.closeReviewModal();
          this.loadPagedData();
          this.toaster.success(this.translate.instant('CLIENT.USER_BOOKS.REVIEW_UPDATED'));
        },
        error: () => {
          this.isSavingReview = false;
          this.toaster.error(this.translate.instant('CLIENT.USER_BOOKS.ERROR_UPDATE_REVIEW'));
        },
      });
    } else {
      // CREATE
      const command: CreateReviewCommand = {
        bookId: this.selectedBook.bookId,
        rating: this.reviewForm.rating,
        comment: this.reviewForm.comment,
      };

      this.reviewService.createReview(command).subscribe({
        next: () => {
          this.isSavingReview = false;
          this.closeReviewModal();
          this.loadPagedData();
          this.toaster.success(this.translate.instant('CLIENT.USER_BOOKS.REVIEW_CREATED'));
        },
        error: () => {
          this.isSavingReview = false;
          this.toaster.error(this.translate.instant('CLIENT.USER_BOOKS.ERROR_CREATE_REVIEW'));
        },
      });
    }
  }

  deleteReview(book: ListMyBooksQueryDto): void {
    if (!book.userReview) return;

    this.dialogHelper
      .confirm(
        this.translate.instant('CLIENT.USER_BOOKS.DELETE_TITLE'),
        this.translate.instant('CLIENT.USER_BOOKS.DELETE_CONFIRM'),
      )
      .subscribe((response) => {
        if (response?.button === DialogButton.YES) {
          this.reviewService.deleteReview(book.bookId).subscribe({
            next: () => {
              this.loadPagedData();
              this.toaster.success(this.translate.instant('CLIENT.USER_BOOKS.REVIEW_DELETED'));
            },
            error: () => {
              this.toaster.error(this.translate.instant('CLIENT.USER_BOOKS.ERROR_DELETE_REVIEW'));
            },
          });
        }
      });
  }

  addCategory(categoryId: number): void {
    if (!this.selectedCategoryIds.includes(categoryId)) {
      this.selectedCategoryIds.push(categoryId);
      this.categorySearchControl.setValue(''); // Clear search
      this.applyFilters();
    }
  }

  removeCategory(categoryId: number): void {
    const index = this.selectedCategoryIds.indexOf(categoryId);
    if (index > -1) {
      this.selectedCategoryIds.splice(index, 1);
      this.applyFilters();
    }
  }

  private applyFilters(): void {
    this.request.categoryIds = this.selectedCategoryIds;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  getCategoryName(categoryId: number): string {
    return this.availableCategories.find((c) => c.id === categoryId)?.name || '';
  }

  getStars(rating: number): boolean[] {
    return Array(5)
      .fill(false)
      .map((_, i) => i < rating);
    //npr. rating = 3
    //index i=0, i<rating -> TRUE -> 1. zvijezda popunjena
    //index i=1, i<rating -> TRUE -> 2. zvijezda popunjena
    //index i=2, i<rating -> TRUE -> 3. zvijezda popunjena
    //index i=3, i<rating -> FALSE
    //index i=4, i<rating -> FALSE
  }
  goBack(): void {
    this.location.back();
  }
}
