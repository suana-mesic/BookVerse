export interface CouponDto {
  id: number;
  name: string;
  promotionCode: string;
  amountOff: number | null;
  percentOff: number | null;
  description: string | null;
}

export interface ListCouponsQueryDto{
  name:string;
}

