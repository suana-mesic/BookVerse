import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import {
  GetCategoriesPopularityQueryDto,
  GetDashboardCardSummaryDto,
  GetMonthlyOrdersCountQueryDto,
  GetMonthlyRevenueQueryDto,
  GetRevenueByMonthAndCategoryQueryDto,
  GetShippersOrdersQueryDto,
  GetTopFiveBooksQueryDto,
} from './statistics-api.model';

@Injectable({
  providedIn: 'root',
})
export class StatisticsApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/statistics`;
  private http = inject(HttpClient);

  getMonthlyRevenue(): Observable<GetMonthlyRevenueQueryDto[]> {
    return this.http.get<GetMonthlyRevenueQueryDto[]>(`${this.baseUrl}/monthly-revenue`);
  }

  getMonthlyOrdersCount(): Observable<GetMonthlyOrdersCountQueryDto[]> {
    return this.http.get<GetMonthlyOrdersCountQueryDto[]>(`${this.baseUrl}/monthly-orders-count`);
  }

  getTop5Books(): Observable<GetTopFiveBooksQueryDto[]> {
    return this.http.get<GetTopFiveBooksQueryDto[]>(`${this.baseUrl}/top-5-books`);
  }

  getShippersOrdersQuery(): Observable<GetShippersOrdersQueryDto[]> {
    return this.http.get<GetShippersOrdersQueryDto[]>(`${this.baseUrl}/shipper-orders-count`);
  }

  getCategoriesPopularity(language?: string): Observable<GetCategoriesPopularityQueryDto[]> {
    const params = language ? new HttpParams().set('language', language) : undefined;
    return this.http.get<GetCategoriesPopularityQueryDto[]>(
      `${this.baseUrl}/categories-popularity`,
      { params },
    );
  }

  getRevenueByMonthAndCategory(language?: string): Observable<GetRevenueByMonthAndCategoryQueryDto[]> {
    const params = language ? new HttpParams().set('language', language) : undefined;
    return this.http.get<GetRevenueByMonthAndCategoryQueryDto[]>(
      `${this.baseUrl}/revenue-by-month-and-category`,
      { params },
    );
  }

  getDashboardCardSummary(): Observable<GetDashboardCardSummaryDto> {
    return this.http.get<GetDashboardCardSummaryDto>(`${this.baseUrl}/dashboard-card-summary`);
  }
}
