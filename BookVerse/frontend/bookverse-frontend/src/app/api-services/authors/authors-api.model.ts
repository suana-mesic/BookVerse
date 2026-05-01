import { Injectable } from '@angular/core';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { PageResult } from '../../core/models/paging/page-result';

@Injectable({
  providedIn: 'root',
})
export class AuthorsListRequest extends BasePagedQuery {
  search?: string | null = null;
  onlyEnabled?: boolean | null = null;
}

export interface ListAuthorsQueryDto {
  id: number;
  firstName: string;
  lastName: string;
  biography: string;
  country: string;
}

export type AuthorsListResponse = PageResult<ListAuthorsQueryDto>;

export type Author = {
  id: number;
  firstName: string;
  lastName: string;
};
