import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { CouponDto, CreateCouponCommand, FormFieldConfig, ListCouponsQueryDto } from './coupons-api.model';
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

  //used for creating a dynamic form for coupon input
  getFormConfig(couponType: 'percent' | 'amount'): Observable<FormFieldConfig[]> {
  return this.http.get<FormFieldConfig[]>(`${this.baseUrl}/form-config/${couponType}`);
  }

  createCoupon(command: CreateCouponCommand): Observable<number> {
  return this.http.post<number>(this.baseUrl, command);
  }
}