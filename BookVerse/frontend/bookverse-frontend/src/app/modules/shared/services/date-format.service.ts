import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class DateFormatService {
  getDateFormat(): string {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const settings = JSON.parse(saved);
      return settings.dateFormat || 'dd.MM.yyyy';
    }
    return 'dd.MM.yyyy';
  }

  getTimeFormat(): string {
    const saved = localStorage.getItem('adminSettings');
    if (saved) {
      const settings = JSON.parse(saved);
      return settings.timeFormat || '24h';
    }
    return '24h';
  }

  getDateTimeFormat(): string {
    const dateFmt = this.getDateFormat();
    const timeFmt = this.getTimeFormat() === '24h' ? 'HH:mm' : 'hh:mm a';
    return `${dateFmt} ${timeFmt}`;
  }
}
