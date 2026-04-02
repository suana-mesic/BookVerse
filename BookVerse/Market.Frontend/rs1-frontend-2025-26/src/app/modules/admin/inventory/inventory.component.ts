import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable, Subject } from 'rxjs';
import {
  debounceTime,
  distinctUntilChanged,
  filter,
  map,
  startWith,
  takeUntil,
} from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import {
  ListOrdersQueryDto,
  ListOrdersRequest,
  OrderStatusType,
} from '../../../api-services/orders/orders-api.models';
import { ToasterService } from '../../../core/services/toaster.service';
import { OrderStatusHelper } from '../../../api-services/orders/order-status.helper';
import { ChangeStatusDialogComponent } from '../orders/change-status-dialog/change-status-dialog.component';
import {
  ListInventoryQueryDto,
  ListInventoryRequest,
} from '../../../api-services/inventory/inventory-api.model';
import { InventoryApiService } from '../../../api-services/inventory/inventory-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
import { TranslateService } from '@ngx-translate/core';
import { BooksApiService } from '../../../api-services/books/books-api.service';
import { StoresApiService } from '../../../api-services/stores/stores-api.service';
import {
  ListBooksForAutocompleteQueryDto,
  ListBooksQueryDto,
  ListBooksRequest,
} from '../../../api-services/books/books-api.models';
import {
  ListStoresQueryDto,
  ListStoresRequest,
} from '../../../api-services/stores/stores-api.model';
import { ListBookFormatsRequest } from '../../../api-services/book-formats/book-format-api.model';

