import { Component, inject, Inject, OnDestroy } from '@angular/core';
import {
  GetOrderByIdQueryDto,
  OrderStatusType,
} from '../../../../api-services/orders/orders-api.models';
import { OrderStatusHelper } from '../../../../api-services/orders/order-status.helper';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrdersApiService } from '../../../../api-services/orders/orders-api.service';
import { CountriesApiService } from '../../../../api-services/rest-countries/countires-api.service';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';

export interface OrderDetailsDialogData {
  orderId: number;
}

@Component({
  selector: 'app-admin-orders-details-dialog',
  standalone: false,
  templateUrl: './order-details-dialog.component.html',
  styleUrl: './order-details-dialog.component.scss',
})
export class OrderDetailsDialogComponent implements OnDestroy {
  private ordersApi = inject(OrdersApiService);
  private dialogRef = inject(MatDialogRef<OrderDetailsDialogComponent>);
  private countriesService = inject(CountriesApiService);
  private translate = inject(TranslateService);

  order?: GetOrderByIdQueryDto;
  isLoading = false;
  errorMessage: string | null = null;
  countries: { name: string; countryCode: string; nameBs: string }[] = [];
  private langChangeSub?: Subscription;

  constructor(@Inject(MAT_DIALOG_DATA) public data: OrderDetailsDialogData) {}

  ngOnInit(): void {
    this.loadOrderDetails();
    this.loadCountries();
    this.langChangeSub = this.translate.onLangChange.subscribe(() => this.loadCountries());
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
  }

  private loadCountries(): void {
    this.countriesService.getCountries().subscribe({
      next: (countries) => (this.countries = countries),
    });
  }

  private loadOrderDetails(): void {
    this.isLoading = true;
    this.errorMessage = null;

    this.ordersApi.getById(this.data.orderId).subscribe({
      next: (order) => {
        this.order = order;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Failed to load order details';
        this.isLoading = false;
        console.error('Load order details error:', err);
      },
    });
  }

  get orderedAtLocal(): Date {
    return new Date(this.order!.orderedAtUtc);
  }

  get paidAtLocal(): Date | null {
    return this.order?.paidAtUtc ? new Date(this.order.paidAtUtc) : null;
  }
  // === Status Helpers ===

  getStatusLabel(status: OrderStatusType): string {
    return OrderStatusHelper.getLabel(status);
  }

  getStatusIcon(status: OrderStatusType): string {
    return OrderStatusHelper.getIcon(status);
  }

  getStatusClass(status: OrderStatusType): string {
    return OrderStatusHelper.getColorClass(status);
  }

  // === Display Helpers ===

  getCustomerName(): string {
    if (!this.order) return '';
    return `${this.order.user.userFirstname} ${this.order.user.userLastname}`;
  }

  getShipToAddress(): { line1: string; line2: string | null; city: string; country: string } | null {
    if (!this.order?.shipToAddress) return null;
    return this.order.shipToAddress;
  }

  getDisplayCountry(savedCountry: string | null | undefined): string {
    if (!savedCountry) return '';
    const match = this.countries.find((c) => c.nameBs === savedCountry);
    return match?.name ?? savedCountry;
  }

  // === Actions ===

  onClose(): void {
    this.dialogRef.close(false);
  }

  retry(): void {
    this.loadOrderDetails();
  }
}
