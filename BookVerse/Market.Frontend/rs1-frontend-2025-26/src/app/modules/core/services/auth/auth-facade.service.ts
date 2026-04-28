// src/app/core/services/auth/auth-facade.service.ts
import { Injectable, inject, signal, computed } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, tap, catchError, map } from 'rxjs';
import { jwtDecode } from 'jwt-decode';

import { AuthApiService } from '../../../../api-services/auth/auth-api.service';
import {
  LoginCommand,
  LoginCommandDto,
  LogoutCommand,
  RefreshTokenCommand,
  RefreshTokenCommandDto,
  VerifyTwoFactorCommand,
} from '../../../../api-services/auth/auth-api.model';

import { AuthStorageService } from './auth-storage.service';
import { CurrentUserDto } from './current-user.dto';
import { JwtPayloadDto } from './jwt-payload.dto';

/**
 * Glavni auth servis (façade).
 * - priča sa AuthApiService (HTTP)
 * - priča sa AuthStorageService (localStorage)
 * - dekodira JWT i drži CurrentUser kao signal
 *
 * Koristi se u:
 * - interceptoru (getAccessToken, refresh)
 * - guardovima (isAuthenticated, isAdmin)
 * - komponentama (login, logout, navbar)
 */
@Injectable({ providedIn: 'root' })
export class AuthFacadeService {
  private api = inject(AuthApiService);
  private storage = inject(AuthStorageService);
  private router = inject(Router);

  // === REACTIVE STATE: current user ===

  private _currentUser = signal<CurrentUserDto | null>(null);

  /** readonly signal za UI – čita se kao auth.currentUser() */
  currentUser = this._currentUser.asReadonly();

  /** computed signali nad current userom */
  isAuthenticated = computed(() => !!this._currentUser());
  isAdmin = computed(() => this._currentUser()?.isAdmin ?? false);
  isManager = computed(() => this._currentUser()?.isManager ?? false);
  isEmployee = computed(() => this._currentUser()?.isEmployee ?? false);

  constructor() {
    // pokušaj inicijalizacije iz postojećeg access tokena
    this.initializeFromToken();
  }

  // =========================================================
  // PUBLIC API
  // =========================================================

  /**
   * Login korisnika (email + password).
   * Snima tokene u storage, dekodira JWT i popunjava current user state.
   */
  login(payload: LoginCommand): Observable<LoginCommandDto> {
    return this.api.login(payload).pipe(
      tap((response: LoginCommandDto) => {
        // snimamo tokene SAMO ako nema 2FA i accessToken postoji
        if (!response.requiresTwoFactor && response.accessToken) {
          this.storage.saveLogin(response); // čuva u localStorage
          this.decodeAndSetUser(response.accessToken); // dekodira JWT
        }
      }),
      map((response) => response),
    );
  }

  verifyTwoFactor(payload: VerifyTwoFactorCommand): Observable<void> {
    return this.api.verifyTwoFactor(payload).pipe(
      tap((response: LoginCommandDto) => {
        if (response.accessToken) {
          this.storage.saveLogin(response);
          this.decodeAndSetUser(response.accessToken);
        }
      }),
      map(() => void 0),
    );
  }

  /**
   * Logout korisnika:
   * - lokalno očisti state i tokene
   * - pokuša invalidirati refresh token na serveru (bez drame na error)
   */
  logout(): Observable<void> {
    const refreshToken = this.storage.getRefreshToken();

    // 1) lokalno očisti (optimistic logout)
    // console.log('BEFORE clear - isAuthenticated:', this._currentUser());
    this.clearUserState();
    // console.log('AFTER clear - isAuthenticated:', this._currentUser());
    // console.log('localStorage accessToken:', localStorage.getItem('accessToken'));

    // 2) nema refresh tokena → nema ni API poziva
    if (!refreshToken) {
      return of(void 0);
    }

    const payload: LogoutCommand = { refreshToken };

    // 3) pokušaj server-side logout, ignoriši greške
    return this.api.logout(payload).pipe(catchError(() => of(void 0)));
  }

  /**
   * Refresh access tokena – koristi refresh token.
   * Poziva interceptor kada dobije 401.
   */
  refresh(payload: RefreshTokenCommand): Observable<RefreshTokenCommandDto> {
    return this.api.refresh(payload).pipe(
      tap((response: RefreshTokenCommandDto) => {
        this.storage.saveRefresh(response); // snimi nove tokene
        this.decodeAndSetUser(response.accessToken); // update current usera
      }),
    );
  }

  /**
   * Utility za guardove/interceptore – očisti auth state i prebaci na /login.
   */
  redirectToLogin(): void {
    this.clearUserState();
    this.router.navigate(['/login']);
  }

  // =========================================================
  // GETTERI ZA INTERCEPTOR
  // =========================================================

  /**
   * Access token za Authorization header.
   */
  getAccessToken(): string | null {
    return this.storage.getAccessToken();
  }

  /**
   * Refresh token za refresh poziv.
   */
  getRefreshToken(): string | null {
    return this.storage.getRefreshToken();
  }

  // =========================================================
  // PRIVATE HELPERS
  // =========================================================

  /**
   * Na startu aplikacije (konstruktor) – pokušaj obnoviti stanje iz postojećeg tokena.
   */
  private initializeFromToken(): void {
    const token = this.storage.getAccessToken();
    if (token) {
      this.decodeAndSetUser(token);
    }
  }

  /**
   * Dekodiraj JWT i postavi current user state.
   */
  private decodeAndSetUser(token: string): void {
    if (!token) return;
    try {
      const payload = jwtDecode<JwtPayloadDto>(token);
      // console.log('JWT PAYLOAD:', payload);

      const user: CurrentUserDto = {
        userId: Number(payload.sub),
        email: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
        isAdmin: payload.is_admin === 'true',
        isManager: payload.is_manager === 'true',
        isEmployee: payload.is_employee === 'true',
        tokenVersion: Number(payload.ver),
        firstName: payload.firstName,
        lastName: payload.lastName,
        fullName: payload.fullName,
      };

      this._currentUser.set(user);
    } catch (error) {
      console.error('Failed to decode JWT token:', error);
      this._currentUser.set(null);
    }
  }

  /**
   * Očisti user state + sve tokene iz storage-a.
   */
  private clearUserState(): void {
    this._currentUser.set(null);
    this.storage.clear();
  }
}
