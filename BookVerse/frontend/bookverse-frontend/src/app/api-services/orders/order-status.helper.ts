import { OrderStatusType } from './orders-api.models';

/**
 * Helper class for working with Order Status.
 *
 * Covers all 8 backend statuses (Draft, Packed, Paid, Shipped, Cancelled,
 * PaymentPending, PaymentFailed, Expired). Labels point to i18n keys under
 * ORDERS.STATUS.*, so the UI is automatically localized.
 */
export class OrderStatusHelper {
  /**
   * Returns the i18n key for a status label.
   */
  static getLabel(status: OrderStatusType): string {
    switch (status) {
      case OrderStatusType.Draft:
        return 'ORDERS.STATUS.DRAFT';
      case OrderStatusType.Packed:
        return 'ORDERS.STATUS.PACKED';
      case OrderStatusType.Paid:
        return 'ORDERS.STATUS.PAID';
      case OrderStatusType.Shipped:
        return 'ORDERS.STATUS.SHIPPED';
      case OrderStatusType.Cancelled:
        return 'ORDERS.STATUS.CANCELLED';
      case OrderStatusType.PaymentPending:
        return 'ORDERS.STATUS.PAYMENT_PENDING';
      case OrderStatusType.PaymentFailed:
        return 'ORDERS.STATUS.PAYMENT_FAILED';
      case OrderStatusType.Expired:
        return 'ORDERS.STATUS.EXPIRED';
      default:
        return 'ORDERS.STATUS.UNKNOWN';
    }
  }

  /**
   * CSS class used by the status badge in tables, dialogs and timelines.
   */
  static getColorClass(status: OrderStatusType): string {
    switch (status) {
      case OrderStatusType.Draft:
        return 'status-draft';
      case OrderStatusType.Packed:
        return 'status-packed';
      case OrderStatusType.Paid:
        return 'status-paid';
      case OrderStatusType.Shipped:
        return 'status-shipped';
      case OrderStatusType.Cancelled:
        return 'status-cancelled';
      case OrderStatusType.PaymentPending:
        return 'status-payment-pending';
      case OrderStatusType.PaymentFailed:
        return 'status-payment-failed';
      case OrderStatusType.Expired:
        return 'status-expired';
      default:
        return 'status-unknown';
    }
  }

  /**
   * Material icon for the status badge.
   */
  static getIcon(status: OrderStatusType): string {
    switch (status) {
      case OrderStatusType.Draft:
        return 'edit_note';
      case OrderStatusType.Packed:
        return 'check_circle';
      case OrderStatusType.Paid:
        return 'payment';
      case OrderStatusType.Shipped:
        return 'done_all';
      case OrderStatusType.Cancelled:
        return 'cancel';
      case OrderStatusType.PaymentPending:
        return 'hourglass_top';
      case OrderStatusType.PaymentFailed:
        return 'error_outline';
      case OrderStatusType.Expired:
        return 'schedule';
      default:
        return 'help_outline';
    }
  }

  /**
   * All statuses, in display order. Used to build filter dropdowns.
   */
  static getAllStatuses(): OrderStatusType[] {
    return [
      OrderStatusType.Draft,
      OrderStatusType.PaymentPending,
      OrderStatusType.Paid,
      OrderStatusType.Packed,
      OrderStatusType.Shipped,
      OrderStatusType.Cancelled,
      OrderStatusType.PaymentFailed,
      OrderStatusType.Expired,
    ];
  }

  /**
   * Filter dropdown options (label + icon + enum value).
   */
  static getStatusOptions(): Array<{ label: string; value: OrderStatusType; icon: string }> {
    return this.getAllStatuses().map((status) => ({
      label: this.getLabel(status),
      value: status,
      icon: this.getIcon(status),
    }));
  }

  static canEdit(status: OrderStatusType): boolean {
    return status === OrderStatusType.Draft || status === OrderStatusType.Packed;
  }

  /**
   * Customer-cancellable statuses. Mirrors CancelOrderCommandHandler on the backend:
   * Draft / PaymentPending: cancelled before payment lands.
   * Paid / Packed: refund + inventory restore happens on the backend side.
   * Shipped / Cancelled / PaymentFailed / Expired are terminal.
   */
  static canCancel(status: OrderStatusType): boolean {
    return (
      status === OrderStatusType.Draft ||
      status === OrderStatusType.PaymentPending ||
      status === OrderStatusType.Paid ||
      status === OrderStatusType.Packed
    );
  }

  /**
   * Staff workflow transitions, matching ChangeOrderStatusCommandHandler.
   * Cancelled is intentionally NOT listed - that path runs through CancelOrderCommandHandler
   * (refund + inventory restore), not through change-status. Draft / PaymentPending are
   * managed by the Stripe webhook and the cleanup background service, so staff has no outlet
   * there.
   */
  static getNextStatuses(currentStatus: OrderStatusType): OrderStatusType[] {
    switch (currentStatus) {
      case OrderStatusType.Paid:
        return [OrderStatusType.Packed];
      case OrderStatusType.Packed:
        return [OrderStatusType.Shipped];
      default:
        return [];
    }
  }
}
