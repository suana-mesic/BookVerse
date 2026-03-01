import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-order-success',
  standalone: false,
  templateUrl: './order-success.component.html',
  styleUrl: './order-success.component.scss'
})
export class OrderSuccessComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  paymentIntentId: string | null = null;

  ngOnInit(): void {
    // Stripe dodaje payment_intent kao query param u URL nakon uspješnog plaćanja
    this.paymentIntentId = this.route.snapshot.queryParamMap.get('payment_intent');

    // Ako nema payment_intent u URL-u, korisnik je direktno otvorio stranicu — preusmjeri ga
    if (!this.paymentIntentId) {
      this.router.navigate(['/client/cart']);
    }
  }

  goToHome(): void {
    this.router.navigate(['/']);
  }
}
