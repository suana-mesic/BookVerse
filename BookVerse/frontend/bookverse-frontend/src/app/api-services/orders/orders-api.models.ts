import { PageResult } from '../../core/models/paging/page-result';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';

// === ENUMS ===

/**
 * Order status enum
 * Corresponds to: OrderStatusType.cs (backend)
 *
 * Frontend MUST mirror backend exactly. Missing values cause filter dropdowns and
 * status helpers to fall through to "Unknown", and orders coming back from the
 * webhook (PaymentPending, PaymentFailed) would otherwise look broken in the UI.
 */
export enum OrderStatusType {
  /** Order row saved but Stripe PaymentIntent not yet created */
  Draft = 1,
  /** Staff has packed the order, ready for shipping */
  Packed = 2,
  /** Payment received and order is being processed */
  Paid = 3,
  /** Order has been shipped or delivered */
  Shipped = 4,
  /** Customer (or staff) cancelled the order; Stripe refund issued if it was paid */
  Cancelled = 5,
  /** PaymentIntent created, user is in checkout flow waiting to pay */
  PaymentPending = 6,
  /** Stripe webhook reported payment_intent.payment_failed; order is dead */
  PaymentFailed = 7,
  /** Background cleanup expired the order after sitting too long in Draft/PaymentPending */
  Expired = 8,
}

// === QUERIES (READ) ===

/**
 * Query parameters for GET /api/orders (admin list)
 * Corresponds to: ListOrderOrderItemsQuery.cs
 */
export class ListOrdersRequest extends BasePagedQuery {
  search?: string | null;
  status?: number | null;
  constructor() {
    super();
  }
}

/**
 * User info in list response
 */
export interface ListOrdersQueryDtoUser {
  firstName: string | null;
  lastName: string | null;
  userAddress: string | null;
  userCity: string | null;
}

/**
 * Response item for GET /api/orders
 * Corresponds to: ListOrderOrderItemsQueryDto.cs
 */
export interface ListOrdersQueryDto {
  orderId: number;
  trackingNumber: string | null;
  userInfo: ListOrdersQueryDtoUser;
  orderDate: string; // ISO date string
  statusNameEnum: OrderStatusType;
  total: number;
}

/**
 * Paged response for GET /api/orders
 */
export type ListOrdersResponse = PageResult<ListOrdersQueryDto>;

// === COMMANDS (WRITE) ===

export interface CreateOrderWithItemsQuery {
  shippingMethodId: number | null;
  storeId: number | null;
  useExistingAddress: boolean;
  line1: string | null;
  line2: string | null;
  city: string | null;
  country: string | null;
  couponIds: number[];
}

export interface CreateOrderWithItemsQueryDto {
  orderId: number;
  clientSecret: string;
  publishableKey: string;
  totalPrice: number;
}
export interface GetOrderByIdQueryDto {
  id: number;
  trackingNumber: string | null;
  user: GetByIdOrderQueryDtoUser;
  shipToAddress: GetByIdOrderQueryDtoShipToAddress;
  orderedAtUtc: string;
  paidAtUtc: string | null;
  status: OrderStatusType;
  totalAmount: number;
  subtotal: number;
  shippingPriceAtTheTime: number;
  discountAmount: number | null;
  items: GetByIdOrderQueryDtoItem[];
}

export interface GetByIdOrderQueryDtoUser {
  userFirstname: string | null;
  userLastname: string | null;
}

export interface GetByIdOrderQueryDtoShipToAddress {
  line1: string;
  line2: string | null;
  city: string;
  country: string;
}

export interface GetByIdOrderQueryDtoItem {
  book: GetByIdOrderQueryDtoItemBook;
  quantity: number;
  unitPrice: number;
}

export interface GetByIdOrderQueryDtoItemBook {
  bookId: number;
  title: string;
}
export interface ListOrdersForUserQueryDto {
  id: number;
  trackingNumber: string;
  orderedAtUtc: string;
  paidAtUtc: string | null;
  status: OrderStatusType;
  totalAmount: number;
  subtotal: number;
  shippingPriceAtTheTime: number;
  discountAmount: number | null;
  items: ListOrdersForUserQueryDtoItem[];
}

export interface ListOrdersForUserQueryDtoItem {
  book: ListOrdersForUserQueryDtoItemBook;
  quantity: number;
  unitPrice: number;
}

export interface ListOrdersForUserQueryDtoItemBook {
  bookId: number;
  title: string;
  imageUrl: string | null;
}

export class ListOrdersForUserRequest extends BasePagedQuery {
  search?: string | null;
  status?: OrderStatusType | null;
  language?: string | null;
  constructor() {
    super();
  }
}
