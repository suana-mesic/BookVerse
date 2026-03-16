// country.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class CountriesApiService {
  private http = inject(HttpClient);
  private baseUrl = 'https://countriesnow.space/api/v0.1';

  getCountries(): Observable<string[]> {
    return this.http
      .get<any>(`${this.baseUrl}/countries/positions`)
      .pipe(map((res) => res.data.map((c: any) => c.name).sort()));
  }

  getCitiesByCountry(country: string): Observable<string[]> {
    return this.http
      .post<any>(`${this.baseUrl}/countries/cities`, { country })
      .pipe(map((res) => res.data.sort()));
  }
}
