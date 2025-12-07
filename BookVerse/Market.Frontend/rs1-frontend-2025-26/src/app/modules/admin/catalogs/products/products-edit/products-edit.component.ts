import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { ProductFormService } from '../services/product-form.service';
import { BaseFormComponent } from '../../../../../core/components/base-classes/base-form-component';
import { GetBookByIdQueryDto, UpdateProductCommand } from '../../../../../api-services/products/products-api.models';
import { ProductsApiService } from '../../../../../api-services/products/products-api.service';
import {
  ProductCategoriesApiService
} from '../../../../../api-services/product-categories/product-categories-api.service';
import { ToasterService } from '../../../../../core/services/toaster.service';
import {
  ListProductCategoriesQueryDto
} from '../../../../../api-services/product-categories/product-categories-api.model';
import { largePaging } from '../../../../../core/models/paging/paging-utils';
import { ListBookFormatsQueryDto } from '../../../../../api-services/book-formats/book-format-api.model';
import { BookFormatApiService } from '../../../../../api-services/book-formats/book-format-api.service';
import { ListAuthorsQueryDto } from '../../../../../api-services/authors/authors-api.model';
import { ListPublishersQueryDto } from '../../../../../api-services/publishers/publishers-api.model';
import { PublishersService } from '../../../../../api-services/publishers/publishers-api.service';
import { AuthorsApiService } from '../../../../../api-services/authors/authors-api.service';


@Component({
  selector: 'app-products-edit',
  standalone: false,
  templateUrl: './products-edit.component.html',
  styleUrl: './products-edit.component.scss',
  providers: [ProductFormService]
})
export class ProductsEditComponent
  extends BaseFormComponent<GetBookByIdQueryDto>
  implements OnInit {

  private api = inject(ProductsApiService);
  private categoriesApi = inject(ProductCategoriesApiService);
  private bookFormatsApi = inject(BookFormatApiService);
  private publishersApi = inject(PublishersService);
  private authorsApi = inject(AuthorsApiService);
  private formService = inject(ProductFormService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private toaster = inject(ToasterService);

  productId!: number;
  categories: ListProductCategoriesQueryDto[] = [];
  bookFormats: ListBookFormatsQueryDto[] = [];
  authors: ListAuthorsQueryDto[] = [];
  publishers: ListPublishersQueryDto[] = [];

  ngOnInit(): void {
    this.productId = +this.route.snapshot.params['id'];
    this.initForm(true); // Edit mode
  }

  protected loadData(): void {
    this.startLoading();

    // Load product and categories in parallel
    forkJoin({
      product: this.api.getById(this.productId),
      categories: this.categoriesApi.list({ onlyEnabled: true, paging: largePaging }),
      bookFormats: this.bookFormatsApi.list({ onlyEnabled: true, paging: largePaging }),
      authors: this.authorsApi.list({ onlyEnabled: true, paging: largePaging }),
      publishers: this.publishersApi.list({ onlyEnabled: true, paging: largePaging }),
    }).subscribe({
      next: ({ product, categories, bookFormats, authors, publishers }) => {
        this.model = product;
        this.categories = categories.items;
        this.bookFormats = bookFormats.items;
        this.authors = authors.items;
        this.publishers = publishers.items;
        this.form = this.formService.createProductForm(product);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading('Failed to load product');
        this.toaster.error('Product not found');
        console.error('Load product error:', err);
        this.router.navigate(['/admin/products']);
      }
    });
  }

  protected save(): void {
    if (this.form.invalid || this.isLoading) {
      return;
    }

    this.startLoading();

    const command: UpdateProductCommand = {
      isbn: this.form.value.isbn,
      title: this.form.value.title,
      publisherId: this.form.value.publisherId,
      bookFormatId: this.form.value.bookFormatId,
      authorIds: this.form.value.authorIds,
      categoryIds: this.form.value.categoryIds,
      price: this.form.value.price,
      language: this.form.value.language,
      description: this.form.value.description,
      pageCount: this.form.value.pageCount,
      quantityInStockForOnlineOrders: this.form.value.quantityInStockForOnlineOrders,
      imageUrl: this.form.value.imageUrl,
      publishedDate: this.form.value.publishedDate
        ? new Date(Date.UTC(
          this.form.value.publishedDate.getFullYear(),
          this.form.value.publishedDate.getMonth(),
          this.form.value.publishedDate.getDate()
        ))
        : null,
    };

    this.api.update(this.productId, command).subscribe({
      next: () => {
        this.stopLoading();
        this.toaster.success('Product updated successfully');
        this.router.navigate(['/admin/products']);
      },
      error: (err) => {
        this.stopLoading('Failed to update product');
        console.error('Update product error:', err);
      }
    });
  }

  onCancel(): void {
    this.router.navigate(['/admin/products']);
  }

  getErrorMessage(controlName: string): string {
    return this.formService.getErrorMessage(this.form, controlName);
  }
}
