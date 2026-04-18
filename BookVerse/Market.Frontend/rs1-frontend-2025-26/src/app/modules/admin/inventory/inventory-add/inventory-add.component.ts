import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ListBooksForAutocompleteQueryDto } from '../../../../api-services/books/books-api.models';
import { ToasterService } from '../../../../core/services/toaster.service';
import { BooksApiService } from '../../../../api-services/books/books-api.service';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { InventoryApiService } from '../../../../api-services/inventory/inventory-api.service';
import {
  GetInventoryByIdQueryDto,
  StoreBookPairs,
} from '../../../../api-services/inventory/inventory-api.model';
import {
  ListStoresQueryDto,
  ListStoresRequest,
} from '../../../../api-services/stores/stores-api.model';
import { StoresApiService } from '../../../../api-services/stores/stores-api.service';
import { map, Observable, startWith } from 'rxjs';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'app-products-edit',
  standalone: false,
  templateUrl: './inventory-add.component.html',
  styleUrl: './inventory-add.component.scss',
  // providers:[BooksFormService]
})
export class InventoryAddComponent extends BaseComponent implements OnInit {
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
  form!: FormGroup;

  books: ListBooksForAutocompleteQueryDto[] = [];
  stores: ListStoresQueryDto[] = [];
  inventory!: GetInventoryByIdQueryDto;
  storeBookPairs!: StoreBookPairs;

  filteredBookOptions: Observable<ListBooksForAutocompleteQueryDto[]>[] = [];
  filteredStoreOptions: Observable<ListStoresQueryDto[]>[] = [];

  storesAutocompleteInputs = new FormArray<FormControl>([]);
  booksAutocompleteInputs = new FormArray<FormControl>([]);

  ngOnInit(): void {
    this.startLoading();
    this.bookId = +this.route.snapshot.params['bookId'];
    this.storeId = +this.route.snapshot.params['storeId'];
    this.loadForm();
    this.addStoreAutocompleteInput();
    this.addBookAutocompleteInput();
  }

  private loadForm() {
    this.loadBooks();
    this.loadStores();
    this.loadStoreBookPairs();
    this.createForm();
  }

  private setFilteredStoreOptions(): void {
    this.filteredStoreOptions = this.storesAutocompleteInputs.controls.map(
      //index daje informaciju o tome koja se kontrola promijenila (koji input prodavnice)
      (control: FormControl, index: number) =>
        control.valueChanges.pipe(
          startWith(''),
          map((value) => this._filterStores(value || '', index)),
        ),
    );
  }

  private _filterStores(enteredValue: string, index: number): ListStoresQueryDto[] {
    //ima 1 filter
    //filter definiše korisnik -> npr. unese slovo "a" u store autocomplete polju za unos

    const filterValue = enteredValue.toLowerCase();
    const result = this.stores.filter((store) =>
      store.storeName.toLowerCase().includes(filterValue),
    );
    return result;
  }

  clearBookInSameRow(index: number) {
    //počistiti autocomplete polje u istom redu gdje se unosi naziv knjige
    this.booksAutocompleteInputs.at(index).setValue('');
  }

  private setFilteredBookOptions(): void {
    this.filteredBookOptions = this.booksAutocompleteInputs.controls.map(
      (control: FormControl) =>
        control.valueChanges.pipe(
          startWith(''),
          map((value) => this._filterBooks(typeof value === 'string' ? value : '')),
        ),
    );
  }

  private _filterBooks(enteredValue: string): ListBooksForAutocompleteQueryDto[] {
    const filterValue = enteredValue.toLowerCase();
    return this.books.filter((x) => x.title.toLowerCase().includes(filterValue));
  }

  addStoreAutocompleteInput() {
    this.storesAutocompleteInputs.push(new FormControl('', Validators.required));
    this.setFilteredStoreOptions();
  }

  addBookAutocompleteInput() {
    this.booksAutocompleteInputs.push(new FormControl('', Validators.required));
    this.setFilteredBookOptions();
  }

  deleteInventoryRow(index: number) {
    this.inventoryArray.removeAt(index);
    this.booksAutocompleteInputs.removeAt(index);
    this.storesAutocompleteInputs.removeAt(index);
    this.setFilteredBookOptions();
  }

  onStoreSelected(event: MatAutocompleteSelectedEvent, index: number) {
    this.clearBookInSameRow(index);
    const storeId = this.stores.filter((x) => x.storeName == event.option.value).at(0)?.id;
    if (storeId) this.inventoryArray.at(index).get('storeId')?.setValue(storeId);
  }

  displayBookTitle = (book: ListBooksForAutocompleteQueryDto | string): string => {
    if (!book) return '';
    if (typeof book === 'string') return book;
    return book.title;
  };

  onBookSelected(event: MatAutocompleteSelectedEvent, index: number) {
    const book: ListBooksForAutocompleteQueryDto = event.option.value;
    this.inventoryArray.at(index).get('bookId')?.setValue(book.id);
  }

  loadStoreBookPairs() {
    this.inventoryApi.getStoreBookPairs().subscribe({
      next: (response) => (this.storeBookPairs = response),
      error: (err) => this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_STORE_BOOK_PAIRS')),
    });
  }

  public get inventoryArray(): FormArray {
    return this.form.get('inventoryInfo') as FormArray;
  }

  private createForm() {
    this.form = this.formBuilder.group({
      inventoryInfo: new FormArray([
        new FormGroup({
          storeId: new FormControl('', Validators.required),
          bookId: new FormControl('', Validators.required),
          quantityInStock: new FormControl('', Validators.required),
          reorderTreshold: new FormControl('', Validators.required),
          location: new FormControl('', this.validateLocation()),
        }),
      ]),
    });
    this.stopLoading();
  }

  private loadBooks() {
    this.booksApi.listBooksForAutocomplete().subscribe({
      next: (response) => (this.books = response),
      error: (err) => this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_BOOKS')),
    });
  }

  private loadStores() {
    const request = new ListStoresRequest();
    request.paging.pageSize = 10000000;
    this.storesApi.list(request).subscribe({
      next: (response) => (this.stores = response.items),
      error: (err) => this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_BOOKS')),
    });
  }

  addNewInventoryRow() {
    const inventoryGroup = new FormGroup({
      storeId: new FormControl('', Validators.required),
      bookId: new FormControl('', Validators.required),
      quantityInStock: new FormControl('', Validators.required),
      reorderTreshold: new FormControl('', Validators.required),
      location: new FormControl('', this.validateLocation()),
    });
    this.inventoryArray.push(inventoryGroup);
    this.addStoreAutocompleteInput(); //dodaji novi mat-autocomplete za prodavnice
    this.addBookAutocompleteInput(); //dodaji novi mat-autocomplete za knjige
  }

  private validateLocation(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!control || !control.value || control.value === '') return null;

      let regexRule = /^Polica [A-Z]-[0-9]{1,}$/;
      return regexRule.test(control.value) ? null : { nevalidnaLokacija: true };
    };
  }

  onSubmit() {
    this.inventoryApi.create(this.form.getRawValue()).subscribe({
      next: (response) => {
        this.toaster.success(this.translate.instant('INVENTORY.DIALOGS.SUCCESS_CREATE'));
        this.router.navigate(['/admin/inventory']);
      },
      error: (err) => this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_CREATE')),
    });
  }
}
