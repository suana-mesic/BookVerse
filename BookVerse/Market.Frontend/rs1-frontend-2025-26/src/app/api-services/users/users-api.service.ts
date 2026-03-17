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

  //Vraća sve ID-eve i Full Names u modulu za statistiku
  getAllUserNames(): Observable<ListUsersQueryDto[]> {
    return this.http.get<ListUsersQueryDto[]>(`${this.baseUrl}/all-user-names`);
  }

  //Vraća sve korisnike za tabelarni prikaz u admin panelu
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
