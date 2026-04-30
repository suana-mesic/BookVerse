import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { AuthApiService } from '../../../api-services/auth/auth-api.service';

@Component({
  selector: 'app-forgot-password',
  standalone: false,
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss',
})
export class ForgotPasswordComponent extends BaseComponent {
  private fb = inject(FormBuilder);
  private authApi = inject(AuthApiService);

  emailSent = false;
  showError = false;

  forgotForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
  });

  onSubmit(): void {
    if (this.forgotForm.invalid || this.isLoading) return;

    this.startLoading();
    this.showError = false;

    this.authApi.forgotPassword({ email: this.forgotForm.value.email ?? '' }).subscribe({
      next: () => {
        this.stopLoading();
        this.emailSent = true;
      },
      error: () => {
        this.stopLoading();
        this.showError = true;
      },
    });
  }
}
