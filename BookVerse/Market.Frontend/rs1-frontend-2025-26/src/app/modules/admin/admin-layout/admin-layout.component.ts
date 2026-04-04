import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import {
  OrderNotification,
  SignalRService,
} from '../../../core/services/signal-r/signal-r.service';
import { audit, Subscription } from 'rxjs';

@Component({
  selector: 'app-admin-layout',
  standalone: false,
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.scss',
})
export class AdminLayoutComponent implements OnInit, OnDestroy {
  notifications: OrderNotification[] = [];
  unreadCount = 0;
  private signalR = inject(SignalRService);
  private notificationSubscription: Subscription | null = null;

  navSections = [
    {
      id: 'system',
      label: 'ADMIN_PANEL.MENU.DATA_VISUALIZATION',
      items: [
        { route: '/admin/statistics', icon: 'bar_chart', label: 'ADMIN_PANEL.MENU.DASHBOARD' },
      ],
    },
    {
      id: 'catalog',
      label: 'ADMIN_PANEL.MENU.CATALOG',
      items: [
        {
          route: '/admin/product-categories',
          icon: 'category',
          label: 'ADMIN_PANEL.MENU.CATEGORIES',
        },
        { route: '/admin/products', icon: 'book', label: 'ADMIN_PANEL.MENU.BOOKS' },
        { route: '/admin/coupons', icon: 'local_activity', label: 'ADMIN_PANEL.MENU.COUPONS' },
      ],
    },
    {
      id: 'orders',
      label: 'ADMIN_PANEL.MENU.RESOURCE_MANAGEMENT',
      items: [
        { route: '/admin/orders', icon: 'shopping_cart', label: 'ADMIN_PANEL.MENU.ORDERS' },
        { route: '/admin/inventory', icon: 'inventory', label: 'ADMIN_PANEL.MENU.INVENTORY' },
        { route: '/admin/users', icon: 'account_circle', label: 'ADMIN_PANEL.MENU.USERS' },
      ],
    },
    {
      id: 'settings',
      label: 'ADMIN_PANEL.MENU.SETTINGS',
      items: [{ route: '/admin/settings', icon: 'settings', label: 'ADMIN_PANEL.SETTINGS' }],
    },
  ];

  ngOnInit(): void {
    const adminSettings = localStorage.getItem('adminSettings');
    const settings = adminSettings ? JSON.parse(adminSettings) : null;
    if (adminSettings) {
      if (settings.theme === 'dark') {
        document.body.classList.add('dark-theme');
      } else {
        document.body.classList.remove('dark-theme');
      }
    }

    const notificationsEnabled = settings?.notificationsEnabled ?? true;
    const soundEnabled = settings?.soundEnabled ?? true;

    if (notificationsEnabled) {
      const token = this.auth.getAccessToken();

      if (token) {
        this.signalR.startConnection(token);
        this.notificationSubscription = this.signalR.newPaidOrder$.subscribe(
          (notification: OrderNotification) => {
            this.notifications.unshift(notification);
            this.unreadCount++;

            if (soundEnabled) {
              const audio = new Audio('sounds/pixel_notification.mp3');
              audio.play().catch((err) => console.warn('Audio play failed: ', err));
            }
          },
        );
      }
    }

    const saved = localStorage.getItem('navSectionsOrder');
    if (saved) {
      const order = JSON.parse(saved);
      this.navSections.sort((a, b) => order.indexOf(a.id) - order.indexOf(b.id));
      //npr. ako je u localStorage bilo sačuvano
      //['orders', 'catalog', 'system']
      //a redoslijed u ovom fajlu je
      //['catalog', 'orders', 'system']

      //1. poziv
      //order.indexOf('catalog') = 1 - order.indexOf('orders') = 0 => rezultat=1, orders ide prije catalog

      //2. poziv
      //order.indexOf('catalog') = 1 - order.indexOf('system') = 2 => rezultat=-1, catalog ide prije system

      //3. poziv
      //order.indexOf('orders') = 0 - order.indexOf('system') = 2 => rezultat=-2, orders ide prije system

      //Zaključak: orders catalog system
    }
  }

  private translate = inject(TranslateService);
  auth = inject(AuthFacadeService);

  currentLang: string;

  languages = [
    { code: 'bs', name: 'Bosanski', flag: '🇧🇦' },
    { code: 'en', name: 'English', flag: '🇬🇧' },
  ];

  constructor() {
    this.currentLang = this.translate.currentLang || 'bs';
  }

  ngOnDestroy(): void {
    document.body.classList.remove('dark-theme');
    this.signalR.stopConnection();
    this.notificationSubscription?.unsubscribe();
  }

  switchLanguage(langCode: string): void {
    this.currentLang = langCode;
    this.translate.use(langCode);
    localStorage.setItem('language', langCode);
  }

  getCurrentLanguage() {
    return this.languages.find((lang) => lang.code === this.currentLang);
  }

  onSectionDrop(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.navSections, event.previousIndex, event.currentIndex);
    localStorage.setItem('navSectionsOrder', JSON.stringify(this.navSections.map((s) => s.id)));
  }

  clearNotifications(): void {
    this.notifications = [];
    this.unreadCount = 0;
  }

  markAllAsRead(): void {
    this.unreadCount = 0;
  }
}
