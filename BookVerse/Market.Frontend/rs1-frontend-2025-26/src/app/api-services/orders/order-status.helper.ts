import { OrderStatusType } from './orders-api.models';

/**
 * Helper class for working with Order Status
 *
 * Provides human-readable labels and styling information
 * for order statuses throughout the application.
 */
export class OrderStatusHelper {
  /**
   * Get human-readable label for order status
   *
   * @param status - Order status enum value
   * @returns Translated label key or default label
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
      default:
        return 'ORDERS.STATUS.UNKNOWN';
    }
  }

  /**
   * Get color class for order status badge
   *
   * Use these classes with your badge/chip component
   *
   * @param status - Order status enum value
   * @returns CSS class name for status color
   */
  static getColorClass(status: OrderStatusType): string {
    switch (status) {
      case OrderStatusType.Draft:
        return 'status-draft'; // Gray
      case OrderStatusType.Packed:
        return 'status-packed'; // Blue
      case OrderStatusType.Paid:
        return 'status-paid'; // Green
      case OrderStatusType.Shipped:
        return 'status-shipped'; // Dark Green
      case OrderStatusType.Cancelled:
        return 'status-cancelled'; // Red
      default:
        return 'status-unknown'; // Gray
    }
  }

  /**
   * Get Material icon name for order status
   *
   * @param status - Order status enum value
   * @returns Material icon name
   */
  static getIcon(status: OrderStatusType): string {
    switch (status) {
      case OrderStatusType.Draft:
        return 'edit_note'; // Draft/note icon
      case OrderStatusType.Packed:
        return 'check_circle'; // Check circle
      case OrderStatusType.Paid:
        return 'payment'; // Payment icon
      case OrderStatusType.Shipped:
        return 'done_all'; // Double check
      case OrderStatusType.Cancelled:
        return 'cancel'; // Cancel X icon
      default:
        return 'help_outline'; // Question mark
    }
  }

  /**
   * Get all available statuses
   *
   * Useful for dropdowns/filters
   *
   * @returns Array of all order statuses
   */
  static getAllStatuses(): OrderStatusType[] {
    return [
      OrderStatusType.Draft,
      OrderStatusType.Packed,
      OrderStatusType.Paid,
      OrderStatusType.Shipped,
      OrderStatusType.Cancelled,
    ];
  }

  /**
   * Get status options for dropdown
   *
   * @returns Array of status options with label and value
   */
  static getStatusOptions(): Array<{ label: string; value: OrderStatusType; icon: string }> {
    return this.getAllStatuses().map((status) => ({
      label: this.getLabel(status),
      value: status,
      icon: this.getIcon(status),
    }));
  }

  /**
   * Check if status allows editing
   *
   * @param status - Order status enum value
   * @returns true if order can be edited
   */
  static canEdit(status: OrderStatusType): boolean {
    // Only Draft and Packed orders can be edited
    return status === OrderStatusType.Draft || status === OrderStatusType.Packed;
  }

  /**
   * Check if status allows cancellation
   *
   * @param status - Order status enum value
   * @returns true if order can be cancelled
   */
  static canCancel(status: OrderStatusType): boolean {
    // Can cancel Draft, Packed, and Paid orders
    // Cannot cancel Shipped or already Cancelled orders
    return (
      status === OrderStatusType.Draft ||
      status === OrderStatusType.Packed ||
      status === OrderStatusType.Paid
    );
  }

  /**
   * Get next possible status transitions
   *
   * @param currentStatus - Current order status
   * @returns Array of possible next statuses
   */
  static getNextStatuses(currentStatus: OrderStatusType): OrderStatusType[] {
    switch (currentStatus) {
      case OrderStatusType.Draft:
        return [OrderStatusType.Cancelled];
      case OrderStatusType.Paid:
        return [OrderStatusType.Packed, OrderStatusType.Cancelled];
      case OrderStatusType.Packed:
        return [OrderStatusType.Shipped, OrderStatusType.Cancelled];
      case OrderStatusType.Shipped:
        return [];
      case OrderStatusType.Cancelled:
        return [];
      default:
        return [];
    }
  }
}
