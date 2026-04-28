import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  ListCartDto,
  CreateCartItemRequest,
  UpdateCartItemRequest,
  SaveForLaterRequest,
  DeleteCartItemRequest,
} from './cart-api.model';

@Injectable({
  providedIn: 'root',
})
export class CartApiService {
  private readonly baseUrl = `${environment.apiUrl}/cart`;

  constructor(private http: HttpClient) {}

  getCart(language?: string): Observable<ListCartDto> {
    let params = new HttpParams();
    if (language) params = params.set('language', language);
    return this.http.get<ListCartDto>(this.baseUrl, { params });
  }

  addToCart(request: CreateCartItemRequest): Observable<string> {
    return this.http.post(this.baseUrl, request, { responseType: 'text' });
  }

  updateQuantity(request: UpdateCartItemRequest): Observable<string> {
    return this.http.put(`${this.baseUrl}/quantity`, request, { responseType: 'text' });
  }

  saveForLater(request: SaveForLaterRequest): Observable<string> {
    return this.http.put(`${this.baseUrl}/save-for-later`, request, { responseType: 'text' });
  }

  removeFromCart(request: DeleteCartItemRequest): Observable<string> {
    return this.http.delete(this.baseUrl, { body: request, responseType: 'text' });
  }
}
