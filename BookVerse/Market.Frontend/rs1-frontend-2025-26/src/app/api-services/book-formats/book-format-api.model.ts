import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { PageResult } from '../../core/models/paging/page-result';

export class ListBookFormatsRequest extends BasePagedQuery {
  search?: string | null;
  onlyEnabled?: boolean | null;
}

export interface ListBookFormatsQueryDto {
  id: number;
  format: string;
  isDeleted: boolean;
}

export type ListBookFormatsResponse = PageResult<ListBookFormatsQueryDto>;