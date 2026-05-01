import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToasterService } from '../../../core/services/toaster.service';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-admin-settings',
  templateUrl: './admin-settings.component.html',
  styleUrls: ['./admin-settings.component.scss'],
  standalone: false,
})
export class AdminSettingsComponent implements OnInit, OnDestroy {
  private fb = inject(FormBuilder);

  settingsForm = this.fb.group({
    theme: this.fb.control<'light' | 'dark'>('light', Validators.required),
    defaultPageSize: this.fb.control<number>(20, [Validators.required, Validators.min(1)]),
    dateFormat: this.fb.control<string>('dd.MM.yyyy', Validators.required),
    timeFormat: this.fb.control<'24h' | '12h'>('24h', Validators.required),
    notificationsEnabled: this.fb.control<boolean>(true, Validators.required),
    soundEnabled: this.fb.control<boolean>(true, Validators.required),
    language: this.fb.control<'bs' | 'en'>('bs', Validators.required),
  });

  get theme(): string {
    return this.settingsForm.controls.theme.value ?? 'light';
  }
  set theme(value: 'light' | 'dark') {
    this.settingsForm.controls.theme.setValue(value);
  }

  get defaultPageSize(): number {
    return this.settingsForm.controls.defaultPageSize.value ?? 20;
  }
  set defaultPageSize(value: number) {
    this.settingsForm.controls.defaultPageSize.setValue(value);
  }

  get dateFormat(): string {
    return this.settingsForm.controls.dateFormat.value ?? 'dd.MM.yyyy';
  }
  set dateFormat(value: string) {
    this.settingsForm.controls.dateFormat.setValue(value);
  }

  get timeFormat(): '24h' | '12h' {
    return this.settingsForm.controls.timeFormat.value ?? '24h';
  }
  set timeFormat(value: '24h' | '12h') {
    this.settingsForm.controls.timeFormat.setValue(value);
  }

  get notificationsEnabled(): boolean {
    return !!this.settingsForm.controls.notificationsEnabled.value;
  }
  set notificationsEnabled(value: boolean) {
    this.settingsForm.controls.notificationsEnabled.setValue(value);
  }

  get soundEnabled(): boolean {
    return !!this.settingsForm.controls.soundEnabled.value;
  }
  set soundEnabled(value: boolean) {
    this.settingsForm.controls.soundEnabled.setValue(value);
  }

  get language(): 'bs' | 'en' {
    return this.settingsForm.controls.language.value ?? 'bs';
  }
  set language(value: 'bs' | 'en') {
    this.settingsForm.controls.language.setValue(value);
  }

  private toaster = inject(ToasterService);
  private translate = inject(TranslateService);
  private langChangeSub?: Subscription;

  ngOnInit() {
    this.loadSettings();
    this.langChangeSub = this.translate.onLangChange.subscribe((event) => {
      if (this.language !== event.lang) {
        this.settingsForm.controls.language.setValue(event.lang as 'bs' | 'en', { emitEvent: false });
      }
    });
  }

  ngOnDestroy(): void {
    this.langChangeSub?.unsubscribe();
  }

  loadSettings() {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const settings = JSON.parse(saved);
      this.theme = settings.theme || 'light';
      this.defaultPageSize = settings.defaultPageSize || 20;
      this.dateFormat = settings.dateFormat || 'dd.MM.yyyy';
      this.timeFormat = settings.timeFormat || '24h';
      this.notificationsEnabled = settings.notificationsEnabled ?? true;
      this.soundEnabled = settings.soundEnabled ?? true;
      this.language = settings.language || (localStorage.getItem('lang') as 'bs' | 'en') || 'bs';
      this.applyTheme();
    } else {
      const savedLang = localStorage.getItem('lang') as 'bs' | 'en' | null;
      if (savedLang === 'bs' || savedLang === 'en') {
        this.language = savedLang;
      }
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
      language: this.language,
    };
    localStorage.setItem('adminSettings', JSON.stringify(settings));
    localStorage.setItem('lang', this.language);
    this.translate.use(this.language);
    this.applyTheme();
    this.toaster.success(this.translate.instant('SETTINGS.DIALOGS.SUCCESS_SAVED'));
  }
  resetSettings() {
    this.theme = 'light';
    this.defaultPageSize = 20;
    this.dateFormat = 'dd.MM.yyyy';
    this.timeFormat = '24h';
    this.notificationsEnabled = true;
    this.soundEnabled = true;
    this.language = 'bs';
    this.saveSettings();
  }
  private applyTheme() {
    if (this.theme === 'dark') {
      document.body.classList.add('dark-theme');
    } else {
      document.body.classList.remove('dark-theme');
    }
  }
}
