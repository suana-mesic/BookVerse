import { Component, inject, OnInit } from '@angular/core';
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
import { BaseComponent } from '../../core/components/base-classes/base-component';
import { ToasterService } from '../../core/services/toaster.service';
import { CouponDto } from '../../../api-services/coupons/coupons-api.model';
import { CouponsApiService } from '../../../api-services/coupons/coupons-api.service';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { ListCartDto } from '../../../api-services/cart/cart-api.model';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';
import { catchError, map, Observable, of, switchMap, timer } from 'rxjs';
import { CountriesApiService } from '../../../api-services/CountriesNow/countires-api.service';
import { Location } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'app-checkout',
  standalone: false,
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss',
})
export class CheckoutComponent extends BaseComponent implements OnInit {
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

  countriesService = inject(CountriesApiService);

  private cartService = inject(CartApiService);
  cart: ListCartDto = { activeItems: [], savedForLaterItems: [], totalPrice: 0 };

  currentStep = 1;
  totalSteps = 3;

  userAddress: UserAddressDto | null = null;
  shippingMethods: ShippingMethodDto[] = [];
  stores: ListStoresQueryDto[] = [];

  useExistingAddress = true;
  deliveryType: 'shipping' | 'pickup' = 'shipping';
  selectedShippingMethodId: number | null = null;
  selectedStoreId: number | null = null;

  couponCode = '';
  appliedCoupons: CouponDto[] = [];
  couponError = '';

  addressForm = this.fb.group({
    line1: ['', Validators.required],
    line2: [''],
    city: [{ value: '', disabled: true }, [Validators.required]],
    country: ['', Validators.required],
  });

  countries: { name: string; countryCode: string; nameBs: string }[] = [];
  cities: string[] = [];
  loadingCities = false;

  //async validator se prosljeđuje kao treći element
  uneseniKupon: FormControl = new FormControl('', null, this.validirajUneseniKupon());

  validirajUneseniKupon(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value || !control || control.value == '') return of(null);

      //čeka 500ms nakon prestanka tipkanja
      return timer(500).pipe(
        switchMap(() => this.couponService.validateCoupon(control.value)),
        map(() => null), //kupojn postoji -> vrati null
        catchError(() => of({ kuponNePostoji: true })), //kupon ne postoji -> vrati kuponNePostoji: true
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

    this.shippingMethodsService.getShippingMethods().subscribe({
      next: (methods) => (this.shippingMethods = methods),
    });

    this.storesService.list().subscribe({
      next: (stores) => (this.stores = stores.items),
    });

    this.cartService.getCart().subscribe({
      next: (cart) => (this.cart = cart),
    });

    this.countriesService.getCountries().subscribe((countries) => {
      this.countries = countries;
    });
  }

  public onCountryChange(country: { name: string; countryCode: string }) {
    this.addressForm.get('city')?.reset();
    this.addressForm.get('city')?.disable();
    this.cities = [];

    if (country) {
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

  getDeliveryAddress(): UserAddressDto | any {
    return this.useExistingAddress ? this.userAddress : this.addressForm.value;
  }

  proceedToPayment(): void {
    this.startLoading();

    const address = this.getDeliveryAddress();

    console.log('selectedShippingMethodId');
    console.log(this.selectedShippingMethodId);
    console.log('selectedStoreId');
    console.log(this.selectedStoreId);

    const request = {
      shippingMethodId: this.selectedShippingMethodId ?? null,
      storeId: this.deliveryType == 'pickup' ? this.selectedStoreId : null,
      useExistingAddress: this.useExistingAddress,
      line1: this.useExistingAddress ? null : address.line1,
      line2: this.useExistingAddress ? null : address.line2,
      city: this.useExistingAddress ? null : address.city,
      country: this.useExistingAddress ? null : address.country?.nameBs,
      couponIds: this.appliedCoupons.map((c) => c.id),
    };

    this.ordersService.createOrder(request).subscribe({
      next: (response) => {
        this.saveCheckoutState();
        this.stopLoading();
        this.toaster.success(this.translate.instant('CLIENT.CHECKOUT.ORDER_CONFIRMED'));
        this.router.navigate(['/client/payment'], {
          state: { orderData: response },
        });
      },
      error: (err) => {
        this.stopLoading();
        this.toaster.error(this.translate.instant('CLIENT.CHECKOUT.ERROR_CREATE_ORDER'));
      },
    });
  }

  applyCoupon(): void {
    if (!this.uneseniKupon.value.trim()) return;
    this.couponError = '';

    if (this.appliedCoupons.some((c) => c.promotionCode === this.uneseniKupon.value)) {
      this.couponError = this.translate.instant('CLIENT.CHECKOUT.COUPON_ALREADY_APPLIED');
      return;
    }

    this.couponService.validateCoupon(this.uneseniKupon.value).subscribe({
      next: (coupon) => {
        this.appliedCoupons.push(coupon);
        this.uneseniKupon.setValue('');
        this.toaster.success(
          this.translate.instant('CLIENT.CHECKOUT.COUPON_APPLIED', { name: coupon.name }),
        );
      },
      error: () => {
        this.couponError = this.translate.instant('CLIENT.CHECKOUT.COUPON_NOT_FOUND');
      },
    });
  }

  removeCoupon(id: number): void {
    this.appliedCoupons = this.appliedCoupons.filter((c) => c.id !== id);
  }

  getDiscountAmount(totalPrice: number): number {
    const shipping =
      this.deliveryType === 'shipping' ? (this.getSelectedShippingMethod()?.price ?? 0) : 0;

    let cijena = totalPrice + shipping;

    for (const coupon of this.appliedCoupons) {
      if (coupon.amountOff) cijena -= coupon.amountOff;
      else if (coupon.percentOff) cijena -= cijena * (coupon.percentOff / 100);
    }

    if (cijena < 0) cijena = 0;

    return totalPrice + shipping - cijena;
  }

  getFinalPrice(): number {
    const shipping =
      this.deliveryType === 'shipping' ? (this.getSelectedShippingMethod()?.price ?? 0) : 0;
    return this.cart.totalPrice + shipping - this.getDiscountAmount(this.cart.totalPrice);
  }

  isBookAvailableInStore(storeId: number): boolean {
    return this.cart.activeItems.every((item) => {
      const qtyInStock = item.quantityInStockInStores?.[storeId] ?? 0; //količina na skladištu
      return qtyInStock >= item.quantity; //true ako je količina na skladištu veća ili jednaka odabranoj količini za kupovinu
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
        const qtyInStock = item.quantityInStockInStores?.[storeId] ?? 0; //količina na skladištu
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

  //Koristi se session storage kako bismo sačuvali podatke koje je korisnik odabrao prije nego je kliknuo na "Potvrdi i plati narudžbu"
  //Ovi podaci su nam potrebni kada korisnik klikne na dugme "Nazad" na formi za plaćanje (payment) kako bismo mogli uraditi restore checkout forme
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

    //ako je korisnik unosio novu adresu pri plaćanju
    if (state.addressForm) {
      this.addressForm.patchValue(state.addressForm);

      // ako je država bila odabrana, učitaj gradove i enable-aj city
      if (state.addressForm.country) {
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
