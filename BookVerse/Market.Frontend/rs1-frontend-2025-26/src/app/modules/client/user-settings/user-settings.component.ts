import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ToasterService } from '../../core/services/toaster.service';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { UsersApiService } from '../../../api-services/users/users-api.service';
import { GetMyProfileQueryDto } from '../../../api-services/users/users-api.model';

@Component({
  selector: 'app-user-settings',
  standalone: false,
  templateUrl: './user-settings.component.html',
  styleUrl: './user-settings.component.scss',
})
export class UserSettingsComponent implements OnInit, OnDestroy {
  theme: 'light' | 'dark' = 'light';
  orderStatusNotifications = true;
  language: 'bs' | 'en' = 'bs';
  twoFactorEnabled = false;

  private profileData: GetMyProfileQueryDto | null = null;

  private location = inject(Location);
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);
  private api = inject(UsersApiService);
  private langChangeSub!: Subscription;

  ngOnInit(): void {
    this.loadSettings();
    this.loadTwoFactor();
    this.langChangeSub = this.translate.onLangChange.subscribe((event) => {
      this.language = event.lang as 'bs' | 'en';
    });
  }

  loadSettings(): void {
    const saved = localStorage.getItem('userSettings');
    if (saved) {
      const settings = JSON.parse(saved);
      this.theme = settings.theme || 'light';
      this.orderStatusNotifications = settings.orderStatusNotifications ?? true;
      this.language = settings.language || 'bs';
    } else {
      const savedLang = localStorage.getItem('lang') as 'bs' | 'en' | null;
      if (savedLang === 'bs' || savedLang === 'en') {
        this.language = savedLang;
      }
    }
    this.applyTheme();
  }

  private loadTwoFactor(): void {
    this.api.getMyProfile().subscribe({
      next: (profile) => {
        this.profileData = profile;
        this.twoFactorEnabled = profile.twoFactorEnabled;
      },
    });
  }

  selectLanguage(lang: 'bs' | 'en'): void {
    this.language = lang;
    this.translate.use(lang);
    localStorage.setItem('lang', lang);
  }

  saveSettings(): void {
    const settings = {
      theme: this.theme,
      orderStatusNotifications: this.orderStatusNotifications,
      language: this.language,
    };
    localStorage.setItem('userSettings', JSON.stringify(settings));
    localStorage.setItem('lang', this.language);
    this.translate.use(this.language);
    this.applyTheme();

    if (this.profileData) {
      this.api.updateMyProfile({
        ...this.profileData,
        twoFactorEnabled: this.twoFactorEnabled,
      }).subscribe();
    }

    this.toaster.success(this.translate.instant('CLIENT.USER_SETTINGS.SUCCESS_SAVED'));
  }

  resetSettings(): void {
    this.theme = 'light';
    this.orderStatusNotifications = true;
    this.language = 'bs';
    this.twoFactorEnabled = false;
    this.saveSettings();
  }

  private applyTheme(): void {
    if (this.theme === 'dark') {
      document.body.classList.add('dark-theme');
    } else {
      document.body.classList.remove('dark-theme');
    }
  }

  goBack(): void {
    this.location.back();
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
  }
}
