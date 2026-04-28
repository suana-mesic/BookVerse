import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from './book/Book';
import { CreateBookCommand } from './book/CreateBookCommand';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class BooksService {
  http = inject(HttpClient);
  page = signal(1);
  pageSize = signal(10);

  getBooksFromApi(language: string) {
    const url = `https://localhost:7260/Books?Paging.Page=${this.page()}&Paging.PageSize=${this.pageSize()}&Language=${language}`;
    //console.log(url);
    return this.http.get<Array<Book>>(url);
  }

  getBookDetailsFromApi(bookId: string, language: string = 'bs') {
    const url = `https://localhost:7260/Books/${bookId}?language=${language}`;
    //console.log(url);
    return this.http.get<Array<Book>>(url);
  }

  apiUrl: string = '';
  createBook(book: CreateBookCommand): Observable<any> {
    return this.http.post('https://localhost:7260/Books', book);
  }
}
