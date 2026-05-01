import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  GetBookByIdQueryDto,
  CreateBookCommand,
  UpdateBookCommand,
  ListBooksRequest,
  ListBooksResponse,
  ListBooksForAutocompleteQueryDto,
  ListMyBooksResponse,
  Book,
} from './books-api.models';
import { buildHttpParams } from '../../core/models/build-http-params';
import { ListMyBooksRequest } from '../reviews/reviews-api.model';

@Injectable({
  providedIn: 'root',
})
export class BooksApiService {
  private readonly baseUrl = `${environment.apiUrl}/Books`;
  private http = inject(HttpClient);

  /**
   * GET /Book
   * List Book with optional query parameters.
   */
  list(request?: ListBooksRequest): Observable<ListBooksResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListBooksResponse>(this.baseUrl, {
      params,
    });
  }

  listMyBooks(request?: ListMyBooksRequest): Observable<ListMyBooksResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListMyBooksResponse>(`${this.baseUrl}/my-books`, {
      params,
    });
  }

  /**
   * GET /Books/{id}
   * Get a single product by ID.
   */
  getById(id: number): Observable<GetBookByIdQueryDto> {
    return this.http.get<GetBookByIdQueryDto>(`${this.baseUrl}/${id}`);
  }

  listBooksForAutocomplete(): Observable<ListBooksForAutocompleteQueryDto[]> {
    return this.http.get<ListBooksForAutocompleteQueryDto[]>(`${this.baseUrl}/dropdown`);
  }

  /**
   * POST /Books
   * Create a new product.
   * @returns ID of the newly created product
   */
  create(payload: CreateBookCommand): Observable<number> {
    return this.http.post<number>(this.baseUrl, payload);
  }

  /**
   * PUT /Books/{id}
   * Update an existing product.
   */
  update(id: number, payload: UpdateBookCommand): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, payload);
  }

  /**
   * DELETE /Books/{id}
   * Delete a product.
   */
  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

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
