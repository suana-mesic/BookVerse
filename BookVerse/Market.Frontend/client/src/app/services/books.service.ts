import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit, signal } from '@angular/core';
import { CreateBookCommand } from '../shared/models/book/CreateBookCommand';
import { Observable } from 'rxjs';
import { Book } from '../shared/models/book/Book';

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

  apiUrl: string = '';
  createBook(book: CreateBookCommand): Observable<any> {
    return this.http.post('https://localhost:7260/Books', book);
  }
}
