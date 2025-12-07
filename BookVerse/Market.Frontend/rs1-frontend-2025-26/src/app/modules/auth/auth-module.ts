import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing-module';
import { AuthLayoutComponent } from './auth-layout/auth-layout.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LogoutComponent } from './logout/logout.component';
import { SharedModule } from '../shared/shared-module';
import { LoginBookverseComponent } from './login-bookverse/login-bookverse.component';


@NgModule({
  declarations: [
    AuthLayoutComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    LogoutComponent,
    LoginBookverseComponent
  ],
  imports: [
    AuthRoutingModule,
    SharedModule
  ]
})
export class AuthModule { }
