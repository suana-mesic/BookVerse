import { NgModule } from '@angular/core';

import { ClientRoutingModule } from './client-routing-module';
import { SharedModule } from '../shared/shared-module';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { HeaderComponent } from '../public/header/header.component';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { PaymentComponent } from './payment/payment.component';
import { OrderSuccessComponent } from './order-success/order-success.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { UserBooksComponent } from './user-books/user-books.component';

@NgModule({
  declarations: [
    UserProfileComponent,
    CartComponent,
    CheckoutComponent,
    PaymentComponent,
    OrderSuccessComponent,
    UserOrdersComponent,
    UserBooksComponent,
  ],
  imports: [SharedModule, ClientRoutingModule, HeaderComponent],
})
export class ClientModule {}
