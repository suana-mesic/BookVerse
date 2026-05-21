import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  ListOrdersRequest,
  ListOrdersResponse,
  GetOrderByIdQueryDto,
  OrderStatusType,
  CreateOrderWithItemsQuery,
  CreateOrderWithItemsQueryDto,
  ListOrdersForUserRequest,
  ListOrdersForUserQueryDto,
} from './orders-api.models';
import { buildHttpParams } from '../../core/models/build-http-params';
import { PageResult } from '../../core/models/paging/page-result';

@Injectable({
  providedIn: 'root',
})
export class OrdersApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/orders`;
  private http = inject(HttpClient);

  /**
   * GET /api/orders
   * List orders for the admin table. Returns basic order info without items.
   */
  list(request?: ListOrdersRequest): Observable<ListOrdersResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListOrdersResponse>(this.baseUrl, {
      params,
    });
  }

  /**
   * GET /api/orders/{id}
   * Get a single order by ID with full details including items.
   */
  getById(id: number): Observable<GetOrderByIdQueryDto> {
    return this.http.get<GetOrderByIdQueryDto>(`${this.baseUrl}/${id}`);
  }

  /**
   * PUT /api/orders/{id}/change-status
   * Change order status. Validates status transitions on backend.
   */
  changeStatus(id: number, newStatus: OrderStatusType): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}/change-status`, {
      newStatus: newStatus,
    });
  }

  createOrder(request: CreateOrderWithItemsQuery): Observable<CreateOrderWithItemsQueryDto> {
    return this.http.post<CreateOrderWithItemsQueryDto>(this.baseUrl, request);
  }

  listForUser(
    request?: ListOrdersForUserRequest,
  ): Observable<PageResult<ListOrdersForUserQueryDto>> {
    const params = request ? buildHttpParams(request as any) : undefined;
    return this.http.get<PageResult<ListOrdersForUserQueryDto>>(`${this.baseUrl}/my-orders`, {
      params,
    });
  }

  cancelOrder(id: number): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/${id}/cancel`, {});
  }

  // Called when the order is already in Draft status and the user wants to pay for it
  // from the user orders module (user-orders.component.ts)
  // this endpoint returns: PublishableKey, ClientSecret and TotalPrice, which are required
  // to open the Stripe payment form
  getPaymentIntent(orderId: number): Observable<{
    clientSecret: string;
    publishableKey: string;
    totalPrice: number;
  }> {
    // POST because the backend may create a new Stripe PaymentIntent and update the order with its id.
    // No body is needed - the order id is in the URL.
    return this.http.post<any>(`${this.baseUrl}/${orderId}/payment-intent`, {});
  }
}
