import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Author, AuthorsListRequest, AuthorsListResponse } from './authors-api.model';
import { buildHttpParams } from '../../core/models/build-http-params';

@Injectable({
  providedIn: 'root',
})
export class AuthorsApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/authors`;
  private http = inject(HttpClient);

  list(request: AuthorsListRequest): Observable<AuthorsListResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;
    return this.http.get<AuthorsListResponse>(this.baseUrl, { params });
  }
  getAuthorFromApi(authorId: number) {
    return this.http.get<Author>(`${this.baseUrl}/${authorId}`);
  }
}
