import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import { ListOrdersQueryDto, ListOrdersRequest, OrderStatusType } from '../../../api-services/orders/orders-api.models';
import { ToasterService } from '../../../core/services/toaster.service';
import { OrderStatusHelper } from '../../../api-services/orders/order-status.helper';
import { ChangeStatusDialogComponent } from '../orders/change-status-dialog/change-status-dialog.component';
import { ListInventoryQueryDto, ListInventoryRequest } from '../../../api-services/inventory/inventory-api.model';
import { InventoryApiService } from '../../../api-services/inventory/inventory-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';


@Component({
  selector: 'app-admin-orders',
  standalone: false,
  templateUrl: './inventory.component.html',
  styleUrl: './inventory.component.scss',
})
export class InventoryComponent
  extends BaseListPagedComponent<ListInventoryQueryDto, ListInventoryRequest>
  implements OnInit, OnDestroy {

  private inventoryApi = inject(InventoryApiService);
  private dialog = inject(MatDialog);
  private toaster = inject(ToasterService);
  private destroy$ = new Subject<void>();
  private globalCounter: number = 0;
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private dialogHelper = inject(DialogHelperService);
  

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
    'actions'
    // 'trackingNumber',
    // 'customer',
    // 'orderedAt',
    // 'totalAmount',
    // 'status',
  ];

  // Search control with debounce
  searchControl = new FormControl('');

  // Status filter
  statusFilter: OrderStatusType | null = null;
  statusOptions = OrderStatusHelper.getStatusOptions();

  // Expose OrderStatusType for template
  OrderStatusType = OrderStatusType;

  constructor() {
    super();
    console.log(this.globalCounter, ". Pozvan je constructor:");
    this.globalCounter += this.globalCounter;

    this.request = new ListInventoryRequest();
    this.request.paging.pageSize = 20;
  }

  ngOnInit(): void {
    console.log(this.globalCounter, ". Pozvan je ngOnInit:");
    this.globalCounter += this.globalCounter;

    this.initList();
    this.setupSearchDebounce();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  /**
   * Setup search with debounce and minimum length
   */
  private setupSearchDebounce(): void {
    console.log(this.globalCounter, ". Pozvan je setupSearchDebounce:");
    this.globalCounter += this.globalCounter;

    this.searchControl.valueChanges
      .pipe(
        debounceTime(400), // Wait 400ms after user stops typing
        distinctUntilChanged(), // Only if value actually changed
        takeUntil(this.destroy$)
      )
      .subscribe((searchTerm) => {
        // Only search if 3+ characters or empty (to clear)
        if (!searchTerm || searchTerm.length >= 3) {
          this.onSearchChange(searchTerm || '');
        }
      });
  }

  protected loadPagedData(): void {
    console.log(this.globalCounter, ". Pozvan je loadPagedData:");
    this.globalCounter += this.globalCounter;

    this.startLoading();

    this.inventoryApi.list(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading('Failed to load orders');
        console.error('Load orders error:', err);
      },
    });
  }

  // === Filters ===

  onSearchChange(searchTerm: string): void {
    console.log(this.globalCounter, ". Pozvan je onSearchChange:");
    this.globalCounter += this.globalCounter;

    this.request.search = searchTerm;
    this.request.paging.page = 1; // Reset to first page
    this.loadPagedData();
  }

  onStatusFilterChange(status: OrderStatusType | null): void {
    console.log(this.globalCounter, ". Pozvan je onStatusFilterChange:");
    this.globalCounter += this.globalCounter;

    this.statusFilter = status;
    // Note: Backend needs to support status filter
    // For now, we filter client-side or update backend
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  clearFilters(): void {
    console.log(this.globalCounter, ". Pozvan je clearFilters:");
    this.globalCounter += this.globalCounter;


    this.searchControl.setValue('', { emitEvent: false });
    this.statusFilter = null;
    this.request.search = null;
    this.request.paging.page = 1;
    this.loadPagedData();
  }


  // onViewDetails(order: ListOrdersQueryDto, event?: MouseEvent): void {
  //   console.log(this.globalCounter, ". Pozvan je onViewDetails:");
  //   this.globalCounter += this.globalCounter;

  //   // spriječi da klik sa dugmeta ode na <tr> i ponovo otvori dialog
  //   event?.stopPropagation();

  //   const dialogRef = this.dialog.open(OrderDetailsDialogComponent, {
  //     width: '900px',
  //     maxWidth: '95vw',
  //     maxHeight: '90vh',
  //     data: {
  //       orderId: order.id
  //     },
  //     panelClass: 'order-details-dialog'
  //   });

  //   dialogRef.afterClosed().subscribe((changed: boolean) => {
  //     if (changed) {
  //       this.loadPagedData(); // Reload if status changed
  //     }
  //   });
  // }

  onChangeStatus(order: ListOrdersQueryDto, event?: Event): void {
    console.log(this.globalCounter, ". Pozvan je onChangeStatus:");
    this.globalCounter += this.globalCounter;

    // Prevent row click
    if (event) {
      event.stopPropagation();
    }

    const dialogRef = this.dialog.open(ChangeStatusDialogComponent, {
      width: '500px',
      maxWidth: '90vw',
      data: {
        order: order
      },
      panelClass: 'change-status-dialog'
    });

    // dialogRef.afterClosed().subscribe((newStatus: OrderStatusType | undefined) => {
    //   if (newStatus !== undefined) {
    //     this.changeOrderStatus(order.id, newStatus);
    //   }
    // });
  }

  // private changeOrderStatus(orderId: number, newStatus: OrderStatusType): void {
  //   this.startLoading();

  //   this.inventoryApi.changeStatus(orderId, newStatus).subscribe({
  //     next: () => {
  //       this.toaster.success('Order status updated successfully');
  //       this.loadPagedData(); // Reload list
  //     },
  //     error: (err) => {
  //       this.stopLoading();

  //       // Extract error message
  //       const errorMessage = this.extractErrorMessage(err);
  //       this.toaster.error(errorMessage || 'Failed to update order status');

  //       console.error('Change status error:', err);
  //     }
  //   });
  // }

  // === Status Helpers (for template) ===

  getStatusLabel(status: OrderStatusType): string {
    return OrderStatusHelper.getLabel(status);
  }

  getStatusIcon(status: OrderStatusType): string {
    console.log("Order status type is, ", status);
    return OrderStatusHelper.getIcon(status);
  }

  getStatusClass(status: OrderStatusType): string {
    return OrderStatusHelper.getColorClass(status);
  }

  canChangeStatus(order: ListOrdersQueryDto): boolean {
    // Can change if not in final state
    return order.statusNameEnum !== OrderStatusType.Completed &&
      order.statusNameEnum !== OrderStatusType.Cancelled;
  }

  // === Display Helpers ===

  getCustomerName(order: ListOrdersQueryDto): string {
    return `${order.userInfo.firstName} ${order.userInfo.lastName}`;
  }

  getCustomerAddress(order: ListOrdersQueryDto): string {
    return `${order.userInfo.userAddress}, ${order.userInfo.userCity}`;
  }

  /**
   * Extract user-friendly error message from HTTP error response
   */
  private extractErrorMessage(err: any): string | null {
    if (err?.error) {
      if (typeof err.error === 'string') {
        return err.error;
      }

      if (err.error.message) {
        return err.error.message;
      }

      if (err.error.title) {
        return err.error.title;
      }
    }

    if (err?.message) {
      return err.message;
    }

    return null;
  }

  editInventory(storeId: number, bookId: number) {
    //inventory/edit/store/:id/book/:id
    this.router.navigate(["/admin/inventory/edit/store", storeId,"book", bookId]);
  }

  deleteInventory(storeId: number, storeName:string, bookId: number) {
    this.dialogHelper.inventory.confirmDelete(storeName).subscribe(result => {
        if (result && result.button === DialogButton.DELETE) {
            this.performDelete(storeId, bookId);
          }
        });
  }

  performDelete(storeId: number, bookId: number){
    this.inventoryApi.delete(storeId, bookId).subscribe({
      next:(response)=> {
        this.dialogHelper.inventory.showDeleteSuccess().subscribe();
        this.loadPagedData();
      },
      error:(err)=>{
        this.toaster.error("Greška prilikom brisanja inventara");
      }
    })
  }
}
