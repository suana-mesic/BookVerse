import { Component, inject, OnInit } from '@angular/core';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';
import { ToasterService } from '../../core/services/toaster.service';
import {
  ListOrdersForUserQueryDto,
  ListOrdersForUserRequest,
  OrderStatusType,
} from '../../../api-services/orders/orders-api.models';
import { BaseListPagedComponent } from '../../core/components/base-classes/base-list-paged-component';
import { debounceTime, distinctUntilChanged, Subject, takeUntil } from 'rxjs';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
import { Location } from '@angular/common';
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
  private toaster = inject(ToasterService);
  private destroy$ = new Subject<void>();
  private router = inject(Router);
  private dialogHelper = inject(DialogHelperService);
  private location = inject(Location);

  searchControl = new FormControl('');
  statusFilter: OrderStatusType | null = null;
  OrderStatusType = OrderStatusType;
  selectedOrder: ListOrdersForUserQueryDto | null = null;
  currentSlide = 0;

  cancellableStatuses = [OrderStatusType.Draft, OrderStatusType.Paid, OrderStatusType.Packed];

  constructor() {
    super();
    this.request = new ListOrdersForUserRequest();
    this.request.paging.page = 1;
    this.request.paging.pageSize = 10;
  }

  ngOnInit(): void {
    this.initList();
    this.setupSearchDebounce();
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
        this.stopLoading('Greška pri učitavanju narudžbi.');
      },
    });
  }

  onStatusFilterChange(status: OrderStatusType | null): void {
    this.statusFilter = status;
    this.request.status = status;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  clearFilters(): void {
    this.searchControl.setValue('', { emitEvent: false });
    this.statusFilter = null;
    this.request.search = null;
    this.request.status = null;
    this.request.paging.page = 1;
    this.loadPagedData();
  }

  cancelOrder(id: number): void {
    this.dialogHelper
      .confirm('Otkazivanje narudžbe', 'Da li ste sigurni da želite otkazati narudžbu?')
      .subscribe((response) => {
        if (response?.button == DialogButton.YES) {
          this.ordersService.cancelOrder(id).subscribe({
            next: () => {
              this.toaster.success('Narudžba uspješno otkazana.');
              this.loadPagedData();
            },
            error: () => {
              this.toaster.error('Greška pri otkazivanju narudžbe.');
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
      [OrderStatusType.Draft]: 'Bilješka',
      [OrderStatusType.Paid]: 'Plaćeno',
      [OrderStatusType.Packed]: 'Zapakovano',
      [OrderStatusType.Shipped]: 'Poslano',
      [OrderStatusType.Cancelled]: 'Otkazano',
    };
    return labels[status] ?? 'Nepoznato';
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
    this.currentSlide = 0; // reset na prvu knjgu
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
        this.toaster.error('Greška pri dohvatanju podataka za plaćanje.');
      },
    });
  }

  goBack(): void {
    this.location.back();
  }
}
