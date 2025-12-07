import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Categories } from './book/Categories';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  http = inject(HttpClient);
  page = signal(1);
  getCategoriesFromApi() {
    const url = `https://localhost:7260/Categories`;
    console.log(url);
    return this.http.get<Array<Categories>>(url);
  }
}
