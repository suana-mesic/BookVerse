import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { buildHttpParams } from '../../core/models/build-http-params';
import { CreateInventoryCommand, GetInventoryByIdQueryDto, ListInventoryRequest, ListInventoryResponse, UpdateInventoryCommand } from './inventory-api.model';

@Injectable({
  providedIn: 'root',
})
export class InventoryApiService {
  private readonly baseUrl = `${environment.apiUrl}/Inventory`;
  private http = inject(HttpClient);

    list(request?: ListInventoryRequest): Observable<ListInventoryResponse> {
      const params = request ? buildHttpParams(request as any) : undefined;
  
      return this.http.get<ListInventoryResponse>(this.baseUrl, {
        params,
      });
    }

    getById(storeId: number, bookId:number): Observable<GetInventoryByIdQueryDto> {
        return this.http.get<GetInventoryByIdQueryDto>(`${this.baseUrl}/store/${storeId}/book/${bookId}`);
    }
    
    create(payload: CreateInventoryCommand): Observable<void> {
        return this.http.post<void>(this.baseUrl, payload);
    }

    update(storeId: number, bookId:number, payload: UpdateInventoryCommand): Observable<void> {
        return this.http.put<void>(`${this.baseUrl}/store/${storeId}/book/${bookId}`, payload);
    }

    delete(storeId: number, bookId:number): Observable<void> {
        return this.http.delete<void>(`${this.baseUrl}/store/${storeId}/book/${bookId}`);
    }

}
