import { ChangeDetectorRef, Component, inject, OnDestroy, OnInit } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  FormBuilder,
  FormControl,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ShippingMethodDto } from '../../../api-services/shipping-methods/shipping-methods-api.model';
import { UserAddressDto } from '../../../api-services/users/users-api.model';
import { ListStoresQueryDto } from '../../../api-services/stores/stores-api.model';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { ShippingMethodsApiService } from '../../../api-services/shipping-methods/shipping-methods-api.service';
import { StoresApiService } from '../../../api-services/stores/stores-api.service';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { ToasterService } from '../../../core/services/toaster.service';
import { CouponDto } from '../../../api-services/coupons/coupons-api.model';
import { CouponsApiService } from '../../../api-services/coupons/coupons-api.service';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { ListCartDto } from '../../../api-services/cart/cart-api.model';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';
import { catchError, map, Observable, of, Subscription, switchMap, timer } from 'rxjs';
import { CountriesApiService } from '../../../api-services/rest-countries/countires-api.service';
import { Location } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import { getBusinessRuleMessage } from '../../../core/services/business-rule-error.helper';
import { getBackendErrorMessage } from '../../../core/services/backend-error-message.helper';
@Component({
  selector: 'app-checkout',
  standalone: false,
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss',
})
export class CheckoutComponent extends BaseComponent implements OnInit, OnDestroy {
  private subscriptions = new Subscription();

  private fb = inject(FormBuilder);
  private router = inject(Router);
  private userService = inject(UsersApiService);
  private shippingMethodsService = inject(ShippingMethodsApiService);
  private couponService = inject(CouponsApiService);
  private storesService = inject(StoresApiService);
  private ordersService = inject(OrdersApiService);
  private toaster = inject(ToasterService);
  private location = inject(Location);
  private translate = inject(TranslateService);
  private cdr = inject(ChangeDetectorRef);

  countriesService = inject(CountriesApiService);

