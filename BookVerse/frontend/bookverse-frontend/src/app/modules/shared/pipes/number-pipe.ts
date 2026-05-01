import { formatNumber } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'appNumber',
  standalone: true,
  pure: false,
})
export class AppNumberPipe implements PipeTransform {
  transform(value: number | null | undefined, digitsInfo: string = '1.2-2'): string {
    if (value === null || value === undefined) return '';
    const lang = localStorage.getItem('lang') ?? 'bs';
    const locale = lang === 'en' ? 'en-US' : 'bs';
    return formatNumber(value, locale, digitsInfo);
  }
}
