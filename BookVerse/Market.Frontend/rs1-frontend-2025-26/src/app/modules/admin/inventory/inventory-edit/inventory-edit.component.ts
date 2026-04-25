import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ListBooksForAutocompleteQueryDto } from '../../../../api-services/books/books-api.models';
import { ToasterService } from '../../../../core/services/toaster.service';
import { BooksApiService } from '../../../../api-services/books/books-api.service';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { TranslateService } from '@ngx-translate/core';
import { InventoryApiService } from '../../../../api-services/inventory/inventory-api.service';
import { GetInventoryByIdQueryDto, StoreBookPairs } from '../../../../api-services/inventory/inventory-api.model';
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
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);
  private bookId: number = 0;
  private storeId: number = 0;
  private formBuilder = inject(FormBuilder);
  form!:FormGroup;
  

  productId!: number;
  books: ListBooksForAutocompleteQueryDto[] = [];
  stores: ListStoresQueryDto[] = [];
  inventory!: GetInventoryByIdQueryDto;
  storeBookPairs: StoreBookPairs | null = null;

  booksAutocompleteInput = new FormControl('');
  filteredBooksOptions!: Observable<ListBooksForAutocompleteQueryDto[]>;
  
  ngOnInit(): void {
    this.startLoading();
    this.bookId = +this.route.snapshot.params['bookId'];
    this.storeId = +this.route.snapshot.params['storeId'];
    this.loadForm();
  }
  
  private setFilteredBooksOptions(): void {
    this.filteredBooksOptions = this.booksAutocompleteInput.valueChanges.pipe(
      startWith(''),
      map((value) => {
        const filterValue = (value ?? '').toLowerCase();
        return this.books.filter((x) => x.title.toLowerCase().includes(filterValue));
      }),
    );
  }

  displayBookTitle = (bookId: number): string => {
    return this.books.find((x) => x.id === bookId)?.title ?? '';
  };

  onBookSelected(event: MatAutocompleteSelectedEvent): void {
    this.form.get('bookId')?.setValue(event.option.value);
  }

  private loadForm(){
    this.inventoryApi.getById(this.storeId, this.bookId).subscribe({
      next:(response)=> {
        this.inventory = response;
        this.loadBooks();
        this.loadStores();
        this.loadStoreBookPairs();
        this.createForm();
        this.stopLoading();
      },
      error:(err)=>
        {
        this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD'));
        this.stopLoading();
        }
    });
  }

  private loadStoreBookPairs(): void {
    this.inventoryApi.getStoreBookPairs().subscribe({
      next: (response) => (this.storeBookPairs = response),
      error: () => {},
    });
  }

  isStoreOccupied(storeId: number): boolean {
    const currentBookId = this.form?.get('bookId')?.value;
    if (!currentBookId || this.storeBookPairs === null) return false;
    if (storeId === this.storeId && currentBookId === this.bookId) return false;
    const available = this.storeBookPairs[storeId];
    if (!available) return false;
    return !available[currentBookId];
  }

  isBookOccupied(bookId: number): boolean {
    const currentStoreId = this.form?.get('storeId')?.value;
    if (!currentStoreId || this.storeBookPairs === null) return false;
    if (currentStoreId === this.storeId && bookId === this.bookId) return false;
    const available = this.storeBookPairs[currentStoreId];
    if (!available) return false;
    return !available[bookId];
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
  location: new FormControl(this.inventory.location,[this.validateLocation()]),
  });
  }

  private loadBooks(): void {
    this.booksApi.listBooksForAutocomplete().subscribe({
      next: (response) => {
        this.books = response;
        this.setFilteredBooksOptions();
        this.booksAutocompleteInput.setValue(this.inventory.bookId as any);
      },
      error: (err) => this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_BOOKS')),
    });
  }

  private loadStores(){
    const request = new ListStoresRequest();
    request.paging.pageSize=10000000;
    this.storesApi.list(request).subscribe({
      next:(response)=>this.stores=response.items,
      error:(err)=>this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_BOOKS'))
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
    const {storeName, title, isbn, lastRestocked, ...raw} = this.form.value;
    const comamnd = { ...raw, quantityInStock: +raw.quantityInStock, reorderTreshold: +raw.reorderTreshold };
    this.inventoryApi.update(this.storeId, this.bookId,comamnd).subscribe({
      next:(response)=>{
        this.toaster.success(this.translate.instant('INVENTORY.DIALOGS.SUCCESS_UPDATE'));
        this.router.navigate(["/admin/inventory"]);
      },
      error:(err)=>this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_UPDATE'))
    })
  }
  }