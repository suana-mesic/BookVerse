import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
@Injectable({
  providedIn: 'root',
})
export class ReportsApiServices {
  private readonly baseUrl = `${environment.apiUrl}/Reports`;
  private http = inject(HttpClient);

  generateOrdersReport(
    dateFrom: Date,
    dateTo: Date,
    userId?: number,
    orderId?: number,
  ): Observable<Blob> {
    const params: any = {
      dateFrom: dateFrom.toISOString(),
      dateTo: dateTo.toISOString(),
      _t: new Date().getTime(),
    };

    if (userId) params.userId = userId;
    if (orderId) params.orderId = orderId;

    return this.http.get(`${this.baseUrl}/orders-report`, {
      params,
      responseType: 'blob',
    });
  }

  generateBooksReport(dateFrom: Date, dateTo: Date, bookId?: number): Observable<Blob> {
    const params: any = {
      dateFrom: dateFrom.toISOString(),
      dateTo: dateTo.toISOString(),
      _t: new Date().getTime(),
    };

    if (bookId) params.bookId = bookId;

    return this.http.get(`${this.baseUrl}/books-report`, {
      params,
      responseType: 'blob',
    });
  }
}
