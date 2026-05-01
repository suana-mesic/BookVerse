import { Injectable, inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({ providedIn: 'root' })
export class DateFormatService {
  private translate = inject(TranslateService);

  private getLang(): string {
    return (
      this.translate.currentLang ||
      this.translate.defaultLang ||
      localStorage.getItem('lang') ||
      'bs'
    );
  }

  getDateFormat(): string {
    return this.getLang() === 'en' ? 'MM/dd/yyyy' : 'dd.MM.yyyy';
  }

  getTimeFormat(): string {
    return this.getLang() === 'en' ? '12h' : '24h';
  }

  getDateTimeFormat(): string {
    const dateFmt = this.getDateFormat();
    const timeFmt = this.getTimeFormat() === '24h' ? 'HH:mm' : 'hh:mm a';
    return `${dateFmt} ${timeFmt}`;
  }
}
