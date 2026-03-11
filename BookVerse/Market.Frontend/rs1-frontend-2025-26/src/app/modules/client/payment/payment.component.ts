import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToasterService } from '../../core/services/toaster.service';
import { OrdersApiService } from '../../../api-services/orders/orders-api.service';
import { loadStripe, Stripe, StripeElements, StripePaymentElement } from '@stripe/stripe-js';
import { BaseComponent } from '../../core/components/base-classes/base-component';
import { CaptchaApiService } from '../../../api-services/captcha/captcha-api.service';
import { CartApiService } from '../../../api-services/cart/cart-api.service';

@Component({
  selector: 'app-payment',
  standalone: false,
  templateUrl: './payment.component.html',
  styleUrl: './payment.component.scss',
})
export class PaymentComponent extends BaseComponent implements OnInit {
  private router = inject(Router);
  private toaster = inject(ToasterService);
  private captchaService = inject(CaptchaApiService);
  private cartService = inject(CartApiService);

  captchaImage: string = '';
  captchaToken: string = '';
  captchaAnswer: string = '';
  captchaVerified: boolean = false;

  // Podaci o narudžbi proslijeđeni iz checkout komponente (orderId, clientSecret, publishableKey, totalPrice)
  orderData: any = null;
  // Glavna Stripe instanca — koristi se za confirmPayment()
  stripe: Stripe | null = null;
  // Kontejner koji drži sve Stripe UI elemente (payment element)
  elements: StripeElements | null = null;
  // Ukupna cijena narudžbe za prikaz na UI
  totalPrice: number = 0;

  async ngOnInit(): Promise<void> {
    const navigation = this.router.getCurrentNavigation();
    this.orderData = history.state.orderData; // Dohvaćamo orderData koji smo proslijedili iz checkout komponente kroz router state

    //Ako nema order data onda preusmjeri na korpu
    if (!this.orderData) {
      this.toaster.error('Nema podataka o narudžbi.');
      this.router.navigate(['/client/cart']);
      return;
    }

    this.totalPrice = this.orderData.totalPrice;
    this.loadCaptcha();
    await this.initStripe(); // Inicijalizujemo Stripe i prikazujemo formu za unos kartice
  }

  loadCaptcha(): void {
    this.captchaService.generate().subscribe({
      next: (data) => {
        this.captchaImage = data.image;
        this.captchaToken = data.token;
        this.captchaAnswer = '';
        this.captchaVerified = false;
      },
    });
  }

  verifyCaptcha(): void {
    if (!this.captchaAnswer.trim()) {
      this.toaster.error('Unesite odgovor sa slike.');
      return;
    }

    this.captchaService.verify(this.captchaToken, this.captchaAnswer).subscribe({
      next: () => {
        this.captchaVerified = true;
        this.toaster.success('Captcha uspješno verificirana!');
      },
      error: () => {
        this.toaster.error('Pogrešan odgovor. Pokušajte ponovo.');
        this.loadCaptcha();
      },
    });
  }

  async initStripe(): Promise<void> {
    // loadStripe učitava Stripe.js sa Stripe servera koristeći naš publishableKey
    // publishableKey je javni ključ — bezbjedno ga koristiti na frontendu
    this.stripe = await loadStripe(this.orderData.publishableKey);

    // clientSecret je tajni ključ koji smo dobili od backenda
    // appearance definira vizuelni stil Stripe forme
    if (!this.stripe) {
      this.toaster.error('Greška pri učitavanju Stripe-a.');
      return;
    }

    this.elements = this.stripe.elements({
      clientSecret: this.orderData.clientSecret,
      appearance: { theme: 'stripe' },
    });

    // Kreiramo 'payment' element — Stripe automatski prikazuje odgovarajuće polje
    // (kartica, Google Pay, Apple Pay itd. ovisno o browseru)
    const paymentElement = this.elements.create('payment');
    paymentElement.mount('#payment-element'); // renderujemo payment element u div sa id="payment-element" u HTML-u
  }

  async submitPayment(): Promise<void> {
    // Ako Stripe ili elements nisu inicijalizovani, ne radimo ništa
    if (!this.stripe || !this.elements) return;

    // Pokazujemo loading indikator dok se plaćanje procesira
    this.startLoading();

    // confirmPayment šalje podatke kartice direktno Stripeu (ne smiju prolaziti kroz naš backend)
    // elements — Stripe čita unesene podatke kartice iz forme
    // return_url — URL na koji Stripe preusmjerava korisnika nakon uspješnog plaćanja
    const { error } = await this.stripe.confirmPayment({
      elements: this.elements,
      confirmParams: {
        // Nakon uspješnog plaćanja, Stripe dodaje payment_intent_client_secret kao query param
        return_url: `${window.location.origin}/client/order-success`,
      },
    });

    // Ako je došlo do greške (pogrešan broj kartice, insufficient funds itd.)
    // Stripe NE preusmjerava na return_url — ostajemo na stranici i prikazujemo grešku
    if (error) {
      this.stopLoading();
      this.toaster.error(error.message ?? 'Greška pri plaćanju.');
    }
  }
}
