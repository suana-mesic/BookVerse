import { Component, OnInit } from '@angular/core';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { ListCartDto, CartItemDto } from '../../../api-services/cart/cart-api.model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  standalone:false
})
export class CartComponent implements OnInit {
  cart: ListCartDto = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };
  isLoading = true;

  constructor(private cartService: CartApiService) {}

  ngOnInit(): void {
    this.loadCart();
  }

  loadCart(): void {
    this.isLoading = true;
    this.cartService.getCart().subscribe({
      next: (data) => {
        this.cart = data;
        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }

 updateQuantity(cartId: number, bookId: number, quantity: number): void {
  if (quantity <= 0) return;
  this.cartService.updateQuantity({ cartId, bookId, quantity }).subscribe({
    next: () => this.loadCart()
  });
}

removeItem(cartId: number, bookId: number): void {
  this.cartService.removeFromCart({ cartId, bookId }).subscribe({
    next: () => this.loadCart()
  });
}


saveForLater(cartId: number, bookId: number): void {
  this.cartService.saveForLater({ cartId, bookId, savedForLater: true }).subscribe({
    next: () => this.loadCart()
  });
}

moveToCart(cartId: number, bookId: number): void {
  this.cartService.saveForLater({ cartId, bookId, savedForLater: false }).subscribe({
    next: () => this.loadCart()
  });
}
}