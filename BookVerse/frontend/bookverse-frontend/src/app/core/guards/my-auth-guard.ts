// src/app/core/guards/auth.guard.ts
import { inject } from '@angular/core';
import { CanActivateFn, ActivatedRouteSnapshot, Router } from '@angular/router';
import { CurrentUserService } from '../services/auth/current-user.service';

export const myAuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot) => {
  const currentUser = inject(CurrentUserService);
  const router = inject(Router);

  const requireAuth = route.data['requireAuth'] === true;
  const requireAdmin = route.data['requireAdmin'] === true;
  const requireManager = route.data['requireManager'] === true;
  const requireEmployee = route.data['requireEmployee'] === true;
  const requireStaff = route.data['requireStaff'] === true;
  const denyStaff = route.data['denyStaff'] === true;

  const isAuth = currentUser.isAuthenticated();

  if (denyStaff && isAuth) {
    const staffUser = currentUser.snapshot;
    if (staffUser && (staffUser.isAdmin || staffUser.isManager || staffUser.isEmployee)) {
      router.navigate(['/admin']);
      return false;
    }
  }

  // 1) if the route requires auth and the user is not logged in → redirect to login
  if (requireAuth && !isAuth) {
    router.navigate(['/auth/login']);
    return false;
  }

  // If auth is not required → allow (public routes)
  if (!requireAuth) {
    return true;
  }

  // 2) role check – admin > manager > employee
  const user = currentUser.snapshot;
  if (!user) {
    router.navigate(['/auth/login']);
    return false;
  }

  if (requireStaff) {
    const isStaff = user.isAdmin || user.isManager || user.isEmployee;
    if (!isStaff) {
      router.navigate([currentUser.getDefaultRoute()]);
      return false;
    }
    return true;
  }

  if (requireAdmin && !user.isAdmin) {
    router.navigate([currentUser.getDefaultRoute()]);
    return false;
  }

  if (requireManager && !user.isManager) {
    router.navigate([currentUser.getDefaultRoute()]);
    return false;
  }

  if (requireEmployee && !user.isEmployee) {
    router.navigate([currentUser.getDefaultRoute()]);
    return false;
  }

  return true;
};

export interface MyAuthRouteData {
  requireAuth?: boolean;
  requireAdmin?: boolean;
  requireManager?: boolean;
  requireEmployee?: boolean;
  requireStaff?: boolean;
  denyStaff?: boolean;
}

export function myAuthData(data: MyAuthRouteData): MyAuthRouteData {
  return data;
}
