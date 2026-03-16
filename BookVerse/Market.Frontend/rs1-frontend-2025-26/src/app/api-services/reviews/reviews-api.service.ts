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

  //todo: izbrisati kasnije i dodati endpoint koji dohvata sve recenzije
  // getAllReviewsForBook(bookId?: number, userId?: number) {
  //   const url = `https://localhost:7260/Reviews?bookId=${bookId}`;
  //   return this.http.get<Array<ListReviewsForBookQueryDto>>(url);
  // }

  //Dohvati sve recenzije za neku knjigu, koristi se za prikaz knjiga u sekciji detalji knjige
  getAllReviewsForBook(
    bookId: number,
    request?: ListReviewsRequest,
  ): Observable<ListReviewsResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListReviewsResponse>(`${this.baseUrl}/${bookId}/all`, {
      params,
    });
  }

  //Recenzija za neku knjigu ali samo za trenutnog korisnika
  getReviewById(bookId: number): Observable<GetReviewsByIdQueryDto> {
    return this.http.get<GetReviewsByIdQueryDto>(`${this.baseUrl}/${bookId}`);
  }

  //Poziva se kada korisnik želi napisati novu recenziju
  createReview(command: CreateReviewCommand): Observable<void> {
    return this.http.post<void>(this.baseUrl, command);
  }

  //Poziva se kada korisnik želi urediti postojeću recenziju
  updateReview(bookId: number, command: UpdateReviewCommand): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${bookId}`, command);
  }

  deleteReview(bookId: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${bookId}`);
  }
}
