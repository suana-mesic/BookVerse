import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { BaseFormComponent } from '../../../../core/components/base-classes/base-form-component';
import { GetBookByIdQueryDto, ListBooksQueryDto, ListBooksRequest, UpdateBookCommand } from '../../../../api-services/books/books-api.models';
import {
  ProductCategoriesApiService
} from '../../../../api-services/product-categories/product-categories-api.service';
import { ToasterService } from '../../../../core/services/toaster.service';
import {
  ListProductCategoriesQueryDto
} from '../../../../api-services/product-categories/product-categories-api.model';
import { largePaging } from '../../../../core/models/paging/paging-utils';
import { ListBookFormatsQueryDto } from '../../../../api-services/book-formats/book-format-api.model';
import { BookFormatApiService } from '../../../../api-services/book-formats/book-format-api.service';
import { ListAuthorsQueryDto } from '../../../../api-services/authors/authors-api.model';
import { ListPublishersQueryDto } from '../../../../api-services/publishers/publishers-api.model';
import { PublishersService } from '../../../../api-services/publishers/publishers-api.service';
import { AuthorsApiService } from '../../../../api-services/authors/authors-api.service';
import { BooksApiService } from '../../../../api-services/books/books-api.service';
import { BooksFormService } from '../../catalogs/book/services/book-form.service';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { InventoryApiService } from '../../../../api-services/inventory/inventory-api.service';
import { GetInventoryByIdQueryDto } from '../../../../api-services/inventory/inventory-api.model';
import { ListStoresQueryDto, ListStoresRequest } from '../../../../api-services/stores/stores-api.model';
import { StoresApiService } from '../../../../api-services/stores/stores-api.service';


