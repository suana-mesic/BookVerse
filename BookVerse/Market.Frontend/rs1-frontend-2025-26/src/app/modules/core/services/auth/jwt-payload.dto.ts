// payload kako dolazi iz JWT-a
export interface JwtPayloadDto {
  sub: string;
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress": string;
  is_admin: string;
  is_manager: string;
  is_employee: string;
  ver: string;
  iat: number;
  exp: number;
  aud: string;
  iss: string;
  firstName:string;
  lastName:string;
  fullName:string;
}
