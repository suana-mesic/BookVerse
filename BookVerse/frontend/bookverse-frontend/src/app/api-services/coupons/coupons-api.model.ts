export interface CouponDto {
  id: number;
  name: string;
  promotionCode: string;
  amountOff: number | null;
  percentOff: number | null;
  description: string | null;
  // Min subtotal the order must reach before this coupon can be applied. Null = no minimum.
  // Surfaced from the backend so the checkout can refuse to apply a coupon inline instead
  // of round-tripping to /api/orders and waiting for the 409.
  minOrderAmount: number | null;
}

export interface ListCouponsQueryDto{
  name:string;
}

export interface FormFieldConfig {
  name:string;
  label:string;
  type:string;
  required:boolean
}
export interface CreateCouponCommand {
  name: string;
  promotionCode: string;
  amountOff: number | null;
  percentOff: number | null;
  description: string | null;
  startDate: string;
  endDate: string;
  // Optional caps that the backend stores. Without these fields in the payload they
  // were being dropped and every new coupon ended up with NULL in both columns.
  minOrderAmount: number | null;
  maxUses: number | null;
}