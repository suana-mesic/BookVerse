import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../core/components/base-classes/base-component';
import { AuthFacadeService } from '../../core/services/auth/auth-facade.service';
import { Router } from '@angular/router';
import { CurrentUserService } from '../../core/services/auth/current-user.service';
import { LoginCommand } from '../../../api-services/auth/auth-api.model';

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

  loginForm = this.fb.group({
    email: ['admin@gmail.com', [Validators.required, Validators.email]],
    password: ['string', [Validators.required]],
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
      next: () => {
        this.stopLoading();
        const target = this.currentUser.getDefaultRoute();
        this.router.navigate([target]);
      },
      error: (err) => {
        this.stopLoading('Invalid credentials. Please try again.');
        this.showLoginError = true;
        console.error('Login error:', err);
      },
    });
  }

  get validMailPass() {
    return this.loginForm.get('email')?.valid && this.loginForm.get('password')?.valid;
  }
}
