import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  GetMyProfileQueryDto,
  ListUsersQueryDto,
  UpdateMyProfileCommand,
  UserAddressDto,
} from './users-api.model';

@Injectable({
  providedIn: 'root',
})
export class UsersApiService {
  private readonly baseUrl = `${environment.apiUrl}/users`;
  private http = inject(HttpClient);

  getMyProfile(): Observable<GetMyProfileQueryDto> {
    return this.http.get<GetMyProfileQueryDto>(`${this.baseUrl}/my-profile`);
  }

  updateMyProfile(payload: UpdateMyProfileCommand): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/my-profile`, payload);
  }

  getUserAddress(): Observable<UserAddressDto> {
    return this.http.get<UserAddressDto>(`${this.baseUrl}/user-address`);
  }

  ListUsers(): Observable<ListUsersQueryDto[]> {
    return this.http.get<ListUsersQueryDto[]>(`${this.baseUrl}/all-users`);
  }
}
