import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { CouponDto, ListCouponsQueryDto } from './coupons-api.model';
import { buildHttpParams } from '../../core/models/build-http-params';

@Injectable({
  providedIn: 'root'
})
export class CouponsApiService {
  private readonly baseUrl = `${environment.apiUrl}/coupons`;
  private http = inject(HttpClient);

  
validateCoupon(code: string): Observable<CouponDto> {
  return this.http.get<CouponDto>(`${this.baseUrl}/validate-coupon/${code}`);
}

getAllCoupons(): Observable<ListCouponsQueryDto[]> {
    return this.http.get<ListCouponsQueryDto[]>(this.baseUrl);
  }
}