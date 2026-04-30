import { BasePagedQuery } from '../../core/models/paging/base-paged-query';
import { PageResult } from '../../core/models/paging/page-result';

export interface GetMyProfileQueryDto {
  firstName: string;
  lastName: string;
  email: string;
  line1: string;
  line2?: string;
  city: string;
  country: string;
  twoFactorEnabled: boolean;
}

export interface UpdateMyProfileCommand {
  firstName: string;
  lastName: string;
  line1: string;
  line2?: string;
  city: string;
  country: string;
  twoFactorEnabled: boolean;
}

export interface UserAddressDto {
  addressId: number | null;
  line1: string | null;
  line2: string | null;
  city: string | null;
  country: string | null;
}

export interface ListUsersQueryDto {
  id: number;
  fullName: string;
  email: string;
  isAdmin: boolean;
  isManager: boolean;
  isEmployee: boolean;
  isEnabled: boolean;
}
export interface GetUserByIdQueryDto {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  isAdmin: boolean;
  isManager: boolean;
  isEmployee: boolean;
  isEnabled: boolean;
}

export interface UpdateUserRolesCommand {
  isAdmin: boolean;
  isManager: boolean;
  isEmployee: boolean;
  isEnabled: boolean;
}

export class ListUsersRequest extends BasePagedQuery {
  search?: string | null;
}

export type ListUsersResponse = PageResult<ListUsersQueryDto>;
