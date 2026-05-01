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
    // Stripe adds payment_intent as a query param to the URL after a successful payment
    this.paymentIntentId = this.route.snapshot.queryParamMap.get('payment_intent');

    // If there is no payment_intent in the URL, the user opened the page directly — redirect them
    if (!this.paymentIntentId) {
      this.router.navigate(['/client/cart']);
    }
  }

  goToHome(): void {
    this.router.navigate(['/']);
  }
}
