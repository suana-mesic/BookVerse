import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { PageResult } from '../../core/models/paging/page-result';

export class ListBookFormatsRequest extends BasePagedQuery {
  search?: string | null;
  onlyEnabled?: boolean | null;
  language?: string | null;
}

// Response item for GET /api/bookformats (anonymous endpoint).
// isDeleted is intentionally not exposed - a public listing should never reveal internal state.
export interface ListBookFormatsQueryDto {
  id: number;
  format: string;
}

export type ListBookFormatsResponse = PageResult<ListBookFormatsQueryDto>;