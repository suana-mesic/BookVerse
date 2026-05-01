import { Component, inject, OnInit } from '@angular/core';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';
import { ToasterService } from '../../../core/services/toaster.service';
import {
  ListOrdersForUserQueryDto,
  ListOrdersForUserRequest,
  OrderStatusType,
} from '../../../api-services/orders/orders-api.models';
import { BaseListPagedComponent } from '../../../core/components/base-classes/base-list-paged-component';
import { debounceTime, distinctUntilChanged, Subject, takeUntil } from 'rxjs';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
import { Location } from '@angular/common';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { SignalRService } from '../../../core/services/signal-r/signal-r.service';
@Component({
  selector: 'app-user-orders',
  standalone: false,
  templateUrl: './user-orders.component.html',
  styleUrl: './user-orders.component.scss',
})
export class UserOrdersComponent
  extends BaseListPagedComponent<ListOrdersForUserQueryDto, ListOrdersForUserRequest>
  implements OnInit
{
  private ordersService = inject(OrdersApiService);
  private signalR = inject(SignalRService);
  private toaster = inject(ToasterService);
  private destroy$ = new Subject<void>();
  private router = inject(Router);
  private dialogHelper = inject(DialogHelperService);
  private location = inject(Location);
  private translate = inject(TranslateService);

  searchControl = new FormControl('');
  statusFilterControl = new FormControl<OrderStatusType | null>(null);
  OrderStatusType = OrderStatusType;

  get statusFilter(): OrderStatusType | null {
    return this.statusFilterControl.value;
  }
  selectedOrder: ListOrdersForUserQueryDto | null = null;
  currentSlide = 0;

  cancellableStatuses = [OrderStatusType.Draft, OrderStatusType.Paid, OrderStatusType.Packed];

  constructor() {
    super();
    this.request = new ListOrdersForUserRequest();
    this.request.paging.page = 1;
    this.request.paging.pageSize = 10;
    this.request.language = this.translate.currentLang || this.translate.defaultLang || 'bs';
  }

  ngOnInit(): void {
    this.initList();
    this.setupSearchDebounce();

    this.translate.onLangChange
      .pipe(takeUntil(this.destroy$))
      .subscribe((event: LangChangeEvent) => {
        this.request.language = event.lang;
        this.loadPagedData();
      });

    this.signalR.orderStatusChanged$
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => this.loadPagedData());
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  private setupSearchDebounce(): void {
    this.searchControl.valueChanges
      .pipe(debounceTime(400), distinctUntilChanged(), takeUntil(this.destroy$))
      .subscribe((value) => {
        if (!value || value.length >= 3) {
          this.request.search = value || null;
          this.request.paging.page = 1;
          this.selectedOrder = null;
          this.loadPagedData();
        }
      });
  }

  public override loadPagedData(): void {
    this.startLoading();
    this.ordersService.listForUser(this.request).subscribe({
      next: (response) => {
        this.handlePageResult(response);
        this.stopLoading();
      },
      error: () => {
        this.stopLoading(this.translate.instant('CLIENT.USER_ORDERS.ERROR_LOAD'));
      },
    });
  }

  onStatusFilterChange(status: OrderStatusType | null): void {
    this.statusFilterControl.setValue(status, { emitEvent: false });
    this.request.status = status;
    this.request.paging.page = 1;
    this.selectedOrder = null;
    this.loadPagedData();
  }

  clearFilters(): void {
    this.searchControl.setValue('', { emitEvent: false });
    this.statusFilterControl.setValue(null, { emitEvent: false });
    this.request.search = null;
    this.request.status = null;
    this.request.paging.page = 1;
    this.selectedOrder = null;
    this.loadPagedData();
  }

  cancelOrder(id: number): void {
    this.dialogHelper
      .confirm(
        this.translate.instant('CLIENT.USER_ORDERS.CANCEL_TITLE'),
        this.translate.instant('CLIENT.USER_ORDERS.CANCEL_CONFIRM'),
      )
      .subscribe((response) => {
        if (response?.button == DialogButton.YES) {
          this.ordersService.cancelOrder(id).subscribe({
            next: () => {
              this.toaster.success(this.translate.instant('CLIENT.USER_ORDERS.ORDER_CANCELLED'));
              this.loadPagedData();
            },
            error: () => {
              this.toaster.error(this.translate.instant('CLIENT.USER_ORDERS.ERROR_CANCEL'));
            },
          });
        }
      });
  }

  canCancel(status: OrderStatusType): boolean {
    return this.cancellableStatuses.includes(status);
  }
  getStatusLabel(status: OrderStatusType): string {
    const labels: Record<OrderStatusType, string> = {
      [OrderStatusType.Draft]: this.translate.instant('CLIENT.USER_ORDERS.STATUS_DRAFT'),
      [OrderStatusType.Paid]: this.translate.instant('CLIENT.USER_ORDERS.STATUS_PAID'),
      [OrderStatusType.Packed]: this.translate.instant('CLIENT.USER_ORDERS.STATUS_PACKED'),
      [OrderStatusType.Shipped]: this.translate.instant('CLIENT.USER_ORDERS.STATUS_SHIPPED'),
      [OrderStatusType.Cancelled]: this.translate.instant('CLIENT.USER_ORDERS.STATUS_CANCELLED'),
    };
    return labels[status] ?? this.translate.instant('CLIENT.USER_ORDERS.STATUS_UNKNOWN');
  }

  getStatusClass(status: OrderStatusType): string {
    const classes: Record<OrderStatusType, string> = {
      [OrderStatusType.Draft]: 'status-draft',
      [OrderStatusType.Paid]: 'status-paid',
      [OrderStatusType.Packed]: 'status-packed',
      [OrderStatusType.Shipped]: 'status-shipped',
      [OrderStatusType.Cancelled]: 'status-cancelled',
    };
    return classes[status] ?? '';
  }

  selectOrder(order: ListOrdersForUserQueryDto): void {
    this.selectedOrder = this.selectedOrder?.id === order.id ? null : order;
    this.currentSlide = 0; // reset to the first book
  }

  nextSlide(): void {
    if (this.selectedOrder && this.currentSlide < this.selectedOrder.items.length - 1) {
      this.currentSlide++;
    }
  }

  prevSlide(): void {
    if (this.currentSlide > 0) {
      this.currentSlide--;
    }
  }

  goToSlide(index: number): void {
    this.currentSlide = index;
  }

  payOrder(order: ListOrdersForUserQueryDto) {
    this.ordersService.getPaymentIntent(order.id).subscribe({
      next: (data) => {
        this.router.navigate(['/client/payment'], {
          state: {
            orderData: {
              orderId: order.id,
              clientSecret: data.clientSecret,
              publishableKey: data.publishableKey,
              totalPrice: data.totalPrice,
            },
          },
        });
      },
      error: () => {
        this.toaster.error(this.translate.instant('CLIENT.USER_ORDERS.ERROR_PAY'));
      },
    });
  }

  goBack(): void {
    this.location.back();
  }
}
