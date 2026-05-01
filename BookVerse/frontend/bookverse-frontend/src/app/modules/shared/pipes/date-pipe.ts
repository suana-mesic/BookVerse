import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { DateFormatService } from '../services/date-format.service';

@Pipe({
  name: 'appDate',
  standalone: false,
  pure: false,
})
export class AppDatePipe implements PipeTransform {
  constructor(private datePipe: DatePipe, private dateFormatService: DateFormatService) {}

  transform(value: Date | string | null, includeTime: boolean = true, timezone?: string): string {
    if (!value) return '';
    const dateFormat = this.dateFormatService.getDateFormat();
    if (!includeTime) return this.datePipe.transform(value, dateFormat, timezone) || '';

    if (this.dateFormatService.getTimeFormat() === '24h') {
      return this.datePipe.transform(value, `${dateFormat} HH:mm`, timezone) || '';
    }

    const datePart = this.datePipe.transform(value, dateFormat, timezone) || '';
    const timePart = this.datePipe.transform(value, 'hh:mm', timezone) || '';
    const hour24 = parseInt(this.datePipe.transform(value, 'H', timezone) || '0', 10);
    const ampm = hour24 >= 12 ? 'PM' : 'AM';
    return `${datePart} ${timePart} ${ampm}`;
  }
}
