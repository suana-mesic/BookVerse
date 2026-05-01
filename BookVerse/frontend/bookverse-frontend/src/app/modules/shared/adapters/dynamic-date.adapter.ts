import { Injectable } from '@angular/core';
import { NativeDateAdapter } from '@angular/material/core';
import { TranslateService } from '@ngx-translate/core';
import { DateFormatService } from '../services/date-format.service';

@Injectable()
export class DynamicDateAdapter extends NativeDateAdapter {
  constructor(
    private dateFormatService: DateFormatService,
    private translate: TranslateService,
  ) {
    const initialLang = translate.currentLang || translate.defaultLang || localStorage.getItem('lang') || 'bs';
    super(initialLang === 'en' ? 'en-US' : 'bs', null as any);

    this.translate.onLangChange.subscribe((event) => {
      this.setLocale(event.lang === 'en' ? 'en-US' : 'bs');
    });
  }

  override format(date: Date, displayFormat: any): string {
    const userFormat = this.dateFormatService.getDateFormat();
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    return userFormat.replace('dd', day).replace('MM', month).replace('yyyy', year.toString());
  }

  override parse(value: any): Date | null {
    if (typeof value !== 'string' || !value.trim()) return null;
    const userFormat = this.dateFormatService.getDateFormat();
    const separator = userFormat.includes('/') ? '/' : '.';
    const parts = value.split(separator);
    if (parts.length !== 3) return null;

    const tokens = userFormat.split(separator);
    let day = 0, month = 0, year = 0;
    for (let i = 0; i < tokens.length; i++) {
      const num = parseInt(parts[i], 10);
      if (isNaN(num)) return null;
      if (tokens[i].startsWith('d')) day = num;
      else if (tokens[i].startsWith('M')) month = num;
      else if (tokens[i].startsWith('y')) year = num;
    }

    if (!day || !month || !year) return null;
    const date = new Date(year, month - 1, day);
    return isNaN(date.getTime()) ? null : date;
  }
}
