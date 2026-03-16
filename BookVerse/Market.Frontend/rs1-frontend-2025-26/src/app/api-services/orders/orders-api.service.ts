import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  ListOrdersRequest,
  ListOrdersResponse,
  ListOrdersWithItemsRequest,
  ListOrdersWithItemsResponse,
  GetOrderByIdQueryDto,
  CreateOrderCommand,
  UpdateOrderCommand,
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
  private readonly baseUrl = `${environment.apiUrl}/OrdersOrderItems`;
  private http = inject(HttpClient);

  /**
   * GET /Orders
   * List orders with optional query parameters.
   * Returns basic order info without items.
   */
  list(request?: ListOrdersRequest): Observable<ListOrdersResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListOrdersResponse>(this.baseUrl, {
      params,
    });
  }

  /**
   * GET /Orders/with-items
   * List orders with items included.
   * Use this when you need to display order items in the list.
   */
  listWithItems(request?: ListOrdersWithItemsRequest): Observable<ListOrdersWithItemsResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListOrdersWithItemsResponse>(`${this.baseUrl}/with-items`, {
      params,
    });
  }

  /**
   * GET /Orders/{id}
   * Get a single order by ID with full details including items.
   */
  getById(id: number): Observable<GetOrderByIdQueryDto> {
    return this.http.get<GetOrderByIdQueryDto>(`${this.baseUrl}/${id}`);
  }

  /**
   * POST /Orders
   * Create a new order.
   * @returns ID of the newly created order
   */
  create(payload: CreateOrderCommand): Observable<number> {
    return this.http.post<number>(this.baseUrl, payload);
  }

  /**
   * PUT /Orders/{id}
   * Update an existing order.
   * Can update order note and items.
   */
  update(id: number, payload: UpdateOrderCommand): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, payload);
  }

  /**
   * PUT /Orders/{id}/change-status
   * Change order status.
   * Validates status transitions on backend.
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

  // Poziva se kada je narudžba već u statusu Draft i kada korisnik želi da je plati
  // iz modula za pregled svih narudžbi (user-orders.component.ts)
  // ovaj endpoint vraća: PublishableKey, ClientSecret i TotalPrice i to je potrebno kako bi se
  // otvorila Stripe forma
  getPaymentIntent(orderId: number): Observable<{
    clientSecret: string;
    publishableKey: string;
    totalPrice: number;
  }> {
    return this.http.get<any>(`${this.baseUrl}/${orderId}/payment-intent`);
  }
}
