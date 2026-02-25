export interface CurrentUserDto {
  userId: number;
  email: string;
  isAdmin: boolean;
  isManager: boolean;
  isEmployee: boolean;
  tokenVersion: number;
  firstName:string;
  lastName:string;
  fullName:string;
}
