import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksFormService } from '../services/book-form.service';
import { CreateBookCommand, GetBookByIdQueryDto } from '../../../../../api-services/books/books-api.models';
import { BaseFormComponent } from '../../../../../core/components/base-classes/base-form-component';
import {
  ProductCategoriesApiService
} from '../../../../../api-services/product-categories/product-categories-api.service';
import { ToasterService } from '../../../../../core/services/toaster.service';
import {
  ListProductCategoriesQueryDto
} from '../../../../../api-services/product-categories/product-categories-api.model';
import { largePaging } from '../../../../../core/models/paging/paging-utils';
import { PublishersService } from '../../../../../api-services/publishers/publishers-api.service';
import { ListPublishersQueryDto } from '../../../../../api-services/publishers/publishers-api.model';
import { ListBookFormatsQueryDto } from '../../../../../api-services/book-formats/book-format-api.model';
import { BookFormatApiService } from '../../../../../api-services/book-formats/book-format-api.service';
import { ListAuthorsQueryDto } from '../../../../../api-services/authors/authors-api.model';
import { AuthorsApiService } from '../../../../../api-services/authors/authors-api.service';
import { BooksApiService } from '../../../../../api-services/books/books-api.service';

@Component({
  selector: 'app-products-add',
  standalone: false,
  templateUrl: './books-add.component.html',
  styleUrl: './books-add.component.scss',
  providers: [BooksFormService]
})
export class BooksAddComponent
  extends BaseFormComponent<GetBookByIdQueryDto>
  implements OnInit {

  private api = inject(BooksApiService);
  private categoriesApi = inject(ProductCategoriesApiService);
  private publishersApi = inject(PublishersService);
  private bookFormatsApi = inject(BookFormatApiService);
  private authorsApi = inject(AuthorsApiService);
  private formService = inject(BooksFormService);
  private router = inject(Router);
  private toaster = inject(ToasterService);

  categories: ListProductCategoriesQueryDto[] = [];
  publishers: ListPublishersQueryDto[] = [];
  bookFormats: ListBookFormatsQueryDto[] = [];
  authors: ListAuthorsQueryDto[] = [];

  ngOnInit(): void {
    this.initForm(false); // Add mode
    this.loadCategories();
    this.loadPublishers();
    this.loadBookFormats();
    this.loadAuthors();
  }

  protected loadData(): void {
    // Not needed in add mode
  }

  protected save(): void {
    if (this.form.invalid || this.isLoading) {
      return;
    }

    this.startLoading();

    const command: CreateBookCommand = {
      isbn: this.form.value.isbn,
      title: this.form.value.title,
      language: this.form.value.language,
      pageCount: this.form.value.pageCount,
      description: this.form.value.description,
      quantityInStockForOnlineOrders: this.form.value.quantityInStockForOnlineOrders == "" ? null : this.form.value.quantityInStockForOnlineOrders,
      publisherId: this.form.value.publisherId,
      price: this.form.value.price,
      bookFormatId: this.form.value.bookFormatId,
      publishedDate: this.form.value.publishedDate,
      imageUrl: this.form.value.imageUrl,
      categoryIds: this.form.value.categoryIds,
      authorIds: this.form.value.authorIds
    };

    this.api.create(command).subscribe({
      next: (productId) => {
        this.stopLoading();
        this.toaster.success('Product created successfully');
        this.router.navigate(['/admin/products']);
      },
      error: (err) => {
        this.stopLoading('Failed to create product');
        console.error('Create product error:', err);
      }
    });
  }

  private loadCategories(): void {
    this.categoriesApi.list({ onlyEnabled: true, paging: largePaging }).subscribe({
      next: (response) => {
        this.categories = response.items;
      },
      error: (err) => {
        this.toaster.error('Failed to load categories');
        console.error('Load categories error:', err);
      }
    });
  }
  private loadPublishers(): void {
    this.publishersApi.list({ onlyEnabled: true, paging: largePaging }).subscribe({
      next: (response) => {
        this.publishers = response.items;
      },
      error: (err) => {
        this.toaster.error('Failed to load publishers');
        console.error('Load publishers error:', err);
      }
    });
  }

  private loadBookFormats(): void {
    this.bookFormatsApi.list({ onlyEnabled: true, paging: largePaging }).subscribe({
      next: (response) => {
        this.bookFormats = response.items;
      },
      error: (err) => {
        this.toaster.error('Failed to load book formats');
        console.error('Load book formats error:', err);
      }
    });
  }

  private loadAuthors(): void {
    this.authorsApi.list({ onlyEnabled: true, paging: largePaging }).subscribe({
      next: (response) => {
        this.authors = response.items;
      },
      error: (err) => {
        this.toaster.error('Failed to load authors');
        console.error('Load authors error:', err);
      }
    });
  }
  protected override initForm(isEdit: boolean): void {
    super.initForm(isEdit);
    this.form = this.formService.createProductForm();
  }

  onCancel(): void {
    this.router.navigate(['/admin/products']);
  }

  getErrorMessage(controlName: string): string {
    return this.formService.getErrorMessage(this.form, controlName);
  }
}
