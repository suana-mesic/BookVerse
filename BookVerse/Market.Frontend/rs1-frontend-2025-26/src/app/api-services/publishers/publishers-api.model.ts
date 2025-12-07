import { Injectable } from '@angular/core';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { PageResult } from '../../core/models/paging/page-result';

@Injectable({
  providedIn: 'root',
})
export class ListPublishersRequest extends BasePagedQuery {
  search?: string | null;
  onlyEnabled?: boolean | null;
}

export interface ListPublishersQueryDto {
  id: number;
  name: string;
  city: string;
  country: string;
}


export type ListPublishersResponse = PageResult<ListPublishersQueryDto>;