@Component({
  selector: 'app-products-edit',
  standalone: false,
  templateUrl: './inventory-edit.component.html',
  styleUrl: './inventory-edit.component.scss',
  // providers:[BooksFormService]
})
export class InventoryEditComponent
  extends BaseComponent
  implements OnInit {

  private inventoryApi = inject(InventoryApiService);
  private booksApi = inject(BooksApiService);
  private storesApi = inject(StoresApiService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private rotue = inject(ActivatedRoute);
  private toaster = inject(ToasterService);
  private bookId: number = 0;
  private storeId: number = 0;
  private formBuilder = inject(FormBuilder);
  form!:FormGroup;
  

  productId!: number;
  books:ListBooksQueryDto[]=[];
  stores:ListStoresQueryDto[]=[];
  inventory!: GetInventoryByIdQueryDto;
  
  ngOnInit(): void {
    this.startLoading();
    this.bookId = +this.route.snapshot.params['bookId'];
    this.storeId = +this.route.snapshot.params['storeId'];
    this.loadForm();
  }
  
  private loadForm(){
    this.inventoryApi.getById(this.storeId, this.bookId).subscribe({
      next:(response)=> {
        this.inventory = response;
        this.loadBooks();
        this.loadStores();
        this.createForm();
        this.stopLoading();
      },
      error:(err)=>
        {
        this.toaster.error("Greška prilikom dohvatanja podataka o inventaru.");
        this.stopLoading();
        }
    });
  }

  private createForm(){
  this.form = this.formBuilder.group({
  storeId: new FormControl(this.inventory.storeId,[Validators.required]),
  storeName: new FormControl(this.inventory.storeName),
  bookId: new FormControl(this.inventory.bookId,[Validators.required]),
  isbn: new FormControl(this.inventory.isbn),
  title: new FormControl(this.inventory.title),
  quantityInStock: new FormControl(this.inventory.quantityInStock,[Validators.required]),
  lastRestocked: new FormControl(this.inventory.lastRestocked),
  reorderTreshold: new FormControl(this.inventory.reorderTreshold,[Validators.required]),
  location: new FormControl(this.inventory.location,[Validators.required, this.validateLocation()]),
  });
  }

  private loadBooks(){
    const request = new ListBooksRequest();
    request.paging.pageSize=10000000;
    this.booksApi.list(request).subscribe({
      next:(response)=>this.books=response.items,
      error:(err)=>this.toaster.error("Greška prilikom dohvatanja knjiga.")
    });
  }

  private loadStores(){
    const request = new ListStoresRequest();
    request.paging.pageSize=10000000;
    this.storesApi.list(request).subscribe({
      next:(response)=>this.stores=response.items,
      error:(err)=>this.toaster.error("Greška prilikom dohvatanja knjiga.")
    });
  }

  private validateLocation(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (!control || !control.value || control.value === '')
      return null;
    
    let regexRule = /^Polica [A-Z]-[0-9]{1,}$/;
    return regexRule.test(control.value) ? null : { nevalidnaLokacija: true };
  }
}

  onSubmit(){
    const {storeName, title, isbn, lastRestocked, ...comamnd} = this.form.value;
    this.inventoryApi.update(this.storeId, this.bookId,comamnd).subscribe({
      next:(response)=>{
        this.toaster.success("Uspješno ste ažurirali podatke o inventaru");
        this.router.navigate(["/admin/inventory"]);
      },
      error:(err)=>this.toaster.error("Greška prilikom ažuriranja podataka o inventaru")
    })
  }
//   protected loadData(): void {
//     this.startLoading();
    
//     // Load product and categories in parallel
//     forkJoin({
//       product: this.api.getById(this.productId),
//       categories: this.categoriesApi.list({ onlyEnabled: true, paging: largePaging }),
//       bookFormats: this.bookFormatsApi.list({ onlyEnabled: true, paging: largePaging }),
//       authors: this.authorsApi.list({ onlyEnabled: true, paging: largePaging }),
//       publishers: this.publishersApi.list({ onlyEnabled: true, paging: largePaging }),
//     }).subscribe({
//       next: ({ product, categories, bookFormats, authors, publishers }) => {
//         this.model = product;
//         this.categories = categories.items;
//         this.bookFormats = bookFormats.items;
//         this.authors = authors.items;
//         this.publishers = publishers.items;
//         this.form = this.formService.createProductForm(product);
//         this.stopLoading();
//       },
//       error: (err) => {
//         this.stopLoading('Failed to load product');
//         this.toaster.error('Product not found');
//         console.error('Load product error:', err);
//         this.router.navigate(['/admin/products']);
//       }
//     });
//   }
  
//   protected save(): void {
//     if (this.form.invalid || this.isLoading) {
//       return;
//     }
    
//     this.startLoading();
    
//     const command: UpdateBookCommand = {
//       isbn: this.form.value.isbn,
//       title: this.form.value.title,
//       publisherId: this.form.value.publisherId,
//       bookFormatId: this.form.value.bookFormatId,
//       authorIds: this.form.value.authorIds,
//       categoryIds: this.form.value.categoryIds,
//       price: this.form.value.price,
//       language: this.form.value.language,
//       description: this.form.value.description,
//       pageCount: this.form.value.pageCount,
//       quantityInStockForOnlineOrders: this.form.value.quantityInStockForOnlineOrders,
//       imageUrl: this.form.value.imageUrl,
//       publishedDate: this.form.value.publishedDate
//       ? new Date(Date.UTC(
//           this.form.value.publishedDate.getFullYear(),
//           this.form.value.publishedDate.getMonth(),
//           this.form.value.publishedDate.getDate()
//         ))
//         : null,
//       };

//     this.api.update(this.productId, command).subscribe({
//       next: () => {
//         this.stopLoading();
//         this.toaster.success('Product updated successfully');
//         this.router.navigate(['/admin/products']);
//       },
//       error: (err) => {
//         this.stopLoading('Failed to update product');
//         console.error('Update product error:', err);
//       }
//     });
//   }

//   onCancel(): void {
//     this.router.navigate(['/admin/products']);
//   }

//   getErrorMessage(controlName: string): string {
//     return this.formService.getErrorMessage(this.form, controlName);
//   }
// }
  }