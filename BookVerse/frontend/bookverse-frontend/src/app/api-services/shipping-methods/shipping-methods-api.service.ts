import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ShippingMethodDto } from './shipping-methods-api.model';

@Injectable({
  providedIn: 'root'
})
export class ShippingMethodsApiService {
  private readonly baseUrl = `${environment.apiUrl}/shippingmethods`;
  private http = inject(HttpClient);

  getShippingMethods(language?: string): Observable<ShippingMethodDto[]> {
    const params = language ? { language } : undefined;
    return this.http.get<ShippingMethodDto[]>(this.baseUrl, { params });
  }
}