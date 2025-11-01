import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit, signal } from '@angular/core';
import { Book } from '../shared/models/book.type';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  http = inject(HttpClient);
  page = signal(1);
  pageSize = signal(10);
  getBooksFromApi() {
    const url = `https://localhost:7260/Books?Paging.Page=${this.page()}&Paging.PageSize=${this.pageSize()}`;
    console.log(url);
    return this.http.get<Array<Book>>(url);
  }
}
