import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ListBooksForAutocompleteQueryDto } from '../../../../api-services/books/books-api.models';
import { ToasterService } from '../../../../core/services/toaster.service';
import { BooksApiService } from '../../../../api-services/books/books-api.service';
import { BaseComponent } from '../../../../core/components/base-classes/base-component';
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
  storeBookPairs!: StoreBookPairs; //contains store-book combinations that do NOT have inventory recorded

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
      (control: FormControl, index: number) =>
        control.valueChanges.pipe(
          startWith(control.value),
          map((value) => {
            const text = typeof value === 'string' ? value : '';
            const storeIdCtrl = this.inventoryArray?.at(index)?.get('storeId');
            const exact = this.stores.find((s) => s.storeName.toLowerCase() === text.toLowerCase());
            if (exact) {
              if (storeIdCtrl?.value !== exact.id)
                storeIdCtrl?.setValue(exact.id, { emitEvent: false });
            } else if (storeIdCtrl?.value) {
              storeIdCtrl?.setValue('', { emitEvent: false });
            }
            return this._filterStores(text, index);
          }),
        ),
    );
  }

  private _filterStores(enteredValue: string, index: number): ListStoresQueryDto[] {
    // Converts the entered text to lowercase for case-insensitive search — e.g., "bOok" and "book" are treated the same.
    const filterValue = enteredValue.toLowerCase();
    // Checks whether the user has already selected a book in the same form row.
    // If a book is already selected, the store list should be narrowed to only those without inventory for that book.
    const selectedBookId = this.inventoryArray?.at(index)?.get('bookId')?.value;

    // Iterates through all stores and decides whether each will be shown in the dropdown (returns true) or not (returns false).
    return this.stores.filter((store) => {
      // First check: Does the store name contain the entered text?
      // If not — immediately exclude the store from the list (return false)
      // E.g., if the user typed "p67" — only stores whose name contains "p67" pass through.
      if (!store.storeName.toLowerCase().includes(filterValue)) return false;
      // Second check: Has the user selected any book at all?
      // If not — return true and show all stores that passed the first check (no further filtering needed).
      if (!selectedBookId) return true;
      // If a book is selected, get the object for that store from storeBookPairs.
      // E.g., for a store with id=2, availableBooks would be { 11: "Crime and Punishment", 12: "The Red and the Black" }.
      const availableBooks = this.storeBookPairs?.[store.id];
      // Third check (double):
      // !! operator -> converts into boolean
      // !!availableBooks — does that store exist at all in storeBookPairs (TRUE means there are books without inventory in it)?
      // !!availableBooks[selectedBookId] — does that store have exactly the selected book? (TRUE means it has it, i.e., no inventory recorded for it)
      // So, a store will be shown IF AND ONLY IF there are books without inventory in it and selectedBookId has no inventory in it
      return !!availableBooks && !!availableBooks[selectedBookId];
    });
  }

  //clearBookInSameRow(index: number) {
  //clear the autocomplete field in the same row where the book title is entered
  //this.booksAutocompleteInputs.at(index).setValue('');
  //}

  private setFilteredBookOptions(): void {
    this.filteredBookOptions = this.booksAutocompleteInputs.controls.map(
      (control: FormControl, index: number) =>
        control.valueChanges.pipe(
          startWith(control.value),
          map((value) => {
            const text =
              typeof value === 'string'
                ? value
                : ((value as ListBooksForAutocompleteQueryDto)?.title ?? '');
            const bookIdCtrl = this.inventoryArray?.at(index)?.get('bookId');
            if (typeof value === 'string') {
              const exact = this.books.find((b) => b.title.toLowerCase() === text.toLowerCase());
              if (exact) {
                if (bookIdCtrl?.value !== exact.id)
                  bookIdCtrl?.setValue(exact.id, { emitEvent: false });
              } else if (bookIdCtrl?.value) {
                bookIdCtrl?.setValue('', { emitEvent: false });
              }
            }
            return this._filterBooks(text, index);
          }),
        ),
    );
  }

  private _filterBooks(enteredValue: string, index: number): ListBooksForAutocompleteQueryDto[] {
    const filterValue = enteredValue.toLowerCase();
    const selectedStoreId = this.inventoryArray?.at(index)?.get('storeId')?.value;

    return this.books.filter((book) => {
      if (!book.title.toLowerCase().includes(filterValue)) return false;
      if (!selectedStoreId) return true;
      const availableBooks = this.storeBookPairs?.[selectedStoreId];
      return !!availableBooks && !!availableBooks[book.id];
    });
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
    const storeId = this.stores.filter((x) => x.storeName == event.option.value).at(0)?.id;
    if (storeId) this.inventoryArray.at(index).get('storeId')?.setValue(storeId);
    const bookCtrl = this.booksAutocompleteInputs.at(index);
    bookCtrl.setValue(bookCtrl.value);
  }

  displayBookTitle = (book: ListBooksForAutocompleteQueryDto | string): string => {
    if (!book) return '';
    if (typeof book === 'string') return book;
    return book.title;
  };

  onBookSelected(event: MatAutocompleteSelectedEvent, index: number) {
    const book: ListBooksForAutocompleteQueryDto = event.option.value;
    this.inventoryArray.at(index).get('bookId')?.setValue(book.id);
    const storeCtrl = this.storesAutocompleteInputs.at(index);
    storeCtrl.setValue(storeCtrl.value);
  }

  //fetches store-book combinations that do NOT have inventory recorded
  loadStoreBookPairs() {
    this.inventoryApi.getStoreBookPairs().subscribe({
      next: (response) => (this.storeBookPairs = response),
      error: (err) =>
        this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_STORE_BOOK_PAIRS')),
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
      error: (err) =>
        this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_BOOKS')),
    });
  }

  private loadStores() {
    const request = new ListStoresRequest();
    request.paging.pageSize = 10000000;
    this.storesApi.list(request).subscribe({
      next: (response) => (this.stores = response.items),
      error: (err) =>
        this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD_BOOKS')),
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
    this.addStoreAutocompleteInput(); //add a new mat-autocomplete for stores
    this.addBookAutocompleteInput(); //add a new mat-autocomplete for books
  }

  private validateLocation(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!control || !control.value || control.value === '') return null;

      let regexRule = /^[A-Z]-[0-9]{1,}$/;
      return regexRule.test(control.value) ? null : { nevalidnaLokacija: true };
    };
  }

  onSubmit() {
    this.inventoryApi.create(this.form.getRawValue()).subscribe({
      next: (response) => {
        this.toaster.success(this.translate.instant('INVENTORY.DIALOGS.SUCCESS_CREATE'));
        this.router.navigate(['/admin/inventory']);
      },
      error: (err) => {
        if (err.status === 409) {
          let storeName = '';
          let bookTitle = '';
          for (let i = 0; i < this.inventoryArray.length; i++) {
            const storeId = this.inventoryArray.at(i).get('storeId')?.value;
            const bookId = this.inventoryArray.at(i).get('bookId')?.value;
            if (storeId && bookId && this.storeBookPairs?.[storeId]?.[bookId]) {
              storeName = this.storesAutocompleteInputs.at(i).value ?? '';
              const bookInput = this.booksAutocompleteInputs.at(i).value;
              bookTitle = typeof bookInput === 'string' ? bookInput : (bookInput?.title ?? '');
              break;
            }
          }
          this.toaster.error(
            this.translate.instant('INVENTORY.DIALOGS.DUPLICATE_INVENTORY', {
              storeName,
              bookTitle,
            }),
          );
        } else {
          this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_CREATE'));
        }
      },
    });
  }
}
