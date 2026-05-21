import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, takeUntil } from 'rxjs/operators';
import { FormControl } from '@angular/forms';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import {
  ListOrdersQueryDto,
  ListOrdersRequest,
  OrderStatusType,
} from '../../../api-services/orders/orders-api.models';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';
import { ToasterService } from '../../../core/services/toaster.service';
import { OrderStatusHelper } from '../../../api-services/orders/order-status.helper';
import { ChangeStatusDialogComponent } from './change-status-dialog/change-status-dialog.component';
import { OrderDetailsDialogComponent } from './admin-orders-details-dialog/order-details-dialog.component';
import { TranslateService } from '@ngx-translate/core';
import { SignalRService } from '../../../core/services/signal-r/signal-r.service';
import { getBusinessRuleMessage } from '../../../core/services/business-rule-error.helper';

@Component({
  selector: 'app-admin-orders',
  standalone: false,
  templateUrl: './admin-orders.component.html',
  styleUrl: './admin-orders.component.scss',
})
export class AdminOrdersComponent
  extends BaseListPagedComponent<ListOrdersQueryDto, ListOrdersRequest>
  implements OnInit, OnDestroy
{
  private ordersApi = inject(OrdersApiService);
  private signalR = inject(SignalRService);
  private dialog = inject(MatDialog);
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);
  private destroy$ = new Subject<void>();
  private globalCounter: number = 0;

  // Table columns
  displayedColumns: string[] = [
    'trackingNumber',
    'customer',
    'orderedAt',
    'totalAmount',
    'status',
    'actions',
  ];

  // Search control with debounce
  searchControl = new FormControl('');

  // Status filter
  statusFilterControl = new FormControl<OrderStatusType | null>(null);
  statusOptions = OrderStatusHelper.getStatusOptions();

  get statusFilter(): OrderStatusType | null {
    return this.statusFilterControl.value;
  }

  // Expose OrderStatusType for template
  OrderStatusType = OrderStatusType;

  constructor() {
    super();
    // console.log(this.globalCounter, '. Constructor called:');
    this.globalCounter += this.globalCounter;

    this.request = new ListOrdersRequest();
    this.request.paging.page = 1;
  }

  ngOnInit(): void {
    // console.log(this.globalCounter, '. ngOnInit called:');
    this.globalCounter += this.globalCounter;

    this.getPaginationSettings();
    this.initList();
    this.setupSearchDebounce();

    this.signalR.newPaidOrder$
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => this.loadPagedData());
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private getPaginationSettings() {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const order = JSON.parse(saved);
      this.request.paging.pageSize = Number(order['defaultPageSize']);
    } else {
      this.request.paging.pageSize = 20;
    }
  }

  /**
   * Setup search with debounce and minimum length
   */
  private setupSearchDebounce(): void {
    // console.log(this.globalCounter, '. setupSearchDebounce called:');
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
    // console.log(this.globalCounter, '. loadPagedData called:');
    this.globalCounter += this.globalCounter;

    this.startLoading();

    this.ordersApi.list(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        // console.log(response);
        this.stopLoading();
      },
      error: (err) => {
        this.stopLoading(this.translate.instant('ORDERS.MESSAGES.ERROR_LOAD'));
        console.error('Load orders error:', err);
      },
    });
  }

  // === Filters ===

  onSearchChange(searchTerm: string): void {
    // console.log(this.globalCounter, '. onSearchChange called:');
    this.globalCounter += this.globalCounter;

    this.request.search = searchTerm;
    this.request.paging.page = 1; // Reset to first page
    this.loadPagedData();
  }

  onStatusFilterChange(status: OrderStatusType | null): void {
    // console.log(this.globalCounter, '. onStatusFilterChange called:');
    this.globalCounter += this.globalCounter;

    this.statusFilterControl.setValue(status, { emitEvent: false });
    this.request.status = status !== null ? status : null;
    // Note: Backend needs to support status filter
    // For now, we filter client-side or update backend
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  clearFilters(): void {
    // console.log(this.globalCounter, '. clearFilters called:');
    this.globalCounter += this.globalCounter;

    this.searchControl.setValue('', { emitEvent: false });
    this.statusFilterControl.setValue(null, { emitEvent: false });
    this.request.search = null;
    this.request.status = null;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  // === Actions ===

  onViewDetails(order: ListOrdersQueryDto, event?: MouseEvent): void {
    // console.log(this.globalCounter, '. onViewDetails called:');
    this.globalCounter += this.globalCounter;

    // prevent the button click from bubbling to <tr> and reopening the dialog
    event?.stopPropagation();

    const dialogRef = this.dialog.open(OrderDetailsDialogComponent, {
      width: '900px',
      maxWidth: '95vw',
      maxHeight: '90vh',
      data: {
        orderId: order.orderId,
      },
      panelClass: 'order-details-dialog',
    });

    dialogRef.afterClosed().subscribe((changed: boolean) => {
      if (changed) {
        this.loadPagedData(); // Reload if status changed
      }
    });
  }

  onChangeStatus(order: ListOrdersQueryDto, event?: Event): void {
    // console.log('STATUS CHANGE');
    // console.log(order);
    // console.log(this.globalCounter, '. onChangeStatus called:');
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

    dialogRef.afterClosed().subscribe((newStatus: OrderStatusType | undefined) => {
      if (newStatus !== undefined) {
        this.changeOrderStatus(order.orderId, newStatus);
      }
    });
  }

  private changeOrderStatus(orderId: number, newStatus: OrderStatusType): void {
    this.startLoading();

    this.ordersApi.changeStatus(orderId, newStatus).subscribe({
      next: () => {
        this.toaster.success(this.translate.instant('ORDERS.MESSAGES.STATUS_UPDATED'));
        this.loadPagedData(); // Reload list
      },
      error: (err) => {
        this.stopLoading();

        // Extract error message
        const errorMessage = this.extractErrorMessage(err);
        this.toaster.error(
          errorMessage || this.translate.instant('ORDERS.MESSAGES.ERROR_UPDATE_STATUS'),
        );

        console.error('Change status error:', err);
      },
    });
  }

  get selectedStatusLabel(): string {
    if (this.statusFilter == null) return 'ORDERS.ALL_STATUSES';
    return (
      this.statusOptions.find((x) => x.value === this.statusFilter)?.label ?? 'ORDERS.ALL_STATUSES'
    );
  }

  // === Status Helpers (for template) ===

  getStatusLabel(status: OrderStatusType): string {
    return OrderStatusHelper.getLabel(status);
  }

  getStatusIcon(status: OrderStatusType): string {
    return OrderStatusHelper.getIcon(status);
  }

  getStatusClass(status: OrderStatusType): string {
    return OrderStatusHelper.getColorClass(status);
  }

  canChangeStatus(order: ListOrdersQueryDto): boolean {
    // Can change if not in final state
    return (
      order.statusNameEnum !== OrderStatusType.Shipped &&
      order.statusNameEnum !== OrderStatusType.Cancelled
    );
  }

  // === Display Helpers ===

  getCustomerName(order: ListOrdersQueryDto): string {
    return `${order.userInfo.firstName} ${order.userInfo.lastName}`;
  }

  getCustomerAddress(order: ListOrdersQueryDto): string {
    return `${order.userInfo.userAddress}, ${order.userInfo.userCity}`;
  }

  /**
   * Extract user-friendly error message from HTTP error response.
   *
   * Order of preference:
   *   1. Known BusinessRuleCode -> translated message (ERRORS.BUSINESS_RULES.*).
   *   2. Raw backend message (string body, error.message, error.title).
   *   3. error.message from HttpErrorResponse.
   *   4. null -> caller uses its own generic toast text.
   */
  private extractErrorMessage(err: any): string | null {
    const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
    if (businessRuleMsg) return businessRuleMsg;

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
}
