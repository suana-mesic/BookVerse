import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit } from '@angular/core';
import { Book } from '../models/book.type';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  http = inject(HttpClient);
  getBooksFromApi() {
    const url = 'https://localhost:7260/Books';
    return this.http.get<Array<Book>>(url);
  }
}