@Component({
  selector: 'app-admin-orders',
  standalone: false,
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.scss',
})
export class InventoryComponent
  extends BaseListPagedComponent<ListInventoryQueryDto, ListInventoryRequest>
  implements OnInit, OnDestroy
{
  private inventoryApi = inject(InventoryApiService);
  private dialog = inject(MatDialog);
  private toaster = inject(ToasterService);
  private destroy$ = new Subject<void>();
  private globalCounter: number = 0;
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private dialogHelper = inject(DialogHelperService);
  private booksApi = inject(BooksApiService);
  private storesApi = inject(StoresApiService);
  private translate = inject(TranslateService);

  // Table columns
  displayedColumns: string[] = [
    'storeName',
    'isbn',
    'title',
    'quantityInStock',
    'lastRestocked',
    'reorderTreshold',
    'location',
    'quantityInStockForOnlineOrders',
    'actions',
  ];

  // Search control with debounce
  searchControl = new FormControl('');
  booksAutocompleteInput = new FormControl('');
  storesAutocompleteInput = new FormControl('');

  searchStoreId = new FormControl(null);
  searchBookId = new FormControl(null);

  filteredBookOptions!: Observable<ListBooksForAutocompleteQueryDto[]>;
  filteredStoresOptions!: Observable<ListStoresQueryDto[]>;

  stores: ListStoresQueryDto[] = [];
  books: ListBooksForAutocompleteQueryDto[] = [];

  constructor() {
    super();
    console.log(this.globalCounter, '. Pozvan je constructor:');
    this.globalCounter += this.globalCounter;

    this.request = new ListInventoryRequest();
    this.request.paging.pageSize = 20;
    this.setFilteredBookOptions();
    this.setFilteredStoresOptions();
  }

  ngOnInit(): void {
    console.log(this.globalCounter, '. Pozvan je ngOnInit:');
    this.globalCounter += this.globalCounter;

    this.initList();
    this.loadBooks();
    this.loadStores();
    this.setupSearchDebounce();
    this.setupSearchByBookDebounce();
    this.setupSearchByStoreDebounce();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  setFilteredBookOptions() {
    console.log('Pozvana je metoda setFilteredBookOptions');
    this.filteredBookOptions = this.booksAutocompleteInput.valueChanges.pipe(
      startWith(''),
      map((value) => this._filterBooks(value || '')),
    );
  }

  setFilteredStoresOptions() {
    console.log('Pozvana je metoda setFilteredStoresOptions');
    this.filteredStoresOptions = this.storesAutocompleteInput.valueChanges.pipe(
      startWith(''),
      map((value) => this._filterStores(value || '')),
    );
  }

  private setupSearchByBookDebounce(): void {
    console.log(this.globalCounter, '. Pozvan je setupSearchByBookDebounce:');
    this.globalCounter += this.globalCounter;

    this.booksAutocompleteInput.valueChanges
      .pipe(
        debounceTime(400),
        distinctUntilChanged(), // Only if value actually changed
        takeUntil(this.destroy$),
      )
      .subscribe((searchTerm) => {
        this.onSearchChange();
      });
  }

  private setupSearchByStoreDebounce(): void {
    console.log(this.globalCounter, '. Pozvan je setupSearchByStoreDebounce:');
    this.globalCounter += this.globalCounter;

    this.storesAutocompleteInput.valueChanges
      .pipe(
        debounceTime(400),
        distinctUntilChanged(), // Only if value actually changed
        takeUntil(this.destroy$),
      )
      .subscribe((searchTerm) => {
        this.onSearchChange();
      });
  }

  private _filterBooks(value: string): ListBooksForAutocompleteQueryDto[] {
    const filterValue = value.toLowerCase();
    return this.books.filter((book) => book.title.toLowerCase().includes(filterValue));
  }

  private _filterStores(value: string): ListStoresQueryDto[] {
    const filterValue = value.toLowerCase();
    return this.stores.filter((store) => store.storeName.toLowerCase().includes(filterValue));
  }

  /**
   * Setup search with debounce and minimum length
   */
  private setupSearchDebounce(): void {
    console.log(this.globalCounter, '. Pozvan je setupSearchDebounce:');
    this.globalCounter += this.globalCounter;

    this.searchControl.valueChanges
      .pipe(
        debounceTime(400), // Wait 400ms after user stops typing
        distinctUntilChanged(), // Only if value actually changed
        takeUntil(this.destroy$),
      )
      .subscribe((searchTerm) => {
        // Only search if 3+ characters or empty (to clear)
        if (!searchTerm || searchTerm.length >= 3) {
          this.onSearchChange(searchTerm || '');
        }
      });
  }

  protected loadPagedData(): void {
    console.log(this.globalCounter, '. Pozvan je loadPagedData:');
    this.globalCounter += this.globalCounter;

    this.startLoading();

    this.inventoryApi.list(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading(this.translate.instant('INVENTORY.DIALOGS.ERROR_LOAD'));
        console.error('Load orders error:', err);
      },
    });
  }

  // === Filters ===

  onSearchChange(searchTerm?: string): void {
    console.log(this.globalCounter, '. Pozvan je onSearchChange:');
    this.globalCounter += this.globalCounter;

    this.request.search = searchTerm;
    this.request.book = this.booksAutocompleteInput.value ?? null;
    this.request.store = this.storesAutocompleteInput.value ?? null;
    this.request.paging.page = 1; // Reset to first page

    this.loadPagedData();
  }

  clearFilters(): void {
    console.log(this.globalCounter, '. Pozvan je clearFilters:');
    this.globalCounter += this.globalCounter;

    this.searchControl.setValue('', { emitEvent: false });
    this.booksAutocompleteInput.setValue(null);
    this.storesAutocompleteInput.setValue(null);
    this.request.store = null;
    this.request.paging.page = 1;
    this.loadPagedData();
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

  onChangeStatus(order: ListOrdersQueryDto, event?: Event): void {
    console.log(this.globalCounter, '. Pozvan je onChangeStatus:');
    this.globalCounter += this.globalCounter;

    // Prevent row click
    if (event) {
      event.stopPropagation();
    }

    const dialogRef = this.dialog.open(ChangeStatusDialogComponent, {
      width: '500px',
      maxWidth: '90vw',
      data: {
        order: order,
      },
      panelClass: 'change-status-dialog',
    });
  }

  editInventory(storeId: number, bookId: number) {
    //inventory/edit/store/:id/book/:id
    this.router.navigate(['/admin/inventory/edit/store', storeId, 'book', bookId]);
  }

  deleteInventory(storeId: number, storeName: string, bookId: number) {
    this.dialogHelper.inventory.confirmDelete(storeName).subscribe((result) => {
      if (result && result.button === DialogButton.DELETE) {
        this.performDelete(storeId, bookId);
      }
    });
  }

  performDelete(storeId: number, bookId: number) {
    this.inventoryApi.delete(storeId, bookId).subscribe({
      next: (response) => {
        this.dialogHelper.inventory.showDeleteSuccess().subscribe();
        this.loadPagedData();
      },
      error: (err) => {
        this.toaster.error(this.translate.instant('INVENTORY.DIALOGS.ERROR_DELETE'));
      },
    });
  }
}
