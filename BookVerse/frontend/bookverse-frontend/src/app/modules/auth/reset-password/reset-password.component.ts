import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { AuthApiService } from '../../../api-services/auth/auth-api.service';
import { getBusinessRuleMessage } from '../../../core/services/business-rule-error.helper';
import { applyFieldErrorsToForm, clearServerErrors, extractFieldErrors } from '../../../core/services/field-errors.helper';

@Component({
  selector: 'app-reset-password',
  standalone: false,
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.scss',
})
export class ResetPasswordComponent extends BaseComponent implements OnInit {
  private fb = inject(FormBuilder);
  private authApi = inject(AuthApiService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private translate = inject(TranslateService);

  passwordReset = false;
  // Banner message shown above the form. Null = no banner. Holds the localized text directly
  // (business-rule code or generic fallback) so the template can render it as-is.
  resetErrorMessage: string | null = null;

  private token = '';
  private email = '';

  resetForm = this.fb.group(
    {
      newPassword: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]],
    },
    { validators: this.passwordMatchValidator },
  );

  public passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const newPassword = control.get('newPassword')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;
    return newPassword === confirmPassword ? null : { passwordMismatch: true };
  }

  ngOnInit(): void {
    this.token = this.route.snapshot.queryParamMap.get('token') ?? '';
    this.email = this.route.snapshot.queryParamMap.get('email') ?? '';

    if (!this.token || !this.email) {
      this.router.navigate(['/auth/forgot-password']);
    }
  }

  onSubmit(): void {
    if (this.resetForm.invalid || this.isLoading) return;

    this.startLoading();
    // Clear any banner and per-field server errors left over from the previous attempt.
    this.resetErrorMessage = null;
    clearServerErrors(this.resetForm);

    this.authApi
      .resetPassword({
        email: this.email,
        token: this.token,
        newPassword: this.resetForm.value.newPassword ?? '',
      })
      .subscribe({
        next: () => {
          this.stopLoading();
          this.passwordReset = true;
        },
        error: (err) => {
          this.stopLoading();

          // Business-rule code (if any) takes priority - shows a single localized banner.
          const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
          if (businessRuleMsg) {
            this.resetErrorMessage = businessRuleMsg;
            return;
          }

          // Backend per-field validation errors (e.g. password too short) get painted onto
          // the matching controls so the user sees the message inline under the input.
          const fieldErrors = extractFieldErrors(err);
          if (applyFieldErrorsToForm(this.resetForm, fieldErrors)) return;

          this.resetErrorMessage = this.translate.instant('AUTH.RESET_PASSWORD.ERROR');
        },
      });
  }

  // Mirrors the helper used by login/register/forgot-password so the template can render
  // backend per-field messages inside <mat-error> without converting on every form.
  serverError(controlName: string): string | null {
    return (this.resetForm.get(controlName)?.errors?.['serverError'] as string) ?? null;
  }
}
