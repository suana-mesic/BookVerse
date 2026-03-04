import { PageResult } from '../../core/models/paging/page-result';
import { BasePagedQuery } from '../../core/models/paging/base-paged-query';

// === QUERIES (READ) ===

/**
 * Query parameters for GET /Inventorys
 * Corresponds to: ListInventorysQuery.cs
 */
export class ListInventoryRequest extends BasePagedQuery {
  search?: string | null;
  onlyEnabled?:boolean|null;
}

/**
 * Response item for GET /Inventorys
 * Corresponds to: ListInventorysQueryDto.cs
 */
export interface ListInventoryQueryDto {
  storeId:number;
  storeName:string;
  bookId:number;
  isbn:number;
  title:string;
  quantityInStock:number;
  lastRestocked:number;
  reorderTreshold:number;
  location:string|null;
  quantityInStockForOnlineOrders:string|null
}


export interface GetInventoryByIdQueryDto {
  storeId:number;
  storeName:string;
  bookId:number;
  isbn:number;
  title:string;
  quantityInStock:number;
  lastRestocked:number;
  reorderTreshold:number;
  location:string|null;
}


export type ListInventoryResponse = PageResult<ListInventoryQueryDto>;

export interface CreateInventoryCommand {
  inventoryInfo: InventoryInfo[];
}

export interface InventoryInfo {
  storeId:number;
  bookId:number;
  quantityInStock:number;
  reorderTreshold:number;
  location:string|null;
}

export interface UpdateInventoryCommand {
  storeId:number;
  bookId:number;
  quantityInStock:number;
  reorderTreshold:number;
  location:string|null;
}
