import { TranslateService } from '@ngx-translate/core';

/**
 * Maps known backend error messages (English strings thrown via BookVerseConflictException
 * or BookVerseNotFoundException) to localized i18n keys under ERRORS.BACKEND_MESSAGES.*.
 *
 * The backend wraps these errors with the generic "entity.error" code, so getBusinessRuleMessage
 * cannot translate them. This helper inspects the raw message and returns the matching localized
 * string, or null when the message is unknown so the caller can fall back to a generic toast.
 *
 * Patterns are intentionally tied to the exact English wording the backend throws. If a backend
 * message ever changes, add a new entry here rather than mutating an old one so we never silently
 * drop a translation for an in-flight client.
 */
const ERROR_MESSAGE_PATTERNS: ReadonlyArray<{ pattern: RegExp; key: string }> = [
  { pattern: /^cart not found\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_CART_NOT_FOUND' },
  { pattern: /^cart is empty\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_CART_EMPTY' },
  { pattern: /^shipping method not found\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_SHIPPING_NOT_FOUND' },
  { pattern: /^store not found\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_STORE_NOT_FOUND' },
  { pattern: /^choose either shipping method or pickup store, not both\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_DELIVERY_BOTH' },
  { pattern: /^you must select a delivery method or a pickup store\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_DELIVERY_NEITHER' },
  { pattern: /^order not found\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_NOT_FOUND' },
  { pattern: /^paymentintentid was not found for this order\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_PAYMENT_INTENT_MISSING' },
  { pattern: /^charge was not found for this paymentintent\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_CHARGE_MISSING' },
  { pattern: /^stripe refund failed/i, key: 'ERRORS.BACKEND_MESSAGES.ORDER_STRIPE_REFUND_FAILED' },
  { pattern: /^book does not exist\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.CART_BOOK_NOT_FOUND' },
  { pattern: /^book is not available for purchase\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.CART_BOOK_UNAVAILABLE' },
  { pattern: /^requested quantity is not available in stock\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.CART_OUT_OF_STOCK' },
  { pattern: /^user is not logged in\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.USER_NOT_LOGGED_IN' },
  { pattern: /^user not found\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.USER_NOT_FOUND' },
  { pattern: /^at most \d+ coupons can be applied per order\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.COUPON_MAX_PER_ORDER' },
  { pattern: /^the same coupon cannot be applied more than once\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.COUPON_DUPLICATE' },
  { pattern: /^one or more coupons do not exist\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.COUPON_NOT_EXIST' },
  { pattern: /^one or more coupons are expired or not yet active\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.COUPON_EXPIRED' },
  { pattern: /requires a minimum order amount/i, key: 'ERRORS.BACKEND_MESSAGES.COUPON_MIN_ORDER_AMOUNT' },
  { pattern: /^combined coupon discount exceeds the order subtotal\.?$/i, key: 'ERRORS.BACKEND_MESSAGES.COUPON_DISCOUNT_EXCEEDS' },
];

/**
 * Returns the localized message for a backend-thrown error, or null if the error's message
 * does not match any known pattern (in which case the caller should fall back to its own
 * generic toast).
 */
export function getBackendErrorMessage(
  error: unknown,
  translate: TranslateService,
): string | null {
  const message = (error as { error?: { message?: string } } | null)?.error?.message;
  if (!message || typeof message !== 'string') return null;

  for (const { pattern, key } of ERROR_MESSAGE_PATTERNS) {
    if (!pattern.test(message)) continue;

    const translated = translate.instant(key);
    // ngx-translate returns the key itself when a translation is missing; in that case we
    // fall back to null so the caller can show its own generic message instead of the raw key.
    return translated === key ? null : translated;
  }

  return null;
}
