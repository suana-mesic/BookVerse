import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthLayoutComponent } from './auth-layout/auth-layout.component';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';
import { LoginBookverseComponent } from './login-bookverse/login-bookverse.component';

const routes: Routes = [
  {
    path: '',
    component: AuthLayoutComponent,
    children: [
      //{ path: 'login', component: LoginComponent }, //-> Template Login
      { path: 'login', component: LoginBookverseComponent }, //-> Our custom Login
      { path: 'register', component: RegisterComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'logout', component: LogoutComponent },
      { path: '', redirectTo: 'login', pathMatch: 'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
