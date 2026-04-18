import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';

@Injectable({ providedIn: 'root' })
export class CountriesApiService {
  private http = inject(HttpClient);
  private translate = inject(TranslateService);

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
            .map((c: any) => ({
              name: this.getTranslatedName(c), // za prikaz (ovisno o jeziku)
              nameBs: c.translations?.['hrv']?.common ?? c.name?.common ?? '', // uvijek bosanski/hrvatski za bazu
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
    return this.http
      .post<any>(`https://countriesnow.space/api/v0.1/countries/cities`, {
        iso2: countryCode,
      })
      .pipe(map((res) => (res.data as string[]).sort((a, b) => a.localeCompare(b))));
  }
}
