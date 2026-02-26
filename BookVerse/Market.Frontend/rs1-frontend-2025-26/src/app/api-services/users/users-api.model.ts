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