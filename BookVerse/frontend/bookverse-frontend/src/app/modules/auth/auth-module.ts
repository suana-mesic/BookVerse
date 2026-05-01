import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing-module';
import { AuthLayoutComponent } from './auth-layout/auth-layout.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { LogoutComponent } from './logout/logout.component';
import { SharedModule } from '../shared/shared-module';
import { LoginBookverseComponent } from './login-bookverse/login-bookverse.component';
import { HeaderComponent } from '../public/header/header.component';

@NgModule({
  declarations: [
    AuthLayoutComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    LogoutComponent,
    LoginBookverseComponent,
  ],
  imports: [AuthRoutingModule, SharedModule, HeaderComponent],
})
export class AuthModule {}
