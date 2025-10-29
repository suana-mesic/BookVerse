import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatError, MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { LoginResponse } from '../../shared/models/LoginResponse';
import { Router, RouterLink } from '@angular/router';
@Component({
  standalone: true,
  selector: 'app-login',
  imports: [
    RouterLink,
    ReactiveFormsModule,
    MatFormField,
    MatInput,
    MatError,
    MatFormFieldModule,
    CommonModule,
    MatIconModule,
    FormsModule,
    MatFormField,
    MatError,
  ],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  registerForm: FormGroup;
  http = inject(HttpClient);
  showLoginError: boolean = false;
  serverMessage: string = '';
  loggedUser: any[] = [];

  constructor(private fb: FormBuilder, private Router: Router) {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      fingerPrint: [''],
    });
  }

  onLogin() {
    console.log('Login clicked');

    const formData = this.registerForm.value;

    this.http
      .post<LoginResponse>('https://localhost:7260/api/auth/login', formData, {
        headers: { Accept: 'text/plain' },
      })
      .subscribe({
        next: (result) => {
          alert('Uspješno ste se logirali');
          this.handleLoginSuccess(result);
          this.Router.navigate(['/']);
        },
        error: (error) => {
          this.showLoginError = true;
          console.log('Login error:', error.error.message);
          this.serverMessage = error.error.message;
        },
      });
  }

  handleLoginSuccess(result: LoginResponse) {
    sessionStorage.setItem('accessToken', result.accessToken);
    sessionStorage.setItem('refreshToken', result.refreshToken);
    sessionStorage.setItem('expiresAt', result.expiresAtUtc.toString());
  }

  get validMailPass() {
    return this.registerForm.get('email')?.valid && this.registerForm.get('password')?.valid;
  }
}
