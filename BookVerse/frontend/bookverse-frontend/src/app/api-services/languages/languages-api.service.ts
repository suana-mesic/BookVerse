import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { ListLanguagesQueryDto, ListLanguagesRequest } from './languages-api.model';

@Injectable({ providedIn: 'root' })
export class LanguagesApiService {
  private readonly baseUrl = `${environment.apiUrl}/Languages`;
  private http = inject(HttpClient);

  list(request?: ListLanguagesRequest): Observable<ListLanguagesQueryDto[]> {
    let params = new HttpParams();
    if (request?.language) params = params.set('language', request.language);
    return this.http.get<ListLanguagesQueryDto[]>(this.baseUrl, { params });
  }
}
