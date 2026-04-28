import { Component, OnDestroy, OnInit, effect, inject, signal, untracked } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import {
  SignalRService,
  OrderStatusNotification,
  OrderNotification,
} from './core/services/signal-r/signal-r.service';
import { AuthFacadeService } from './modules/core/services/auth/auth-facade.service';
import { OrderStatusHelper } from './api-services/orders/order-status.helper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit, OnDestroy {
  protected readonly title = signal('rs1-frontend-2025-26');
  currentLang: string = 'bs';

  private signalR = inject(SignalRService);
  private auth = inject(AuthFacadeService);
  private orderStatusSub: Subscription | null = null;
  private newPaidOrderSub: Subscription | null = null;

  constructor(private translate: TranslateService) {
    this.translate.addLangs(['en', 'bs']);
    this.translate.setDefaultLang('bs');

    const savedLang = localStorage.getItem('lang') || 'bs';
    this.currentLang = savedLang;

    this.translate.use(savedLang).subscribe({
      next: (translations) => {
        console.log('Translations loaded successfully for language:', savedLang);
        console.log('Available keys:', Object.keys(translations));
      },
      error: (error) => {
        console.error('Error loading translations:', error);
        console.error('Check if files exist at: /i18n/' + savedLang + '.json');
      },
    });

    effect(() => {
      const isAuth = this.auth.isAuthenticated();
      const user = this.auth.currentUser();
      if (isAuth) {
        untracked(() => {
          const token = this.auth.getAccessToken();
          if (!token) return;

          if (!this.orderStatusSub) {
            this.signalR.startUserConnection(token);
            this.subscribeToOrderStatusNotifications();
          }

          if (user?.isAdmin && !this.newPaidOrderSub) {
            this.signalR.startAdminConnection(token);
            this.subscribeToNewPaidOrderNotifications();
          }
        });
      } else {
        untracked(() => {
          this.cleanupOrderStatusNotifications();
          this.cleanupNewPaidOrderNotifications();
        });
      }
    });
  }

  ngOnInit(): void {
    const savedSettings =
      localStorage.getItem('userSettings') || localStorage.getItem('adminSettings');
    if (savedSettings) {
      const settings = JSON.parse(savedSettings);
      if (settings.theme === 'dark') {
        document.body.classList.add('dark-theme');
      }
    }

    this.translate.get('BOOKS.TITLE').subscribe((res: string) => {
      console.log('Translation for BOOKS.TITLE:', res);
      if (res === 'BOOKS.TITLE') {
        console.error('⚠️ Translation not working! Key returned instead of value.');
        console.error('Possible causes:');
        console.error('1. Translation files not in /i18n/ folder');
        console.error('2. JSON files have syntax errors');
        console.error('3. TranslateService not properly initialized');
      }
    });
  }

  private subscribeToOrderStatusNotifications(): void {
    this.orderStatusSub = this.signalR.orderStatusChanged$.subscribe(
      (notification: OrderStatusNotification) => {
        const settings = JSON.parse(localStorage.getItem('userSettings') || '{}');
        if (settings.orderStatusNotifications === false) return;

        const statusKey = OrderStatusHelper.getLabel(notification.newStatus);
        const statusLabel = this.translate.instant(statusKey);
        const message = this.translate.instant('NOTIFICATIONS.ORDER_STATUS_CHANGED', {
          status: statusLabel,
        });

        this.signalR.addUserNotification({
          message,
          orderNumber: notification.orderNumber || '',
          receivedAt: new Date(notification.updatedAt),
        });
      },
    );
  }

  private cleanupOrderStatusNotifications(): void {
    this.signalR.stopUserConnection();
    this.orderStatusSub?.unsubscribe();
    this.orderStatusSub = null;
  }

  private subscribeToNewPaidOrderNotifications(): void {
    this.newPaidOrderSub = this.signalR.newPaidOrder$.subscribe(
      (notification: OrderNotification) => {
        const settings = JSON.parse(localStorage.getItem('adminSettings') || '{}');
        if (settings.notificationsEnabled === false) return;

        this.signalR.addAdminNotification(notification);

        if (settings.soundEnabled !== false) {
          const audio = new Audio('/sounds/pixel_notification.mp3');
          audio.play().catch((err) => console.warn('Audio play failed: ', err));
        }
      },
    );
  }

  private cleanupNewPaidOrderNotifications(): void {
    this.signalR.stopConnection();
    this.newPaidOrderSub?.unsubscribe();
    this.newPaidOrderSub = null;
  }

  switchLanguage(lang: string): void {
    this.currentLang = lang;
    localStorage.setItem('lang', lang);
    this.translate.use(lang).subscribe({
      next: () => {
        console.log('Language switched to:', lang);
      },
      error: (error) => {
        console.error('Error switching language:', error);
      },
    });
  }

  ngOnDestroy(): void {
    this.cleanupOrderStatusNotifications();
    this.cleanupNewPaidOrderNotifications();
  }
}
