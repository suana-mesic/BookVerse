import { PageResult } from '../../core/models/paging/page-result';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';

export class ListMyBooksRequest extends BasePagedQuery {
  search?: string | null;
  categoryIds?: number[];
  language?: string | null;

  constructor() {
    super();
    this.categoryIds = [];
  }
}

export interface GetReviewsByIdQueryDto {
  bookId: number;
  userId: number;
  rating: number;
  comment: string;
  datePosted: string;
  updatedAt?: string | null;
}

export interface CreateReviewCommand {
  bookId: number;
  rating: number;
  comment: string;
}

export interface UpdateReviewCommand {
  rating: number;
  comment: string;
}

export type ListReviewsForBookQueryDto = {
  id: number;
  bookId: number;
  userId: number;
  user: {
    firstName: string;
    lastName: string;
  };
  rating: number;
  comment: string;
  datePosted: Date;
};

export class ListReviewsRequest extends BasePagedQuery {
  search?: string | null;
  // Future filters: status?, dateFrom?, dateTo?, userId?
  constructor() {
    super();
  }
}

export type ListReviewsResponse = PageResult<ListReviewsForBookQueryDto>;
