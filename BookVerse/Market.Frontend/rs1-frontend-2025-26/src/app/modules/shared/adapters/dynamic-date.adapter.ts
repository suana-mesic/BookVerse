import { Inject, Injectable, Optional } from '@angular/core';
import { NativeDateAdapter } from '@angular/material/core';
import { DateFormatService } from '../services/date-format.service';

@Injectable()
export class DynamicDateAdapter extends NativeDateAdapter {
  constructor(private dateFormatService: DateFormatService) {
    super('bs', null as any); // možeš promijeniti locale ako treba
  }

  override format(date: Date, displayFormat: any): string {
    const userFormat = this.dateFormatService.getDateFormat(); // npr. 'dd.MM.yyyy'
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const year = date.getFullYear();
    return userFormat.replace('dd', day).replace('MM', month).replace('yyyy', year.toString());
  }
}
