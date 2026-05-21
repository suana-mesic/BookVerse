namespace BookVerse.Application.Common.Exceptions;

// Stable, frontend-facing identifiers for every BookVerseBusinessRuleException thrown by the
// backend. The frontend uses these strings as i18n keys (see ERRORS.BUSINESS_RULES.* in
// en.json / bs.json) so we can show a localized message without parsing the English text.
//
// Why constants and not random strings:
//   - Replaces the old magic codes "123", "323", "556" that meant nothing to anyone.
//   - One place to look when adding a new error: pick a SCREAMING_SNAKE_CASE name that
//     describes the rule, throw with it, and add the matching i18n entry.
//   - Compile-time check: if you mistype the code in a handler the build fails. With raw
//     strings a typo would silently slip through.
public static class BusinessRuleCodes
{
    // Order cancellation: the order is in a status (Shipped, Cancelled, Expired, PaymentFailed)
    // that does not allow cancellation.
    public const string ORDER_NOT_CANCELLABLE = "ORDER_NOT_CANCELLABLE";

    // Order status change: the order's current status is not in our known set.
    // Indicates a bug or out-of-sync enum; surfaced so QA can spot it.
    public const string ORDER_STATUS_UNKNOWN = "ORDER_STATUS_UNKNOWN";

    // Order status change: the requested transition is not allowed from the current status
    // (e.g. Paid -> Draft, or Shipped -> anything).
    public const string ORDER_STATUS_TRANSITION_INVALID = "ORDER_STATUS_TRANSITION_INVALID";

    // EnsurePaymentIntent retry: the order is not in PaymentPending, so retrying payment
    // makes no sense (Draft never reached Stripe, Paid is done, Cancelled/Expired/Failed are terminal).
    public const string ORDER_NOT_PAYABLE = "ORDER_NOT_PAYABLE";

    // Inventory create: the referenced Book or Store does not exist (or is soft-deleted).
    public const string INVENTORY_BOOK_OR_STORE_INVALID = "INVENTORY_BOOK_OR_STORE_INVALID";

    // Inventory create: a row for this Book + Store pair already exists, so a second insert
    // would violate the unique key.
    public const string INVENTORY_DUPLICATE = "INVENTORY_DUPLICATE";

    // Generic auth guard used by handlers that need a user but cannot recover one.
    // (Most auth issues use BookVerseUnauthorizedException; this exists for the few places
    // that historically used BookVerseBusinessRuleException for the same check.)
    public const string USER_NOT_AUTHENTICATED = "USER_NOT_AUTHENTICATED";

    // Coupon create: AmountOff and PercentOff cannot both be set on the same coupon.
    public const string COUPON_MULTIPLE_DISCOUNT_TYPES = "COUPON_MULTIPLE_DISCOUNT_TYPES";

    // Captcha verification failed - token was tampered with, expired, or the user typed
    // the wrong characters. Login/Register/ForgotPassword forms use this code to show a
    // single localized "Wrong CAPTCHA, try again" message instead of a generic error.
    public const string CAPTCHA_INVALID = "CAPTCHA_INVALID";

    // The current customer has already redeemed this coupon MaxUses times across their
    // own (non-cancelled) orders. Frontend shows a localized "you've reached your
    // personal limit" message inline under the coupon input.
    public const string COUPON_MAX_USES_REACHED = "COUPON_MAX_USES_REACHED";
}
