import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ListStoresRequest, ListStoresResponse } from './stores-api.model';
import { buildHttpParams } from '../../core/models/build-http-params';

@Injectable({
  providedIn: 'root'
})
export class StoresApiService {
  private readonly baseUrl = `${environment.apiUrl}/api/stores`;
  private http = inject(HttpClient);

  list(request?: ListStoresRequest): Observable<ListStoresResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;

    return this.http.get<ListStoresResponse>(this.baseUrl, {
      params,
    });
  }
}