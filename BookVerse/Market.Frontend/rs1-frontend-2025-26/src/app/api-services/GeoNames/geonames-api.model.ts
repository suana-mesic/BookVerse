import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GeonamesApiService {
  private http = inject(HttpClient);

  // getCities(): Observable<string[]> {
  //   return this.http
  //     .get<any>(
  //       'http://api.geonames.org/searchJSON?country=BA&featureClass=P&maxRows=1000&username=TVOJ_USERNAME',
  //     )
  //     .pipe(map((response) => response.geonames.map((x: any) => x.name).sort()));
  // }
}
