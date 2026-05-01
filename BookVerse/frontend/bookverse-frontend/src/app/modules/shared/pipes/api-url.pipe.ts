import { Pipe, PipeTransform } from '@angular/core';
import { environment } from '../../../../environments/environment';

@Pipe({
  name: 'apiUrl',
  standalone: true,
})
export class ApiUrlPipe implements PipeTransform {
  transform(value: string | null | undefined): string {
    if (!value) return '';
    if (value.startsWith('http://') || value.startsWith('https://') || value.startsWith('data:')) return value;
    const base = environment.apiUrl.replace(/\/+$/, '');
    const path = value.startsWith('/') ? value : '/' + value;
    return base + path;
  }
}
