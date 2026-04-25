import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Categories } from './book/Categories';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  http = inject(HttpClient);
  page = signal(1);
  getCategoriesFromApi(language?: string): Observable<Categories[]> {
    const url = `https://localhost:7260/Categories`;
    let params = new HttpParams();
    if (language) {
      params = params.set('Language', language);
    }
    return this.http.get<Categories[]>(url, { params });
  }
}
