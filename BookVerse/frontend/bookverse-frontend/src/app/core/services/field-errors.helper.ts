import { AbstractControl, FormGroup } from '@angular/forms';

/**
 * One field-level validation error returned by the backend (matches FieldErrorDto in
 * BookVerse.Shared.Dtos). Field names come back camelCased so we can look up the
 * matching Angular form control directly without converting on every form.
 */
export interface FieldErrorDto {
  field: string;
  message: string;
  errorCode?: string;
}

/**
 * Shape of the HTTP error returned by BookVerseExceptionHandler for ValidationException.
 * Only the parts we read are typed; the rest of ErrorDto is ignored.
 */
interface ValidationErrorPayload {
  code?: string;
  fieldErrors?: FieldErrorDto[];
}

/**
 * Pulls FieldErrors out of an HttpErrorResponse, or null if the error is not a
 * validation error (so the caller falls back to its own generic message).
 */
export function extractFieldErrors(error: unknown): FieldErrorDto[] | null {
  const body = (error as { error?: ValidationErrorPayload } | null)?.error;
  if (!body || body.code !== 'validation.error') return null;
  return body.fieldErrors ?? null;
}

/**
 * Marks every field listed in `fieldErrors` as invalid on the given form, attaching the
 * server message under a `serverError` validator key. Templates can read it via
 * `form.get('email')?.errors?.['serverError']` to render the inline message.
 *
 * Returns true when at least one error was applied — useful for telling the caller
 * "I handled this, you don't need to show a generic toast".
 */
export function applyFieldErrorsToForm(
  form: FormGroup,
  fieldErrors: FieldErrorDto[] | null,
): boolean {
  if (!fieldErrors || fieldErrors.length === 0) return false;

  let applied = false;
  for (const fe of fieldErrors) {
    const control: AbstractControl | null = form.get(fe.field);
    if (!control) continue;

    // Preserve any client-side validation errors that might also be present.
    const existing = control.errors ?? {};
    control.setErrors({ ...existing, serverError: fe.message });
    // markAsTouched so the matInput shows the error immediately, not only after blur.
    control.markAsTouched();
    applied = true;
  }
  return applied;
}

/**
 * Clears any previously-applied `serverError` from every control in the form. Call this
 * before re-submitting so stale server messages from a previous attempt don't stick.
 */
export function clearServerErrors(form: FormGroup): void {
  for (const name of Object.keys(form.controls)) {
    const control = form.controls[name];
    const errors = control.errors;
    if (!errors || !('serverError' in errors)) continue;

    const { serverError: _ignored, ...rest } = errors;
    control.setErrors(Object.keys(rest).length === 0 ? null : rest);
  }
}
