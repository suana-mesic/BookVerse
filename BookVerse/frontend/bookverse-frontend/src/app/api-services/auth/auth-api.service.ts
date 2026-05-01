import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  LoginCommand,
  LoginCommandDto,
  RefreshTokenCommand,
  RefreshTokenCommandDto,
  LogoutCommand,
  RegisterCommand,
  RegisterCommandDto,
  VerifyTwoFactorCommand,
  ForgotPasswordCommand,
  ResetPasswordCommand
} from './auth-api.model';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/Auth`;
  private http = inject(HttpClient);

   /**
   * POST /Auth/verify-2fa
   * Verify 2FA code and get tokens.
   */
  verifyTwoFactor(payload: VerifyTwoFactorCommand): Observable<LoginCommandDto> {
    return this.http.post<LoginCommandDto>(`${this.baseUrl}/verify-2fa`, payload);
  }

  /**
   * POST /Auth/login
   * Authenticate user and get access/refresh tokens.
   */
  login(payload: LoginCommand): Observable<LoginCommandDto> {
    return this.http.post<LoginCommandDto>(`${this.baseUrl}/login`, payload);
  }

  register(payload: RegisterCommand): Observable<RegisterCommandDto> {
    return this.http.post<RegisterCommandDto>(`${this.baseUrl}/register`, payload);
  }


  /**
   * POST /Auth/refresh
   * Refresh access token using refresh token.
   */
  refresh(payload: RefreshTokenCommand): Observable<RefreshTokenCommandDto> {
    return this.http.post<RefreshTokenCommandDto>(`${this.baseUrl}/refresh`, payload);
  }

  /**
   * POST /Auth/logout
   * Invalidate refresh token and logout user.
   */
  logout(payload: LogoutCommand): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/logout`, payload);
  }

  forgotPassword(payload: ForgotPasswordCommand): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/forgot-password`, payload);
  }

  resetPassword(payload: ResetPasswordCommand): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/reset-password`, payload);
  }
}
