import { Component, inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ShippingMethodDto } from '../../../api-services/shipping-methods/shipping-methods-api.model';
import { UserAddressDto } from '../../../api-services/users/users-api.model';
import { ListStoresQueryDto } from '../../../api-services/stores/stores-api.model';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { ShippingMethodsApiService } from '../../../api-services/shipping-methods/shipping-methods-api.service';
import { StoresApiService } from '../../../api-services/stores/stores-api.service';
import { BaseComponent } from '../../core/components/base-classes/base-component';
import { ToasterService } from '../../core/services/toaster.service';
import { CouponDto, ListCouponsQueryDto } from '../../../api-services/coupons/coupons-api.model';
import { CouponsApiService } from '../../../api-services/coupons/coupons-api.service';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { ListCartDto } from '../../../api-services/cart/cart-api.model';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';

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
  private couponService=inject(CouponsApiService);
  private storesService = inject(StoresApiService);
  private ordersService = inject(OrdersApiService);
  private toaster = inject(ToasterService);

  private cartService = inject(CartApiService);
  cart: ListCartDto = {activeItems:[], savedForLaterItems:[], totalPrice:0};

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
  appliedCoupons: CouponDto []= [];
  couponError = '';
  allCoupons: ListCouponsQueryDto[]=[];

  addressForm = this.fb.group({
    line1: ['', Validators.required],
    line2: [''],
    city: ['', Validators.required],
    country: ['', Validators.required],
  });

  uneseniKupon:FormControl = new FormControl('', this.validirajUneseniKupon());

  validirajUneseniKupon():ValidatorFn{
    return (control:AbstractControl) : ValidationErrors | null => {
      if(!control.value || !control || control.value=='')
        return null;

      const postoji = this.allCoupons.some(x=>x.name.toLowerCase() == this.uneseniKupon.value.toLowerCase()); 
      return postoji?null:{kuponNePostoji:true};
    }
  }

  ngOnInit(): void {
    this.startLoading();

    this.userService.getUserAddress().subscribe({
      next: (address) => {
        this.userAddress = address;
        this.useExistingAddress = !!address?.line1;
        this.stopLoading();
      },
      error: () => {
        this.stopLoading('Greška pri učitavanju adrese.');
      }
    });

    this.shippingMethodsService.getShippingMethods().subscribe({
      next: (methods) => this.shippingMethods = methods
    });

    this.storesService.list().subscribe({
      next: (stores) => this.stores = stores.items
    });

    this.cartService.getCart().subscribe({
      next: (cart) => this.cart = cart
    })

    this.couponService.getAllCoupons().subscribe({
      next: (listaKupona) => {
        this.allCoupons = listaKupona;
        console.log(listaKupona);
      }
    })
  }

  nextStep(): void {
    if (this.currentStep < this.totalSteps)
      this.currentStep++;
  }

  prevStep(): void {
    if (this.currentStep > 1)
      this.currentStep--;
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
    return this.shippingMethods.find(x => x.id === this.selectedShippingMethodId) ?? null;
  }

  getSelectedStore(): ListStoresQueryDto | null {
    return this.stores.find(s => s.id === this.selectedStoreId) ?? null;
  }

  getDeliveryAddress(): UserAddressDto | any {
    return this.useExistingAddress ? this.userAddress : this.addressForm.value;
  }

  proceedToPayment(): void {
    this.startLoading();

    const address = this.getDeliveryAddress();

    const request = {
      shippingMethodId:this.selectedShippingMethodId!,
      storeId: this.deliveryType=='pickup'?this.selectedStoreId:null,
      useExistingAddress:this.useExistingAddress,
      line1:this.useExistingAddress?null:address.line1,
      line2:this.useExistingAddress?null:address.line2,
      city:this.useExistingAddress?null:address.city,
      country:this.useExistingAddress?null:address.country,
      couponIds:this.appliedCoupons.map(c=>c.id)
    };

    this.ordersService.createOrder(request).subscribe({
      next:(response)=>{
        this.stopLoading();
        this.toaster.success('Narudžba potvrđena! Preusmjeravamo na plaćanje...');
        this.router.navigate(['/client/payment'], {
        state: { orderData: response }
      });
      },
      error:(err)=>{
        this.stopLoading();
        this.toaster.error("Greška prilikom kreiranje narudćbe");
      }
    })
  }

applyCoupon(): void {
  if (!this.uneseniKupon.value.trim()) return;
  this.couponError = '';

  if (this.appliedCoupons.some(c => c.promotionCode === this.uneseniKupon.value)) {
    this.couponError = 'Ovaj kupon je već primijenjen.';
    return;
  }

  this.couponService.validateCoupon(this.uneseniKupon.value).subscribe({
    next: (coupon) => {
      this.appliedCoupons.push(coupon);
      this.uneseniKupon.setValue('');
      this.toaster.success(`Kupon "${coupon.name}" uspješno primijenjen!`);
    },
    error: () => {
      this.couponError = 'Kupon nije pronađen ili je istekao.';
    }
  });
}

  removeCoupon(id: number): void {
    this.appliedCoupons = this.appliedCoupons.filter(c => c.id !== id);
  }

  getDiscountAmount(totalPrice: number): number {
    const shipping = this.deliveryType === 'shipping'
      ? (this.getSelectedShippingMethod()?.price ?? 0)
      : 0;
    
    let cijena = totalPrice + shipping;

    for (const coupon of this.appliedCoupons) {
      if (coupon.amountOff) cijena -= coupon.amountOff;
      else if (coupon.percentOff) cijena -= cijena * (coupon.percentOff / 100);
    }

    if (cijena < 0) cijena = 0;

    return (totalPrice + shipping) - cijena;
  }

  getFinalPrice(): number {
    const shipping = this.deliveryType === 'shipping'
      ? (this.getSelectedShippingMethod()?.price ?? 0)
      : 0;
    return this.cart.totalPrice + shipping - this.getDiscountAmount(this.cart.totalPrice);
  }
}