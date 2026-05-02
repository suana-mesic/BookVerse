import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { BooksFormService } from '../services/book-form.service';
import { BaseFormComponent } from '../../../../../core/components/base-classes/base-form-component';
import {
  GetBookByIdQueryDto,
  UpdateBookCommand,
} from '../../../../../api-services/books/books-api.models';
import { ProductCategoriesApiService } from '../../../../../api-services/product-categories/product-categories-api.service';
import { ToasterService } from '../../../../../core/services/toaster.service';
import { ListProductCategoriesQueryDto } from '../../../../../api-services/product-categories/product-categories-api.model';
import { largePaging } from '../../../../../core/models/paging/paging-utils';
import { ListBookFormatsQueryDto } from '../../../../../api-services/book-formats/book-format-api.model';
import { BookFormatApiService } from '../../../../../api-services/book-formats/book-format-api.service';
import { ListAuthorsQueryDto } from '../../../../../api-services/authors/authors-api.model';
import { ListPublishersQueryDto } from '../../../../../api-services/publishers/publishers-api.model';
import { PublishersService } from '../../../../../api-services/publishers/publishers-api.service';
import { AuthorsApiService } from '../../../../../api-services/authors/authors-api.service';
import { BooksApiService } from '../../../../../api-services/books/books-api.service';
import { LanguagesApiService } from '../../../../../api-services/languages/languages-api.service';
import { ListLanguagesQueryDto } from '../../../../../api-services/languages/languages-api.model';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-products-edit',
  standalone: false,
  templateUrl: './books-edit.component.html',
  styleUrl: './books-edit.component.scss',
  providers: [BooksFormService],
})
export class BooksEditComponent extends BaseFormComponent<GetBookByIdQueryDto> implements OnInit {
  private api = inject(BooksApiService);
  private categoriesApi = inject(ProductCategoriesApiService);
  private bookFormatsApi = inject(BookFormatApiService);
  private languagesApi = inject(LanguagesApiService);
  private publishersApi = inject(PublishersService);
  private authorsApi = inject(AuthorsApiService);
  private formService = inject(BooksFormService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);

  productId!: number;
  categories: ListProductCategoriesQueryDto[] = [];
  bookFormats: ListBookFormatsQueryDto[] = [];
  languages: ListLanguagesQueryDto[] = [];
  authors: ListAuthorsQueryDto[] = [];
  publishers: ListPublishersQueryDto[] = [];

  ngOnInit(): void {
    this.productId = +this.route.snapshot.params['id'];
    this.initForm(true); // Edit mode
    this.startLoading();
  }

  protected loadData(): void {
    // Load product and categories in parallel
    forkJoin({
      product: this.api.getById(this.productId),
      categories: this.categoriesApi.list(),
      bookFormats: this.bookFormatsApi.list({ onlyEnabled: true, paging: largePaging }),
      languages: this.languagesApi.list(),
      authors: this.authorsApi.list({ onlyEnabled: true, paging: largePaging }),
      publishers: this.publishersApi.list({ onlyEnabled: true, paging: largePaging }),
    }).subscribe({
      next: ({ product, categories, bookFormats, languages, authors, publishers }) => {
        this.model = product;
        this.categories = categories;
        this.bookFormats = bookFormats.items;
        this.languages = languages;
        this.authors = authors.items;
        this.publishers = publishers.items;
        this.form = this.formService.createProductForm(product);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading(this.translate.instant('BOOKS.DIALOGS.ERROR_LOAD'));
        this.toaster.error(this.translate.instant('ERRORS.NOT_FOUND'));
        console.error('Load product error:', err);
        this.stopLoading();
        this.router.navigate(['/admin/products']);
      },
    });
  }

  protected save(): void {
    if (this.form.invalid || this.isLoading) {
      return;
    }

    this.startLoading();

    const publishedDate = this.form.value.publishedDate
      ? new Date(this.form.value.publishedDate)
      : null;

    const command: UpdateBookCommand = {
      isbn: this.form.value.isbn,
      title: this.form.value.title,
      publisherId: this.form.value.publisherId,
      bookFormatId: this.form.value.bookFormatId,
      authorIds: this.form.value.authorIds,
      categoryIds: this.form.value.categoryIds,
      price: this.form.value.price,
      languageId: this.form.value.languageId,
      description: this.form.value.description,
      pageCount: this.form.value.pageCount,
      quantityInStockForOnlineOrders: this.form.value.quantityInStockForOnlineOrders,
      imageUrl: this.form.value.imageUrl,
      publishedDate: publishedDate
        ? new Date(
            Date.UTC(
              publishedDate.getFullYear(),
              publishedDate.getMonth(),
              publishedDate.getDate(),
            ),
          )
        : null,
    };

    this.api.update(this.productId, command).subscribe({
      next: () => {
        this.stopLoading();
        this.toaster.success(this.translate.instant('BOOKS.DIALOGS.SUCCESS_UPDATE'));
        this.router.navigate(['/admin/products']);
      },
      error: (err) => {
        this.stopLoading();
        const key = err.status === 409
          ? 'BOOKS.DIALOGS.ERROR_DUPLICATE_ISBN'
          : 'BOOKS.DIALOGS.ERROR_UPDATE';
        this.toaster.error(this.translate.instant(key));
        console.error('Update product error:', err);
      },
    });
  }

  onCancel(): void {
    this.router.navigate(['/admin/products']);
  }

  getErrorMessage(controlName: string): string {
    return this.formService.getErrorMessage(this.form, controlName);
  }
}
