import { TranslateService } from '@ngx-translate/core';

/**
 * Stable set of business-rule error codes the backend can return inside ErrorDto.code.
 * Each value matches a constant on the backend in BusinessRuleCodes.cs and an i18n key
 * under ERRORS.BUSINESS_RULES.* in en.json / bs.json. Listing them here means:
 *   - components get autocomplete and a typo causes a TypeScript error
 *   - we can iterate all known codes in one place when looking up the translation
 */
export const BUSINESS_RULE_CODES = [
  'ORDER_NOT_CANCELLABLE',
  'ORDER_STATUS_UNKNOWN',
  'ORDER_STATUS_TRANSITION_INVALID',
  'ORDER_NOT_PAYABLE',
  'INVENTORY_BOOK_OR_STORE_INVALID',
  'INVENTORY_DUPLICATE',
  'USER_NOT_AUTHENTICATED',
  'COUPON_MULTIPLE_DISCOUNT_TYPES',
  'CAPTCHA_INVALID',
  'COUPON_MAX_USES_REACHED',
] as const;

export type BusinessRuleCode = (typeof BUSINESS_RULE_CODES)[number];

/**
 * Returns the localized message for a business-rule HTTP error, or null if the error
 * is not a known business-rule failure (in which case the caller should fall back to
 * its own generic message).
 *
 * The backend sends a payload like { code: "ORDER_NOT_CANCELLABLE", message: "..." }
 * and we use the code as an i18n key. The English message from the backend stays as
 * the last-resort fallback so we never show "undefined" to the user even if a new
 * code is added on the server before the frontend translation lands.
 */
export function getBusinessRuleMessage(
  error: unknown,
  translate: TranslateService,
): string | null {
  const code = (error as { error?: { code?: string } } | null)?.error?.code;
  if (!code) return null;

  // Only translate codes we know about - everything else (validation.error, auth.error,
  // entity.error) is handled by the existing generic flow.
  if (!(BUSINESS_RULE_CODES as readonly string[]).includes(code)) return null;

  const key = `ERRORS.BUSINESS_RULES.${code}`;
  const translated = translate.instant(key);

  // ngx-translate returns the key itself when the translation is missing. Detect that
  // and fall back to the English message the backend sent, so we never show the raw key.
  if (translated === key) {
    return (error as { error?: { message?: string } } | null)?.error?.message ?? null;
  }

  return translated;
}
