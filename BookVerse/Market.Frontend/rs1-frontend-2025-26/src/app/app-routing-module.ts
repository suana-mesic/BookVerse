import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { myAuthData, myAuthGuard } from './core/guards/my-auth-guard';
import { BookDetailsComponent } from './modules/public/book-details/book-details.component';

const routes: Routes = [
  {
    path: 'admin',
    canActivate: [myAuthGuard],
    data: myAuthData({ requireAuth: true, requireStaff: true }),
    loadChildren: () => import('./modules/admin/admin-module').then((m) => m.AdminModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth-module').then((m) => m.AuthModule),
  },

  // {
  //   path: 'login',
  //   loadComponent: () =>
  //     import('./modules/auth/auth-module').then(m => m.AuthModule)
  // },
  {
    path: 'client',
    canActivate: [myAuthGuard],
    data: myAuthData({ requireAuth: true }), // bilo ko logiran
    loadChildren: () => import('./modules/client/client-module').then((m) => m.ClientModule),
  },
  {
    path: 'public',
    loadChildren: () => import('./modules/public/public-module').then((m) => m.PublicModule),
  },
  {
    path: 'knjige/:id',
    loadComponent: () =>
      import('./modules/public/book-details/book-details.component').then(
        (m) => m.BookDetailsComponent,
      ),
  },
  {
    path: '',
    loadComponent: () =>
      // Promijenite loadChildren u loadComponent
      import('./modules/public/landing-page/landing-page').then((m) => m.LandingPage),
  },

  // fallback 404
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
