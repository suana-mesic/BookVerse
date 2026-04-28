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
    language: string = 'bs',
  ): Observable<Blob> {
    const dateToEnd = new Date(dateTo);
    dateToEnd.setDate(dateToEnd.getDate() + 1);
    dateToEnd.setHours(2, 0, 0, 0);
    const params: any = {
      dateFrom: dateFrom.toISOString(),
      dateTo: dateToEnd.toISOString(),
      language,
      _t: new Date().getTime(),
    };

    if (userId) params.userId = userId;

    return this.http.get(`${this.baseUrl}/orders-report`, {
      params,
      responseType: 'blob',
    });
  }

  generateBooksReport(
    dateFrom: Date,
    dateTo: Date,
    bookId?: number,
    language: string = 'bs',
  ): Observable<Blob> {
    const dateToEnd = new Date(dateTo);
    dateToEnd.setDate(dateToEnd.getDate() + 1);
    dateToEnd.setHours(2, 0, 0, 0);
    const params: any = {
      dateFrom: dateFrom.toISOString(),
      dateTo: dateToEnd.toISOString(),
      language,
      _t: new Date().getTime(),
    };

    if (bookId) params.bookId = bookId;

    return this.http.get(`${this.baseUrl}/books-report`, {
      params,
      responseType: 'blob',
    });
  }
}
