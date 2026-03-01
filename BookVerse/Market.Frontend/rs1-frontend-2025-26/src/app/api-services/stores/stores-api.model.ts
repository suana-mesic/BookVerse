import { BasePagedQuery } from "../../core/models/paging/base-paged-query";
import { PageResult } from "../../core/models/paging/page-result";

export interface ListStoresQueryDto {
  id: number;
  storeName: string;
  city: string;
  line1: string;
  phone: string;
  openingHours: string;
}

export class ListStoresRequest extends BasePagedQuery {
  search?: string | null;
  onlyEnabled?: boolean | null;
}

export type ListStoresResponse = PageResult<ListStoresQueryDto>;
