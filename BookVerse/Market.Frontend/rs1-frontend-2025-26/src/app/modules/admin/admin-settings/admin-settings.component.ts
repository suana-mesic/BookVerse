import { Component, inject, OnDestroy } from '@angular/core';
import { ToasterService } from '../../core/services/toaster.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-admin-settings',
  templateUrl: './admin-settings.component.html',
  styleUrls: ['./admin-settings.component.scss'],
  standalone: false,
})
export class AdminSettingsComponent implements OnDestroy {
  theme = 'light';
  defaultPageSize = 25;
  dateFormat = 'dd.MM.yyyy';
  timeFormat = '24h';
  notificationsEnabled = true;
  soundEnabled = true;
  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);

  ngOnInit() {
    this.loadSettings();
  }
  loadSettings() {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const settings = JSON.parse(saved);
      this.theme = settings.theme || 'light';
      this.defaultPageSize = settings.defaultPageSize || 25;
      this.dateFormat = settings.dateFormat || 'dd.MM.yyyy';
      this.timeFormat = settings.timeFormat || '24h';
      this.notificationsEnabled = settings.notificationsEnabled ?? true;
      this.soundEnabled = settings.soundEnabled ?? true;
      this.applyTheme();
    }
  }
  saveSettings() {
    const settings = {
      theme: this.theme,
      defaultPageSize: this.defaultPageSize,
      dateFormat: this.dateFormat,
      timeFormat: this.timeFormat,
      notificationsEnabled: this.notificationsEnabled,
      soundEnabled: this.soundEnabled,
    };
    localStorage.setItem('adminSettings', JSON.stringify(settings));
    this.applyTheme();
    this.toaster.success(this.translate.instant('SETTINGS.DIALOGS.SUCCESS_SAVED'));
  }
  resetSettings() {
    this.theme = 'light';
    this.defaultPageSize = 25;
    this.dateFormat = 'dd.MM.yyyy';
    this.timeFormat = '24h';
    this.notificationsEnabled = true;
    this.soundEnabled = true;
    this.saveSettings();
  }
  private applyTheme() {
    if (this.theme === 'dark') {
      document.body.classList.add('dark-theme');
    } else {
      document.body.classList.remove('dark-theme');
    }
  }
  onThemeChange() {
    this.applyTheme();
  }
  onPageSizeChange() {}
  onDateFormatChange() {}
  onTimeFormatChange() {}
  onNotificationsChange() {}
  onSoundChange() {}

  ngOnDestroy(): void {}
}
