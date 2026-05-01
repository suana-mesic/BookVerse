import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  CreateReviewCommand,
  GetReviewsByIdQueryDto,
  ListReviewsForBookQueryDto,
  ListReviewsRequest,
  ListReviewsResponse,
  UpdateReviewCommand,
} from './reviews-api.model';
import { buildHttpParams } from '../../core/models/build-http-params';

@Injectable({
  providedIn: 'root',
})
export class ReviewsApiService {
  private readonly baseUrl = `${environment.apiUrl}/Reviews`;
  private http = inject(HttpClient);

  //todo: delete later and add an endpoint that fetches all reviews
  // getAllReviewsForBook(bookId?: number, userId?: number) {
  //   const url = `https://localhost:7260/Reviews?bookId=${bookId}`;
  //   return this.http.get<Array<ListReviewsForBookQueryDto>>(url);
  // }

  //Fetch all reviews for a book, used for displaying books in the book details section
  getAllReviewsForBook(
    bookId: number,
    request?: ListReviewsRequest,
  ): Observable<ListReviewsResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListReviewsResponse>(`${this.baseUrl}/${bookId}/all`, {
      params,
    });
  }

  //Review for a book but only for the current user
  getReviewById(bookId: number): Observable<GetReviewsByIdQueryDto> {
    return this.http.get<GetReviewsByIdQueryDto>(`${this.baseUrl}/${bookId}`);
  }

  //Called when the user wants to write a new review
  createReview(command: CreateReviewCommand): Observable<void> {
    return this.http.post<void>(this.baseUrl, command);
  }

  //Called when the user wants to edit an existing review
  updateReview(bookId: number, command: UpdateReviewCommand): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${bookId}`, command);
  }

  deleteReview(bookId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${bookId}`);
  }
}
