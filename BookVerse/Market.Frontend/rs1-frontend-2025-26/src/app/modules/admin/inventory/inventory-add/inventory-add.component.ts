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
  storeBookPairs!: StoreBookPairs; //sadrži kombinacije prodavnica i knjiga koje NEMAJU popisan inventar

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
    // Pretvara ukucani tekst u mala slova da bi pretraga bila case-insensitive — npr. "kNjiga" i "knjiga" tretiraju se isto.
    const filterValue = enteredValue.toLowerCase();
    // Provjerava da li je korisnik već odabrao knjigu u istom redu forme.
    // Ako je knjiga već odabrana, lista prodavnica treba biti sužena samo na one koje nemaju popisan inventar za nju.
    const selectedBookId = this.inventoryArray?.at(index)?.get('bookId')?.value;

    // Prolazi kroz sve prodavnice i za svaku odlučuje da li će biti prikazana u dropdownu (vraća true) ili ne (vraća false).
    return this.stores.filter((store) => {
      // Prva provjera: Da li naziv prodavnice sadrži ukucani tekst?
      // Ako ne — odmah izbaci tu prodavnicu iz liste (vrati false)
      // Npr. korisnik je ukucao prodavnicu koja ne postoji "p67" — samo prodavnice čiji naziv sadrži "p67" prolaze dalje.
      if (!store.storeName.toLowerCase().includes(filterValue)) return false;
      // Druga provjera: Da li je korisnik uopće odabrao neku knjigu?
      // Ako nije — vrati true i prikaži sve prodavnice koje su prošle prvu provjeru (nema potrebe za daljnjim filtriranjem).
      if (!selectedBookId) return true;
      // Ako je knjiga odabrana, uzima se objekat za tu prodavnicu iz storeBookPairs.
      // Npr. za prodavnicu sa id=2, availableBooks bi bio { 11: "Zločin i kazna", 12: "Crveno i crno" }.
      const availableBooks = this.storeBookPairs?.[store.id];
      // Treća provjera (dvostruka):
      // !!availableBooks — da li ta prodavnica uopće postoji u storeBookPairs (TRUE znači da postoje knjige koje nemaju popisan inventar u njoj)?
      // !!availableBooks[selectedBookId] — da li ta prodavnica ima baš tu odabranu knjigu? (TRUE znači da ima tu knjigu, to jeste da za odabranu knjigu nije popisan inventar)
      // Dakle, prodavnicu ćemo ispisati AKO i samo AKO postoje knjige koje nemaju popisan inventar u njoj i selectedBookId nema popisan inventar u njoj
      return !!availableBooks && !!availableBooks[selectedBookId];
    });
  }

  //clearBookInSameRow(index: number) {
  //počistiti autocomplete polje u istom redu gdje se unosi naziv knjige
  //this.booksAutocompleteInputs.at(index).setValue('');
  //}

  private setFilteredBookOptions(): void {
    this.filteredBookOptions = this.booksAutocompleteInputs.controls.map(
      (control: FormControl, index: number) =>
        control.valueChanges.pipe(
          startWith(''),
          map((value) => this._filterBooks(typeof value === 'string' ? value : '', index)),
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
    //this.clearBookInSameRow(index);
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

  //dohvata kombinacije prodavnica i knjiga koje NEMAJU popisan inventar
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
