import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ListPublishersRequest, ListPublishersResponse } from './publishers-api.model';
import { buildHttpParams } from '../../core/models/build-http-params';

@Injectable({
  providedIn: 'root',
})
export class PublishersService {
  private readonly baseUrl = `${environment.apiUrl}/api/publishers`;
  private http = inject(HttpClient);

  list(request?: ListPublishersRequest): Observable<ListPublishersResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;
    return this.http.get<ListPublishersResponse>(this.baseUrl, { params });
  }
}
