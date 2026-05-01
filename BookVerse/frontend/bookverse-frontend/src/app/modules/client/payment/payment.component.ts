import { Component, inject, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { ToasterService } from '../../../core/services/toaster.service';
import { loadStripe, Stripe, StripeElements, StripePaymentElement } from '@stripe/stripe-js';
import { BaseComponent } from '../../../core/components/base-classes/base-component';
import { CaptchaApiService } from '../../../api-services/captcha/captcha-api.service';
import { CartApiService } from '../../../api-services/cart/cart-api.service';
import { formatNumber, Location } from '@angular/common';
import { TranslateService } from '@ngx-translate/core';
import { DialogHelperService } from '../../shared/services/dialog-helper.service';
import { DialogButton } from '../../shared/models/dialog-config.model';
@Component({
  selector: 'app-payment',
  standalone: false,
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.scss',
})
export class PaymentComponent extends BaseComponent implements OnInit, OnDestroy {
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private captchaService = inject(CaptchaApiService);
  private cartService = inject(CartApiService);
  private location = inject(Location);
  private translate = inject(TranslateService);
  private fb = inject(FormBuilder);
  private dialogHelper = inject(DialogHelperService);

  private langSub: Subscription | null = null;

  captchaImage: string = '';
  captchaToken: string = '';
  captchaVerified: boolean = false;

  captchaForm = this.fb.group({
    answer: ['', [Validators.required]],
  });

  // Order data passed from the checkout component (orderId, clientSecret, publishableKey, totalPrice)
  orderData: any = null;
  // Main Stripe instance — used for confirmPayment()
  stripe: Stripe | null = null;
  // Container that holds all Stripe UI elements (payment element)
  elements: StripeElements | null = null;
  // Total order price for display on the UI
  totalPrice: number = 0;
  paymentFormComplete: boolean = false;

  async ngOnInit(): Promise<void> {
    const navigation = this.router.getCurrentNavigation();
    this.orderData = history.state.orderData; // Retrieve orderData passed from the checkout component via router state

    // If there is no order data, redirect to the cart
    if (!this.orderData) {
      this.toaster.error(this.translate.instant('CLIENT.PAYMENT.NO_ORDER_DATA'));
      this.router.navigate(['/client/cart']);
      return;
    }

    this.totalPrice = this.orderData.totalPrice;
    this.loadCaptcha();
    await this.initStripe();

    this.langSub = this.translate.onLangChange.subscribe(() => {
      this.initStripe();
    }); // Initialize Stripe and display the card input form
  }

  loadCaptcha(): void {
    this.captchaService.generate().subscribe({
      next: (data) => {
        this.captchaImage = data.image;
        this.captchaToken = data.token;
        this.captchaForm.reset({ answer: '' });
        this.captchaVerified = false;
      },
    });
  }

  verifyCaptcha(): void {
    const answer = (this.captchaForm.value.answer ?? '').trim();
    if (this.captchaForm.invalid || !answer) {
      this.toaster.error(this.translate.instant('CLIENT.PAYMENT.ENTER_CAPTCHA'));
      return;
    }

    this.captchaService.verify(this.captchaToken, answer).subscribe({
      next: () => {
        this.captchaVerified = true;
        this.toaster.success(this.translate.instant('CLIENT.PAYMENT.CAPTCHA_SUCCESS'));
      },
      error: () => {
        this.toaster.error(this.translate.instant('CLIENT.PAYMENT.CAPTCHA_WRONG'));
        this.loadCaptcha();
      },
    });
  }

  ngOnDestroy(): void {
    this.langSub?.unsubscribe();
  }

  prevStep() {
    this.router.navigate(['/client/checkout'], { state: { fromPayment: true } });
  }

  async initStripe(): Promise<void> {
    const paymentContainer = document.getElementById('payment-element');
    if (paymentContainer) paymentContainer.innerHTML = '';

    this.stripe = await loadStripe(this.orderData.publishableKey);

    // Appearance defines the visual style of the Stripe form
    if (!this.stripe) {
      this.toaster.error(this.translate.instant('CLIENT.PAYMENT.STRIPE_ERROR'));
      return;
    }

    const isDark = document.body.classList.contains('dark-theme');
    const lang = this.translate.currentLang || this.translate.defaultLang || 'bs';
    const stripeLocale = lang === 'en' ? 'en' : 'hr';

    this.elements = this.stripe.elements({
      clientSecret: this.orderData.clientSecret, // clientSecret is the secret key received from the backend
      locale: stripeLocale as any,
      appearance: isDark
        ? {
            theme: 'night',
            variables: {
              colorBackground: '#1e2d42',
              colorText: '#d8d8d8',
              colorPrimary: '#4976b5',
              colorDanger: '#ef5350',
              borderRadius: '8px',
            },
          }
        : { theme: 'stripe' },
    });

    // Create the 'payment' element — Stripe automatically displays the appropriate field
    // (card, Google Pay, Apple Pay, etc. depending on the browser)
    const paymentElement = this.elements.create('payment');
    paymentElement.mount('#payment-element'); // Render the payment element in the div with id="payment-element" in HTML
    this.paymentFormComplete = false;
    paymentElement.on('change', (event) => {
      this.paymentFormComplete = event.complete === true;
    });
  }

  confirmAndPay(): void {
    const lang = this.translate.currentLang || this.translate.defaultLang || 'bs';
    const locale = lang === 'en' ? 'en-US' : 'bs';
    const amount = formatNumber(this.totalPrice, locale, '1.2-2');
    this.dialogHelper.checkout.confirmPayment(amount).subscribe((result) => {
      if (result?.button !== DialogButton.YES) return;
      this.submitPayment();
    });
  }

  async submitPayment(): Promise<void> {
    // If Stripe or elements are not initialized, do nothing
    if (!this.stripe || !this.elements) return;

    // Show the loading indicator while the payment is being processed
    this.startLoading();

    // confirmPayment sends card data directly to Stripe (must not pass through our backend)
    // elements — Stripe reads the entered card data from the form
    // return_url — URL to which Stripe redirects the user after a successful payment
    const { error } = await this.stripe.confirmPayment({
      elements: this.elements,
      confirmParams: {
        // After successful payment, Stripe adds payment_intent_client_secret as a query param
        return_url: `${window.location.origin}/client/order-success`,
      },
    });

    // If an error occurred (wrong card number, insufficient funds, etc.)
    // Stripe does NOT redirect to return_url — we stay on the page and display the error
    if (error) {
      this.stopLoading();
      this.toaster.error(error.message ?? this.translate.instant('CLIENT.PAYMENT.PAYMENT_ERROR'));
    }
  }

  goBack(): void {
    this.location.back();
  }
}
