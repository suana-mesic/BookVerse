import { Component, OnDestroy, OnInit, effect, inject, signal, untracked } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import {
  SignalRService,
  OrderStatusNotification,
  OrderNotification,
} from './core/services/signal-r/signal-r.service';
import { AuthFacadeService } from './core/services/auth/auth-facade.service';
import { OrderStatusHelper } from './api-services/orders/order-status.helper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit, OnDestroy {
  protected readonly title = signal('bookverse-frontend');
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
        console.log(this.translate.instant('DEBUG.TRANSLATIONS_LOADED'), savedLang);
        console.log(this.translate.instant('DEBUG.AVAILABLE_KEYS'), Object.keys(translations));
      },
      error: (error) => {
        console.error(this.translate.instant('DEBUG.ERROR_LOADING_TRANSLATIONS'), error);
        console.error(this.translate.instant('DEBUG.CHECK_TRANSLATION_FILE', { lang: savedLang }));
      },
    });

    effect(() => {
      const isAuth = this.auth.isAuthenticated();
      const user = this.auth.currentUser();
      if (isAuth) {
        untracked(() => {
          const isStaff = !!(user?.isAdmin || user?.isManager || user?.isEmployee);
          const key = isStaff ? 'adminSettings' : 'userSettings';
          const saved = localStorage.getItem(key);

          // Restores theme and language based on the panel the user logs into.
          // If the user previously chose dark theme, it is restored on next login.
          // On logout it resets to light. The same applies to the admin panel.
          if (saved) {
            const settings = JSON.parse(saved);
            if (settings.theme === 'dark') {
              document.body.classList.add('dark-theme');
            } else {
              document.body.classList.remove('dark-theme');
            }
            if (settings.language) {
              this.translate.use(settings.language);
            }
          }

          const token = this.auth.getAccessToken();
          if (!token) return;

          //User connection to SignalR Hub
          if (!this.orderStatusSub) {
            this.signalR.startUserConnection(token);
            this.subscribeToOrderStatusNotifications();
          }

          //Staff connection to SignalR Hub
          if (isStaff && !this.newPaidOrderSub) {
            this.signalR.startStaffConnection(token);
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
    if (this.auth.isAuthenticated()) {
      const user = this.auth.currentUser();
      const isStaff = !!(user?.isAdmin || user?.isManager || user?.isEmployee);
      const key = isStaff ? 'adminSettings' : 'userSettings';
      const saved = localStorage.getItem(key);
      if (saved) {
        const settings = JSON.parse(saved);
        if (settings.theme === 'dark') {
          document.body.classList.add('dark-theme');
        }
      }
    } else {
      document.body.classList.remove('dark-theme');
    }

    this.translate.get('BOOKS.TITLE').subscribe((res: string) => {
      console.log(this.translate.instant('DEBUG.TRANSLATION_FOR_BOOKS_TITLE'), res);
      if (res === 'BOOKS.TITLE') {
        console.error(this.translate.instant('DEBUG.TRANSLATION_NOT_WORKING'));
        console.error(this.translate.instant('DEBUG.POSSIBLE_CAUSES'));
        console.error(this.translate.instant('DEBUG.CAUSE_MISSING_FOLDER'));
        console.error(this.translate.instant('DEBUG.CAUSE_JSON_ERRORS'));
        console.error(this.translate.instant('DEBUG.CAUSE_SERVICE_NOT_INITIALIZED'));
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

        this.signalR.addStaffNotification(notification);

        if (settings.soundEnabled !== false) {
          const audio = new Audio('/sounds/pixel_notification.mp3');
          audio
            .play()
            .catch((err) => console.warn(this.translate.instant('DEBUG.AUDIO_PLAY_FAILED'), err));
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
        console.log(this.translate.instant('DEBUG.LANGUAGE_SWITCHED'), lang);
      },
      error: (error) => {
        console.error(this.translate.instant('DEBUG.ERROR_SWITCHING_LANGUAGE'), error);
      },
    });
  }

  ngOnDestroy(): void {
    this.cleanupOrderStatusNotifications();
    this.cleanupNewPaidOrderNotifications();
  }
}
