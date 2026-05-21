import { Component, ViewChild, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { AuthApiService } from '../../../api-services/auth/auth-api.service';
import { CaptchaInputComponent } from '../../shared/components/captcha-input/captcha-input.component';
import { getBusinessRuleMessage } from '../../../core/services/business-rule-error.helper';
import { applyFieldErrorsToForm, clearServerErrors, extractFieldErrors } from '../../../core/services/field-errors.helper';

@Component({
  selector: 'app-forgot-password',
  standalone: false,
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss',
})
export class ForgotPasswordComponent extends BaseComponent {
  private fb = inject(FormBuilder);
  private authApi = inject(AuthApiService);
  private translate = inject(TranslateService);

  emailSent = false;

  // Banner shown at the top of the form. Holds the localized message directly so
  // different errors (CAPTCHA_INVALID, network error, etc.) can use the same banner
  // with their own text. Null = banner hidden.
  forgotErrorMessage: string | null = null;

  // Reference to the captcha widget shown above the submit button.
  @ViewChild('captcha') captcha?: CaptchaInputComponent;

  forgotForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
  });

  onSubmit(): void {
    // Require both the email AND a 5-character captcha answer before sending the request.
    if (this.forgotForm.invalid || !this.captcha?.isValid || this.isLoading) return;

    this.startLoading();
    // Clear any banner and per-field server errors left over from the previous attempt.
    this.forgotErrorMessage = null;
    clearServerErrors(this.forgotForm);

    // Read the (token, answer) pair from the shared captcha widget. The backend re-verifies
    // them in ForgotPasswordCommandHandler before doing the email lookup.
    const captchaValue = this.captcha.getValue();

    this.authApi
      .forgotPassword({
        email: this.forgotForm.value.email ?? '',
        captchaToken: captchaValue.token,
        captchaAnswer: captchaValue.answer,
      })
      .subscribe({
        next: () => {
          this.stopLoading();
          this.emailSent = true;
        },
        error: (err) => {
          this.stopLoading();
          // Refresh the captcha so the user can try again with a new challenge.
          this.captcha?.refresh();

          // CAPTCHA_INVALID (and any other business-rule code) shows up in the red
          // banner at the top of the form with its OWN localized message.
          const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
          if (businessRuleMsg) {
            this.forgotErrorMessage = businessRuleMsg;
            return;
          }

          // Per-field validation errors (e.g. invalid email format) get painted onto the
          // matching controls so the user sees the backend message inline under the input.
          const fieldErrors = extractFieldErrors(err);
          if (applyFieldErrorsToForm(this.forgotForm, fieldErrors)) return;

          this.forgotErrorMessage = this.translate.instant('AUTH.FORGOT_PASSWORD.ERROR');
        },
      });
  }

  // Mirrors the helper used by login/register so the template can render backend per-field
  // messages inside <mat-error> via [innerText] without converting on every form.
  serverError(controlName: string): string | null {
    return (this.forgotForm.get(controlName)?.errors?.['serverError'] as string) ?? null;
  }
}