  private cartService = inject(CartApiService);
  cart: ListCartDto = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };

  currentStep = 1;
  totalSteps = 3;

  userAddress: UserAddressDto | null = null;
  shippingMethods: ShippingMethodDto[] = [];
  stores: ListStoresQueryDto[] = [];

  deliveryForm = this.fb.group({
    useExistingAddress: this.fb.control<boolean>(true, Validators.required),
    deliveryType: this.fb.control<'shipping' | 'pickup'>('shipping', Validators.required),
    shippingMethodId: this.fb.control<number | null>(null),
    storeId: this.fb.control<number | null>(null),
  });

  get useExistingAddress(): boolean {
    return !!this.deliveryForm.controls.useExistingAddress.value;
  }
  set useExistingAddress(value: boolean) {
    this.deliveryForm.controls.useExistingAddress.setValue(value);
  }

  get deliveryType(): 'shipping' | 'pickup' {
    return this.deliveryForm.controls.deliveryType.value ?? 'shipping';
  }
  set deliveryType(value: 'shipping' | 'pickup') {
    this.deliveryForm.controls.deliveryType.setValue(value);
  }

  get selectedShippingMethodId(): number | null {
    return this.deliveryForm.controls.shippingMethodId.value;
  }
  set selectedShippingMethodId(value: number | null) {
    this.deliveryForm.controls.shippingMethodId.setValue(value);
  }

  get selectedStoreId(): number | null {
    return this.deliveryForm.controls.storeId.value;
  }
  set selectedStoreId(value: number | null) {
    this.deliveryForm.controls.storeId.setValue(value);
  }

  couponCode = '';
  appliedCoupons: CouponDto[] = [];
  couponError = '';

  // Business cap from the backend (CouponValidationService.MaxCouponsPerOrder). Kept in sync
  // here so the user gets an inline error before submit, instead of a 409 after submit.
  readonly maxCouponsPerOrder = 2;

  addressForm = this.fb.group({
    line1: ['', Validators.required],
    line2: [''],
    city: [{ value: '', disabled: true }, [Validators.required]],
    country: ['', Validators.required],
  });

  countries: { name: string; countryCode: string; nameBs: string }[] = [];
  cities: string[] = [];
  loadingCities = false;

  //async validator is passed as the third element
  enteredCoupon: FormControl = new FormControl('', null, this.validateEnteredCoupon());

  validateEnteredCoupon(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value || !control || control.value == '') return of(null);

      //waits 500ms after the user stops typing
      return timer(500).pipe(
        switchMap(() => this.couponService.validateCoupon(control.value)),
        map(() => null), //coupon exists -> return null
        catchError((err) => {
          // If the backend rejected with a known business-rule code (e.g. COUPON_MAX_USES_REACHED
          // when the user has already redeemed this coupon their personal MaxUses times), surface
          // the localized message via the validator error so <mat-error> can show the correct
          // reason instead of the generic "coupon does not exist or has expired". When the backend
          // returns a non-business-rule message we still try the known-message map so e.g. the
          // localized "user not signed in" surfaces in place of the generic 404 fallback.
          const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
          const backendMsg = getBackendErrorMessage(err, this.translate);
          const message = businessRuleMsg ?? backendMsg;
          if (message) {
            return of({ couponBusinessRule: message });
          }
          return of({ couponDoesNotExist: true });
        }),
      );
    };
  }

  ngOnInit(): void {
    const comingFromPayment = history?.state?.fromPayment;
    if (!comingFromPayment) sessionStorage.removeItem('checkoutState');

    const hasSavedState = !!sessionStorage.getItem('checkoutState');
    this.restoreCheckoutState();
    this.startLoading();

    this.userService.getUserAddress().subscribe({
      next: (address) => {
        this.userAddress = address;
        if (!hasSavedState) {
          this.useExistingAddress = !!address?.line1;
        }
        this.stopLoading();
      },
      error: () => {
        this.stopLoading(this.translate.instant('CLIENT.CHECKOUT.ERROR_LOAD_ADDRESS'));
      },
    });

    const lang = this.translate.currentLang || this.translate.defaultLang || 'bs';

    this.shippingMethodsService.getShippingMethods(lang).subscribe({
      next: (methods) => (this.shippingMethods = methods),
    });

    this.storesService.list().subscribe({
      next: (stores) => (this.stores = stores.items),
    });

    this.cartService.getCart(lang).subscribe({
      next: (cart) => {
        this.cart = cart;
        this.revalidateAppliedCoupons();
      },
    });

    this.subscriptions.add(
      this.translate.onLangChange.subscribe((event) => {
        this.cartService.getCart(event.lang).subscribe({
          next: (cart) => {
            this.cart = cart;
            this.revalidateAppliedCoupons();
          },
        });
        this.shippingMethodsService.getShippingMethods(event.lang).subscribe({
          next: (methods) => (this.shippingMethods = methods),
        });
        this.countriesService.getCountries().subscribe((countries) => {
          this.countries = countries;
        });
      }),
    );

    this.countriesService.getCountries().subscribe((countries) => {
      this.countries = countries;
    });

    this.enteredCoupon.statusChanges.subscribe(() => {
      this.enteredCoupon.markAsTouched();
      this.cdr.detectChanges();
    });
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  private isRestoringState = false;
  public onCountryChange(country: { name: string; countryCode: string } | null): void {
    if (this.isRestoringState) return; // block during state restore

    this.addressForm.get('city')?.reset();
    this.addressForm.get('city')?.disable();
    this.cities = [];

    if (!country?.countryCode) return;

    this.loadingCities = true;
    this.countriesService.getCitiesByCountry(country.countryCode).subscribe({
      next: (cities) => {
        this.cities = cities;
        this.loadingCities = false;
        this.addressForm.get('city')?.enable();
      },
      error: () => (this.loadingCities = false),
    });
  }

  nextStep(): void {
    if (this.currentStep < this.totalSteps) this.currentStep++;
  }

  prevStep(): void {
    if (this.currentStep > 1) this.currentStep--;
  }

  isStep1Valid(): boolean {
    if (this.useExistingAddress) return !!this.userAddress?.line1;
    return this.addressForm.valid;
  }

  isStep2Valid(): boolean {
    if (this.deliveryType === 'shipping') return !!this.selectedShippingMethodId;
    return !!this.selectedStoreId;
  }

  getSelectedShippingMethod(): ShippingMethodDto | null {
    return this.shippingMethods.find((x) => x.id === this.selectedShippingMethodId) ?? null;
  }

  getSelectedStore(): ListStoresQueryDto | null {
    return this.stores.find((s) => s.id === this.selectedStoreId) ?? null;
  }

  getDeliveryAddress(): any {
    if (this.useExistingAddress) return this.userAddress;

    const formValue = this.addressForm.getRawValue();
    const country = formValue.country as any;
    return {
      ...formValue,
      country: country?.name ?? country,
    };
  }

  getDisplayCountry(savedCountry: string | null | undefined): string {
    if (!savedCountry) return '';
    const match = this.countries.find((c) => c.nameBs === savedCountry);
    return match?.name ?? savedCountry;
  }

  proceedToPayment(): void {
    this.submitOrder();
  }

  private submitOrder(): void {
    this.startLoading();

    const address = this.getDeliveryAddress();
    const rawCountry = this.addressForm.getRawValue().country as any;

    const request = {
      // Send only the id matching the chosen delivery mode. The backend validator enforces
      // a strict XOR between shippingMethodId and storeId, so sending both (which happened
      // when the user toggled pickup but selectedShippingMethodId still held a leftover value)
      // gets rejected with "Choose either shipping method or pickup store, not both."
      shippingMethodId: this.deliveryType === 'shipping' ? (this.selectedShippingMethodId ?? null) : null,
      storeId: this.deliveryType === 'pickup' ? this.selectedStoreId : null,
      useExistingAddress: this.useExistingAddress,
      line1: this.useExistingAddress ? null : address.line1,
      line2: this.useExistingAddress ? null : address.line2,
      city: this.useExistingAddress ? null : address.city,
      country: this.useExistingAddress ? null : (rawCountry?.nameBs ?? rawCountry?.name ?? null),
      // Defense-in-depth: dedupe by id when building the payload. The two anti-duplicate
      // checks in applyCoupon() should already keep appliedCoupons unique, but if a duplicate
      // ever slips through (race condition, manual state restore from session storage) we
      // strip it here so the backend never sees the same coupon id twice.
      couponIds: [...new Set(this.appliedCoupons.map((c) => c.id))],
    };

    this.ordersService.createOrder(request).subscribe({
      next: (response) => {
        this.saveCheckoutState();
        this.stopLoading();
        this.toaster.success(this.translate.instant('CLIENT.CHECKOUT.ORDER_CONFIRMED'));

        // Free-order flow: backend returns an empty clientSecret when coupons brought totalPrice to zero.
        // No Stripe payment step is required, so we skip the payment screen and go straight to the success page.
        if (!response?.clientSecret) {
          this.router.navigate(['/client/order-success']);
          return;
        }

        this.router.navigate(['/client/payment'], {
          state: { orderData: response },
        });
      },
      error: (err) => {
        this.stopLoading();
        // Priority: business-rule code (localized via i18n key) > known backend English message
        // (mapped to ERRORS.BACKEND_MESSAGES.* i18n key) > generic "could not create order" fallback.
        const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
        const backendMsg = getBackendErrorMessage(err, this.translate);
        this.toaster.error(
          businessRuleMsg
            ?? backendMsg
            ?? this.translate.instant('CLIENT.CHECKOUT.ERROR_CREATE_ORDER'),
        );
      },
    });
  }

  applyCoupon(): void {
    // Normalize once: trim whitespace and lowercase so duplicate detection works regardless of
    // how the user typed the code ("WELCOME10A" vs "welcome10a" must be treated as identical).
    const entered = (this.enteredCoupon.value ?? '').trim();
    if (!entered) return;
    this.couponError = '';

    const enteredLower = entered.toLowerCase();

    // Hard cap on number of coupons per order. Same limit lives in the backend
    // (CouponValidationService.MaxCouponsPerOrder); enforcing it here too saves a round
    // trip and lets the user see the error inline instead of on submit.
    if (this.appliedCoupons.length >= this.maxCouponsPerOrder) {
      this.couponError = this.translate.instant('CLIENT.CHECKOUT.COUPON_MAX_REACHED', {
        max: this.maxCouponsPerOrder,
      });
      return;
    }

    // Anti-duplicate check, part 1: compare by promotionCode case-insensitively before we hit
    // the network. Without toLowerCase the user could re-submit the same code in different
    // casing and we would fire a needless backend call.
    if (this.appliedCoupons.some((c) => c.promotionCode.toLowerCase() === enteredLower)) {
      const message = this.translate.instant('CLIENT.CHECKOUT.COUPON_ALREADY_APPLIED');
      // Inline error stays under the input AND toaster fires for extra visibility, so the
      // user notices the duplicate even if they were not looking at the coupon field.
      this.couponError = message;
      this.toaster.error(message);
      return;
    }

    this.couponService.validateCoupon(entered).subscribe({
      next: (coupon) => {
        // Anti-duplicate check, part 2: after the backend returns the canonical coupon,
        // make sure its id is not already in the applied list. This catches the edge case
        // where two different-looking codes resolved to the same coupon record.
        if (this.appliedCoupons.some((c) => c.id === coupon.id)) {
          const message = this.translate.instant('CLIENT.CHECKOUT.COUPON_ALREADY_APPLIED');
          this.couponError = message;
          this.toaster.error(message);
          return;
        }

        // MinOrderAmount check: the same rule lives on the backend
        // (CouponValidationService) and would return 409 on order submit. We do it here
        // too so the user sees the reason inline immediately, without a round-trip.
        if (coupon.minOrderAmount != null && this.cart.totalPrice < coupon.minOrderAmount) {
          const message = this.translate.instant('CLIENT.CHECKOUT.COUPON_MIN_ORDER_AMOUNT', {
            code: coupon.promotionCode,
            min: coupon.minOrderAmount,
          });
          this.couponError = message;
          this.toaster.error(message);
          return;
        }

        this.appliedCoupons.push(coupon);
        this.enteredCoupon.setValue('');
        this.toaster.success(
          this.translate.instant('CLIENT.CHECKOUT.COUPON_APPLIED', { code: coupon.promotionCode }),
        );
      },
      error: (err) => {
        // Priority for inline coupon error: business-rule code (e.g. COUPON_MAX_USES_REACHED) >
        // known backend English message > generic "not found" fallback.
        const businessRuleMsg = getBusinessRuleMessage(err, this.translate);
        const backendMsg = getBackendErrorMessage(err, this.translate);
        this.couponError = businessRuleMsg
          ?? backendMsg
          ?? this.translate.instant('CLIENT.CHECKOUT.COUPON_NOT_FOUND');
      },
    });
  }

  removeCoupon(id: number): void {
    this.appliedCoupons = this.appliedCoupons.filter((c) => c.id !== id);
  }

  // Re-checks every previously applied coupon against the current cart subtotal. Coupons
  // whose MinOrderAmount is no longer met by the cart get removed from this.appliedCoupons
  // and the user gets a localized toast - that way the backend won't reject the order at
  // submit time with a raw English "requires a minimum order amount" message. Triggered
  // after every cart reload (initial load and language change).
  private revalidateAppliedCoupons(): void {
    if (!this.appliedCoupons.length) return;

    const keptCoupons: CouponDto[] = [];
    const droppedCodes: string[] = [];

    for (const coupon of this.appliedCoupons) {
      if (coupon.minOrderAmount != null && this.cart.totalPrice < coupon.minOrderAmount) {
        droppedCodes.push(coupon.promotionCode);
        continue;
      }
      keptCoupons.push(coupon);
    }

    if (droppedCodes.length === 0) return;

    this.appliedCoupons = keptCoupons;
    this.toaster.error(
      this.translate.instant('CLIENT.CHECKOUT.COUPONS_DROPPED_AFTER_CART_CHANGE', {
        codes: droppedCodes.join(', '),
      }),
    );
  }

  getDiscountAmount(totalPrice: number): number {
    const subTotal = totalPrice;
    let discountAmount = 0;

    for (const coupon of this.appliedCoupons) {
      if (coupon.amountOff) discountAmount += coupon.amountOff;
      else if (coupon.percentOff) discountAmount += subTotal * (coupon.percentOff / 100);
    }

    return discountAmount;
  }

  getFinalPrice(): number {
    const shipping =
      this.deliveryType === 'shipping' ? (this.getSelectedShippingMethod()?.price ?? 0) : 0;
    const finalPrice =
      this.cart.totalPrice + shipping - this.getDiscountAmount(this.cart.totalPrice);
    return finalPrice < 0 ? 0 : finalPrice;
  }

  isBookAvailableInStore(storeId: number): boolean {
    return this.cart.activeItems.every((item) => {
      const qtyInStock = item.quantityInStockInStores?.[storeId] ?? 0; //quantity in stock
      return qtyInStock >= item.quantity; //true if the stock quantity is greater than or equal to the selected purchase quantity
    });
  }

  isBookAvailableForShipping(): boolean {
    return this.cart.activeItems.every((item) => {
      return item.quantityInStockForOnlineOrders >= item.quantity;
    });
  }

  getUnavailableBooksForStore(storeId: number): string[] {
    return this.cart.activeItems
      .filter((item) => {
        const qtyInStock = item.quantityInStockInStores?.[storeId] ?? 0; //quantity in stock
        return qtyInStock < item.quantity;
      })
      .map((item) => item.bookTitle);
  }

  getUnavailableBooksForShipping(): string[] {
    return this.cart.activeItems
      .filter((item) => {
        return item.quantityInStockForOnlineOrders < item.quantity;
      })
      .map((item) => item.bookTitle);
  }

  //Session storage is used to save the data the user selected before clicking "Confirm and pay for order"
  //This data is needed when the user clicks the "Back" button on the payment form so the checkout form can be restored
  private saveCheckoutState() {
    sessionStorage.setItem(
      'checkoutState',
      JSON.stringify({
        currentStep: this.currentStep,
        useExistingAddress: this.useExistingAddress,
        deliveryType: this.deliveryType,
        selectedShippingMethodId: this.selectedShippingMethodId,
        selectedStoreId: this.selectedStoreId,
        appliedCoupons: this.appliedCoupons,
        addressForm: this.addressForm.getRawValue(),
      }),
    );
  }

  private restoreCheckoutState() {
    const saved = sessionStorage.getItem('checkoutState');
    if (!saved) return;

    const state = JSON.parse(saved);
    this.currentStep = state.currentStep;
    this.useExistingAddress = state.useExistingAddress;
    this.deliveryType = state.deliveryType;
    this.selectedShippingMethodId = state.selectedShippingMethodId;
    this.selectedStoreId = state.selectedStoreId;
    this.appliedCoupons = state.appliedCoupons ?? [];

    if (state.addressForm) {
      this.isRestoringState = true; // enable flag BEFORE patchValue
      this.addressForm.patchValue(state.addressForm);
      this.isRestoringState = false; // disable flag AFTER patchValue

      if (state.addressForm.country?.countryCode) {
        this.loadingCities = true;
        this.countriesService.getCitiesByCountry(state.addressForm.country.countryCode).subscribe({
          next: (cities) => {
            this.cities = cities;
            this.loadingCities = false;
            this.addressForm.get('city')?.enable();
            this.addressForm.get('city')?.setValue(state.addressForm.city);
          },
          error: () => (this.loadingCities = false),
        });
      }
    }

    sessionStorage.removeItem('checkoutState');
  }

  goBack(): void {
    this.location.back();
  }
}
