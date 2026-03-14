import { PageResult } from '../../core/models/paging/page-result';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';

// === QUERIES (READ) ===

/**
 * Query parameters for GET /Books
 * Corresponds to: ListBooksQuery.cs
 */
export class ListBooksRequest extends BasePagedQuery {
  search?: string | null;
  // Future filters: categoryId?, isEnabled?, priceMin?, priceMax?
}

/**
 * Response item for GET /Books
 * Corresponds to: ListBooksQueryDto.cs
 */
export interface ListBooksQueryDto {
  id: number;
  isbn: string;
  title: string;
  authors: Author[];
  categories: Category[];
  publisherName: string;
  bookFormatName: string;
  price: number;
  language: string;
  description?: string | null;
  pageCount: number;
  quantityInStockForOnlineOrders: number;
  imageUrl: string;
  publishedDate: string;
  isDeleted: boolean;
  // stockQuantity: number;
  // categoryName: string;
  // isEnabled: boolean;
}

export interface Author {
  id: number;
  firstName: string;
  lastName: string;
  biography: string | null;
  country: string | null;
}

export interface Category {
  id: number;
  name: string;
}

/**
 * Response for GET /Books/{id}
 * Corresponds to: GetBookByIdQueryDto.cs
 */
export interface GetBookByIdQueryDto {
  isbn: string;
  title: string;
  publisherId: number;
  bookFormatId: number;
  authorIds: number[];
  categoryIds: number[];
  price: number;
  language: string;
  description: string;
  pageCount: number;
  quantityInStockForOnlineOrders: number;
  imageUrl: string;
  publishedDate: Date;
}

/**
 * Paged response for GET /Books
 */
export type ListBooksResponse = PageResult<ListBooksQueryDto>;

// === COMMANDS (WRITE) ===

/**
 * Command for POST /Books
 * Corresponds to: CreateBookCommand.cs
 */
export interface CreateBookCommand {
  isbn: string;
  title: string;
  publisherId: number;
  bookFormatId: number;
  authorIds: number[];
  categoryIds: number[];
  price: number;
  language: string;
  description: string;
  pageCount: number;
  quantityInStockForOnlineOrders: number;
  imageUrl: string;
  publishedDate: Date;
}

/**
 * Command for PUT /Books/{id}
 * Corresponds to: UpdateBookCommand.cs
 */
export interface UpdateBookCommand {
  isbn: string;
  title: string;
  publisherId: number;
  bookFormatId: number;
  authorIds: number[];
  categoryIds: number[];
  price: number;
  language: string;
  description: string;
  pageCount: number;
  quantityInStockForOnlineOrders: number;
  imageUrl: string;
  publishedDate: Date | null;
}

export interface ListBooksForAutocompleteQueryDto {
  id: number;
  title: string;
}
