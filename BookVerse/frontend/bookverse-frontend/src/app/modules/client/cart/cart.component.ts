import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { ListCartDto } from '../../../api-services/cart/cart-api.model';
import { Location } from '@angular/common';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';
import { LangChangeEvent, TranslateService } from '@ngx-translate/core';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
  standalone: false,
})
export class CartComponent implements OnInit, OnDestroy {
  cart: ListCartDto = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };
  isLoading = true;
  private location = inject(Location);
  private translate = inject(TranslateService);
  private destroy$ = new Subject<void>();
  private currentLang = 'bs';

  constructor(
    private cartService: CartApiService,
    private authFacade: AuthFacadeService,
  ) {}

  ngOnInit(): void {
    this.currentLang = this.translate.currentLang || this.translate.defaultLang || 'bs';

    if (!this.authFacade.isAuthenticated()) {
      this.cart = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };
      this.isLoading = false;
      return;
    }
    this.loadCart();

    this.translate.onLangChange
      .pipe(takeUntil(this.destroy$))
      .subscribe((event: LangChangeEvent) => {
        this.currentLang = event.lang;
        this.loadCart();
      });
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  loadCart(): void {
    if (!this.authFacade.isAuthenticated()) {
      this.cart = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };
      this.isLoading = false;
      return;
    }
    this.isLoading = true;
    this.cartService.getCart(this.currentLang).subscribe({
      next: (data) => {
        this.cart = data;
        this.isLoading = false;
      },
      error: () => {
        this.cart = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };
        this.isLoading = false;
      },
    });
  }

  updateQuantity(cartId: number, bookId: number, quantity: number): void {
    if (quantity <= 0) return;
    this.cartService.updateQuantity({ cartId, bookId, quantity }).subscribe({
      next: () => this.loadCart(),
    });
  }

  removeItem(cartId: number, bookId: number): void {
    this.cartService.removeFromCart({ cartId, bookId }).subscribe({
      next: () => this.loadCart(),
    });
  }

  saveForLater(cartId: number, bookId: number): void {
    this.cartService.saveForLater({ cartId, bookId, savedForLater: true }).subscribe({
      next: () => this.loadCart(),
    });
  }

  moveToCart(cartId: number, bookId: number): void {
    this.cartService.saveForLater({ cartId, bookId, savedForLater: false }).subscribe({
      next: () => this.loadCart(),
    });
  }

  goBack(): void {
    this.location.back();
  }
}
