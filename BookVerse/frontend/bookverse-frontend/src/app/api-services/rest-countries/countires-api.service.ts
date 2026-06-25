import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map, catchError, of, forkJoin, switchMap } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class CountriesApiService {
  private http = inject(HttpClient);
  private translate = inject(TranslateService);
  private failedCityCountries = new Set<string>([
    'AX', 'AS', 'AQ', 'BV', 'HM', 'GS', 'TF', 'IO',
    'CC', 'CX', 'NU', 'PN', 'TK', 'UM', 'WF', 'YT',
    'BL', 'MF', 'SX', 'BQ', 'AI', 'MS', 'VG', 'VI', 'TC',
    'FK', 'NC', 'PF', 'TV', 'NR', 'PW', 'MH', 'FM',
    'KI', 'SH', 'EH', 'PM', 'NF', 'VA', 'GI',
    'GF', 'GP', 'MQ', 'RE', 'GL', 'FO', 'CK', 'GU',
    'MP', 'AW', 'CW', 'BM', 'KY', 'JE', 'GG', 'IM',
  ]);

  private readonly v5Url = environment.restCountries.apiUrl;
  private readonly v5Key = environment.restCountries.apiKey;
  private readonly pageSize = 100;

  private get lang(): string {
    const current = this.translate.currentLang ?? this.translate.defaultLang ?? 'en';
    const langMap: Record<string, string> = { bs: 'hrv' };
    return langMap[current] ?? current;
  }

  getCountries(): Observable<{ name: string; countryCode: string; nameBs: string }[]> {
    return this.fetchCountriesPage(0).pipe(
      switchMap((first) => {
        const objects = [...(first.data?.objects ?? [])];
        const total = first.data?.meta?.total ?? objects.length;
        const offsets: number[] = [];
        for (let o = this.pageSize; o < total; o += this.pageSize) {
          offsets.push(o);
        }
        if (offsets.length === 0) {
          return of(objects);
        }
        return forkJoin(offsets.map((o) => this.fetchCountriesPage(o))).pipe(
          map((pages) => objects.concat(...pages.map((p) => p.data?.objects ?? []))),
        );
      }),
      map((objects) =>
        objects
          .filter((c: any) => !this.failedCityCountries.has(c.codes?.alpha_2))
          .map((c: any) => ({
            name: this.getTranslatedName(c),
            nameBs: c.names?.translations?.['hrv']?.common ?? c.names?.common ?? '',
            countryCode: c.codes?.alpha_2,
          }))
          .sort((a, b) => a.name.localeCompare(b.name)),
      ),
    );
  }

  private fetchCountriesPage(offset: number): Observable<any> {
    const params = new HttpParams()
      .set('api-key', this.v5Key)
      .set('response_fields', 'names,codes')
      .set('limit', this.pageSize)
      .set('offset', offset);
    return this.http.get<any>(this.v5Url, { params });
  }

  private getTranslatedName(country: any): string {
    const lang = this.lang;
    return country.names?.translations?.[lang]?.common ?? country.names?.common ?? '';
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
