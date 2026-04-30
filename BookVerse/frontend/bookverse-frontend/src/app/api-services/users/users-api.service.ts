import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import {
  GetMyProfileQueryDto,
  GetUserByIdQueryDto,
  ListUsersQueryDto,
  ListUsersRequest,
  ListUsersResponse,
  UpdateMyProfileCommand,
  UpdateUserRolesCommand,
  UserAddressDto,
} from './users-api.model';
import { buildHttpParams } from '../../core/models/build-http-params';

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

  //Returns all IDs and Full Names used in the statistics module
  getAllUserNames(): Observable<ListUsersQueryDto[]> {
    return this.http.get<ListUsersQueryDto[]>(`${this.baseUrl}/all-user-names`);
  }

  //Returns all users for table display in the admin panel
  list(request?: ListUsersRequest): Observable<ListUsersResponse> {
    const params = request ? buildHttpParams(request as any) : undefined;
    return this.http.get<ListUsersResponse>(`${this.baseUrl}/all-users`, { params });
  }

  getById(id: number): Observable<GetUserByIdQueryDto> {
    return this.http.get<GetUserByIdQueryDto>(`${this.baseUrl}/${id}`);
  }

  updateRoles(id: number, payload: UpdateUserRolesCommand): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}/roles`, payload);
  }
}
