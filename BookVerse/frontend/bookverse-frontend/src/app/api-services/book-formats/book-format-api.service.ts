import { inject, Injectable } from '@angular/core';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { buildHttpParams } from '../../core/models/build-http-params';
import { Observable } from 'rxjs';
import { ListBookFormatsRequest, ListBookFormatsResponse } from './book-format-api.model';

@Injectable({
  providedIn: 'root',
})
export class BookFormatApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/bookformats`;
  private http = inject(HttpClient);


  list(request?: ListBookFormatsRequest): Observable<ListBookFormatsResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListBookFormatsResponse>(this.baseUrl, {
      params,
    });
  }


}
