import { Component, inject } from '@angular/core';
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
  showLoginError: boolean = false;

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
    if (this.loginForm.invalid || this.isLoading) return;

    this.startLoading();

    const payload: LoginCommand = {
      email: this.loginForm.value.email ?? '',
      password: this.loginForm.value.password ?? '',
      fingerprint: null,
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
        this.showLoginError = true;
        console.error('Login error:', err);
      },
    });
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
