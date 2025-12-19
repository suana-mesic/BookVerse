import { HttpClient } from '@angular/common/http';
import { inject, Injectable, OnInit, signal } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from './book/Book';
import { CreateBookCommand } from './book/CreateBookCommand';
import { Review } from './book/Review';

@Injectable({
  providedIn: 'root',
})
export class ReviewsService {
  http = inject(HttpClient);

  getReviewsByBookIdFromApi(bookId?: number, userId?: number) {
    const url = `https://localhost:7260/Reviews?bookId=${bookId}`;
    console.log(url);
    return this.http.get<Array<Review>>(url);
  }
}
