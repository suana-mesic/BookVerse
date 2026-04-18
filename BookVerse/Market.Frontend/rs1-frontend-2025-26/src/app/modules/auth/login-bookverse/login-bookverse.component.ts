import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../core/components/base-classes/base-component';
import { Router } from '@angular/router';
import { CurrentUserService } from '../../../core/services/auth/current-user.service';
import {
  LoginCommand,
  LoginCommandDto,
  VerifyTwoFactorCommand,
} from '../../../api-services/auth/auth-api.model';
import { AuthFacadeService } from '../../core/services/auth/auth-facade.service';

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

  hidePassword = true;
  showLoginError: boolean = false;

  // 2FA state
  requiresTwoFactor: boolean = false;
  twoFactorEmail: string = '';
  twoFactorCode: string = '';
  showTwoFactorError: boolean = false;
  loginErrorStatus: number = 0;

  loginForm = this.fb.group({
    // email: ['admin@bookverse.com', [Validators.required, Validators.email]],
    // password: ['string', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
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
        console.log('login response:', response);
        this.stopLoading();
        // ako backend traži 2FA
        if (response.requiresTwoFactor) {
          this.requiresTwoFactor = true;
          this.twoFactorEmail = response.email ?? '';
          return;
        }
        const target = this.currentUser.getDefaultRoute();
        this.router.navigate([target]);
      },
      error: (err) => {
        this.stopLoading();
        this.showLoginError = true;
        // čuvamo status kod za prikaz poruke
        this.loginErrorStatus = err.status;
        console.error('Login error:', err);
      },
    });
  }

  get validMailPass() {
    return this.loginForm.get('email')?.valid && this.loginForm.get('password')?.valid;
  }

  //kada korisnik klikne da se verifikuje
  onVerifyTwoFactor(): void {
    if (!this.twoFactorCode || this.isLoading) return;

    this.startLoading();

    const payload: VerifyTwoFactorCommand = {
      email: this.twoFactorEmail,
      code: this.twoFactorCode,
    };

    this.auth.verifyTwoFactor(payload).subscribe({
      next: () => {
        this.stopLoading();
        const target = this.currentUser.getDefaultRoute();
        this.router.navigate([target]);
      },
      error: (err) => {
        this.stopLoading();
        this.showTwoFactorError = true;
        console.error('2FA error:', err);
      },
    });
  }
}
