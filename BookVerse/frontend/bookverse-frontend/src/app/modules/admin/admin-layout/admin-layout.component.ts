import { Component, computed, inject, OnDestroy, OnInit, signal } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Subscription } from 'rxjs';
import { SignalRService } from '../../../core/services/signal-r/signal-r.service';
import { AuthFacadeService } from '../../../core/services/auth/auth-facade.service';

@Component({
  selector: 'app-admin-layout',
  standalone: false,
  templateUrl: './admin-layout.component.html',
  styleUrl: './admin-layout.component.scss',
})
export class AdminLayoutComponent implements OnInit, OnDestroy {
  signalR = inject(SignalRService);
  private translate = inject(TranslateService);
  auth = inject(AuthFacadeService);

  private readonly allNavSections = [
    {
      id: 'system',
      label: 'ADMIN_PANEL.MENU.DATA_VISUALIZATION',
      items: [
        {
          route: '/admin/statistics',
          icon: 'bar_chart',
          label: 'ADMIN_PANEL.MENU.DASHBOARD',
          roles: ['admin', 'manager'],
        },
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
          roles: ['admin', 'manager', 'employee'],
        },
        {
          route: '/admin/products',
          icon: 'book',
          label: 'ADMIN_PANEL.MENU.BOOKS',
          roles: ['admin', 'manager', 'employee'],
        },
        {
          route: '/admin/coupons',
          icon: 'local_activity',
          label: 'ADMIN_PANEL.MENU.COUPONS',
          roles: ['admin', 'manager'],
        },
      ],
    },
    {
      id: 'orders',
      label: 'ADMIN_PANEL.MENU.RESOURCE_MANAGEMENT',
      items: [
        {
          route: '/admin/orders',
          icon: 'shopping_cart',
          label: 'ADMIN_PANEL.MENU.ORDERS',
          roles: ['admin', 'manager', 'employee'],
        },
        {
          route: '/admin/inventory',
          icon: 'inventory',
          label: 'ADMIN_PANEL.MENU.INVENTORY',
          roles: ['admin', 'manager', 'employee'],
        },
        {
          route: '/admin/users',
          icon: 'account_circle',
          label: 'ADMIN_PANEL.MENU.USERS',
          roles: ['admin'],
        },
      ],
    },
    {
      id: 'settings',
      label: 'ADMIN_PANEL.MENU.SETTINGS',
      items: [
        {
          route: '/admin/settings',
          icon: 'settings',
          label: 'ADMIN_PANEL.SETTINGS',
          roles: ['admin', 'manager', 'employee'],
        },
      ],
    },
  ];

  private sectionOrder = signal<string[]>([]);

  //Here defined what user can see
  navSections = computed(() => {
    const user = this.auth.currentUser();
    const order = this.sectionOrder();

    const activeRoles: string[] = [];
    if (user?.isAdmin) activeRoles.push('admin');
    if (user?.isManager) activeRoles.push('manager');
    if (user?.isEmployee) activeRoles.push('employee');

    const filtered = this.allNavSections
      .map((section) => ({
        //spread operator - copies each section
        //role - that the original sections do not mutate
        ...section,
        items: section.items.filter((item) =>
          item.roles.some((role) => activeRoles.includes(role)),
        ),
      }))
      .filter((section) => section.items.length > 0);

    if (order.length > 0) {
      filtered.sort((a, b) => order.indexOf(a.id) - order.indexOf(b.id));
    }
    return filtered;
  });

  currentLang: string;

  languages = [
    { code: 'bs', key: 'CLIENT.HEADER.LANG_BS', flag: '🇧🇦' },
    { code: 'en', key: 'CLIENT.HEADER.LANG_EN', flag: '🇬🇧' },
  ];

  constructor() {
    this.currentLang = this.translate.currentLang || 'bs';
  }

  private langChangeSub?: Subscription;

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

    const saved = localStorage.getItem('navSectionsOrder');
    if (saved) {
      this.sectionOrder.set(JSON.parse(saved));
    }

    this.langChangeSub = this.translate.onLangChange.subscribe((event) => {
      this.currentLang = event.lang;
    });
  }

  ngOnDestroy(): void {
    document.body.classList.remove('dark-theme');
    this.langChangeSub?.unsubscribe();
  }

  switchLanguage(langCode: string): void {
    this.currentLang = langCode;
    localStorage.setItem('lang', langCode);

    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const settings = JSON.parse(saved);
      settings.language = langCode;
      localStorage.setItem('adminSettings', JSON.stringify(settings));
    }

    this.translate.use(langCode).subscribe();
  }

  getCurrentLanguage() {
    return this.languages.find((lang) => lang.code === this.currentLang);
  }

  onSectionDrop(event: CdkDragDrop<any[]>) {
    const sections = [...this.navSections()];
    moveItemInArray(sections, event.previousIndex, event.currentIndex);
    const newOrder = sections.map((s) => s.id);
    this.sectionOrder.set(newOrder);
    localStorage.setItem('navSectionsOrder', JSON.stringify(newOrder));
  }

  clearNotifications(): void {
    this.signalR.clearStaffNotifications();
  }

  markAllAsRead(): void {
    this.signalR.markStaffNotificationsRead();
  }
}
