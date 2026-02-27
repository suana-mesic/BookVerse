import {NgModule} from '@angular/core';

import {ClientRoutingModule} from './client-routing-module';
import {SharedModule} from '../shared/shared-module';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { HeaderComponent } from '../public/header/header.component';
import { CartComponent } from './cart/cart.component';


@NgModule({
  declarations: [
    UserProfileComponent,
    CartComponent
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
    HeaderComponent
  ]
})
export class ClientModule { }
