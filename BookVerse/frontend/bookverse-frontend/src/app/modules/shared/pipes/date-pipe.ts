import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'appDate',
  standalone: false,
})
export class AppDatePipe implements PipeTransform {
  constructor(private datePipe: DatePipe) {}

  transform(value: Date | string | null) {
    if (!value) return;

    const saved = localStorage.getItem('adminSettings');
    const settings = saved ? JSON.parse(saved) : {};

    const dateFormat = settings.dateFormat || 'dd.MM.yyyy';
    const timeFormat = settings.timeFormat === '12h' ? 'hh:mm a' : 'HH:mm';

    const fullFormat = `${dateFormat} ${timeFormat}`;
    return this.datePipe.transform(value, fullFormat) || '';
  }
}
