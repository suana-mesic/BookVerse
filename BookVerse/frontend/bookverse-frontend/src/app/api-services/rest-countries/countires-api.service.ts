import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map, catchError, of } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

@Injectable({ providedIn: 'root' })
export class CountriesApiService {
  private http = inject(HttpClient);
  private translate = inject(TranslateService);
  private failedCityCountries = new Set<string>([
    'AX', 'AS', 'AQ', 'BV', 'HM', 'GS', 'TF', 'IO',
    'CC', 'CX', 'NU', 'PN', 'TK', 'UM', 'WF', 'YT',
    'BL', 'MF', 'SX', 'BQ', 'AI', 'MS', 'VG', 'TC',
    'FK', 'NC', 'PF', 'TV', 'NR', 'PW', 'MH', 'FM',
    'KI', 'SH', 'EH', 'PM', 'NF', 'VA', 'GI',
  ]);

  private get lang(): string {
    const current = this.translate.currentLang ?? this.translate.defaultLang ?? 'en';
    const langMap: Record<string, string> = { bs: 'hrv' };
    return langMap[current] ?? current;
  }

  getCountries(): Observable<{ name: string; countryCode: string; nameBs: string }[]> {
    return this.http
      .get<any[]>(`https://restcountries.com/v3.1/all?fields=name,cca2,translations`)
      .pipe(
        map((res) =>
          res
            .filter((c: any) => !this.failedCityCountries.has(c.cca2))
            .map((c: any) => ({
              name: this.getTranslatedName(c), // for display (depends on language)
              nameBs: c.translations?.['hrv']?.common ?? c.name?.common ?? '', // always Bosnian/Croatian for database storage
              countryCode: c.cca2,
            }))
            .sort((a, b) => a.name.localeCompare(b.name)),
        ),
      );
  }

  private getTranslatedName(country: any): string {
    const lang = this.lang;
    return country.translations?.[lang]?.common ?? country.name?.common ?? '';
  }

  getCitiesByCountry(countryCode: string): Observable<string[]> {
    if (this.failedCityCountries.has(countryCode)) {
      return of<string[]>([]);
    }
    return this.http
      .post<{ data?: string[] }>(`https://countriesnow.space/api/v0.1/countries/cities`, {
        iso2: countryCode,
      })
      .pipe(
        map((res) => (res.data ?? []).slice().sort((a, b) => a.localeCompare(b))),
        catchError(() => {
          this.failedCityCountries.add(countryCode);
          return of<string[]>([]);
        }),
      );
  }
}
