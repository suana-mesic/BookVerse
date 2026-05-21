import { Component, ViewChild, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { Router } from '@angular/router';
import { CurrentUserService } from '../../../core/services/auth/current-user.service';
import {
  LoginCommand,
  LoginCommandDto,
  VerifyTwoFactorCommand,
} from '../../../api-services/auth/auth-api.model';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { TranslateService } from '@ngx-translate/core';
import { CaptchaInputComponent } from '../../shared/components/captcha-input/captcha-input.component';
import {
  applyFieldErrorsToForm,
  clearServerErrors,
  extractFieldErrors,
} from '../../../core/services/field-errors.helper';
import { getBusinessRuleMessage } from '../../../core/services/business-rule-error.helper';

@Component({
  selector: 'app-login-bookverse',
  standalone: false,
  templateUrl: './login-bookverse.component.html',
  styleUrl: './login-bookverse.component.scss',
})
export class LoginBookverseComponent extends BaseComponent {
  private fb = inject(FormBuilder);
  private auth = inject(AuthFacadeService);
  private router = inject(Router);
  private currentUser = inject(CurrentUserService);
  private cartService = inject(CartApiService);
  private translate = inject(TranslateService);

  hidePassword = true;
  // Banner shown at the top of the form. Null = hidden. We store the localized text directly
  // so different errors (wrong credentials, wrong CAPTCHA, etc.) can use the same banner with
  // their own message instead of a generic line.
  loginErrorMessage: string | null = null;

  // Reference to the captcha widget in the template. We read its token + answer when submitting
  // and call refresh() on it after a server-side failure so the user gets a fresh challenge.
  @ViewChild('captcha') captcha?: CaptchaInputComponent;

  // 2FA state
  requiresTwoFactor: boolean = false;
  twoFactorEmail: string = '';
  showTwoFactorError: boolean = false;

  loginForm = this.fb.group({
    // email: ['admin@bookverse.com', [Validators.required, Validators.email]],
    // password: ['string', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  twoFactorForm = this.fb.group({
    code: [
      '',
      [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(6),
        Validators.pattern(/^[0-9]+$/),
      ],
    ],
  });

  onSubmit(): void {
    // Block submit until BOTH the email/password form AND the captcha answer field are valid.
    if (this.loginForm.invalid || !this.captcha?.isValid || this.isLoading) return;

    // Clear stale errors from the previous attempt: per-field server errors AND the
    // top-of-form banner. If the new attempt fails for a different reason, the error
    // handler will set the appropriate message again.
    clearServerErrors(this.loginForm);
    this.loginErrorMessage = null;

    this.startLoading();

    // Read the captcha pair from the shared widget and include it in the login payload.
    // The backend re-verifies the pair before checking credentials.
    const captchaValue = this.captcha?.getValue() ?? { token: '', answer: '' };

    const payload: LoginCommand = {
      email: this.loginForm.value.email ?? '',
      password: this.loginForm.value.password ?? '',
      fingerprint: null,
      captchaToken: captchaValue.token,
      captchaAnswer: captchaValue.answer,
    };

    this.auth.login(payload).subscribe({
      next: (response: LoginCommandDto) => {
        // console.log('login response:', response);
        this.stopLoading();
        // if the backend requires 2FA
        if (response.requiresTwoFactor) {
          this.requiresTwoFactor = true;
          this.twoFactorEmail = response.email ?? '';
          return;
        }
        this.handlePostLoginNavigation();
      },
      error: (err) => {
        this.stopLoading();
        // Always refresh the captcha after any failure. If the captcha itself was wrong the
        // old one is now consumed; if credentials were wrong, refreshing also stops an attacker
        // from re-using a single solved captcha across many login attempts.
        this.captcha?.refresh();

        // CAPTCHA_INVALID (and any other business-rule code) shows in the same red banner at
        // the top of the form, but with its OWN localized message so the user knows the
        // captcha was the problem - not the credentials.
        const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
        if (businessRuleMsg) {
          this.loginErrorMessage = businessRuleMsg;
          return;
        }

        // Per-field validation errors paint inline on the inputs instead of the banner.
        const fieldErrors = extractFieldErrors(err);
        const handled = applyFieldErrorsToForm(this.loginForm, fieldErrors);
        // Fall back to the generic "invalid credentials" message in the banner.
        this.loginErrorMessage = handled
          ? null
          : this.translate.instant('AUTH.LOGIN.INVALID_CREDENTIALS');
        console.error('Login error:', err);
      },
    });
  }

  /**
   * Returns the server-side error message attached to `controlName`, or null when the field
   * has only client-side errors. The template uses this to render the backend's message in the
   * existing mat-error slot, falling back to the i18n key when no server error is present.
   */
  serverError(controlName: string): string | null {
    return (this.loginForm.get(controlName)?.errors?.['serverError'] as string) ?? null;
  }

  get validMailPass() {
    return this.loginForm.get('email')?.valid && this.loginForm.get('password')?.valid;
  }

  private restoreLanguage(): void {
    const saved = localStorage.getItem('user_lang');
    if (saved) {
      localStorage.setItem('lang', saved);
      localStorage.removeItem('user_lang');
      this.translate.use(saved);
    }
  }

  private handlePostLoginNavigation(): void {
    this.restoreLanguage();
    const pending = sessionStorage.getItem('pendingAddToCart');
    sessionStorage.removeItem('pendingAddToCart');

    const user = this.currentUser.snapshot;
    const isCustomer = !!user && !user.isAdmin && !user.isManager && !user.isEmployee;

    if (pending && isCustomer) {
      const { bookId, quantity } = JSON.parse(pending);
      this.cartService.addToCart({ bookId, quantity }).subscribe({
        next: () => this.router.navigate(['/client/cart']),
        error: () => this.router.navigate(['/client/cart']),
      });
      return;
    }

    this.router.navigate([this.currentUser.getDefaultRoute()]);
  }

  //when the user clicks to verify
  onVerifyTwoFactor(): void {
    if (this.twoFactorForm.invalid || this.isLoading) return;

    this.startLoading();

    const payload: VerifyTwoFactorCommand = {
      email: this.twoFactorEmail,
      code: this.twoFactorForm.value.code ?? '',
    };

    this.auth.verifyTwoFactor(payload).subscribe({
      next: () => {
        this.stopLoading();
        this.handlePostLoginNavigation();
      },
      error: (err) => {
        this.stopLoading();
        this.showTwoFactorError = true;
        console.error('2FA error:', err);
      },
    });
  }
}
