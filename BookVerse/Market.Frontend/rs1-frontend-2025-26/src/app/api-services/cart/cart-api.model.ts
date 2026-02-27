export interface CartItemDto {
  cartId: number;
  bookId: number;
  bookTitle: string;
  imageUrl: string | null;
  price: number;
  quantity: number;
  subtotal: number;
  dateAdded: string;
}

export interface ListCartDto {
  activeItems: CartItemDto[];
  savedForLaterItems: CartItemDto[];
  totalPrice: number;
}

export interface CreateCartItemRequest {
  bookId: number;
  quantity: number;
}

export interface UpdateCartItemRequest {
  cartId: number;
  bookId: number;
  quantity: number;
}

export interface SaveForLaterRequest {
  cartId: number;
  bookId: number;
  savedForLater: boolean;
}

export interface DeleteCartItemRequest {
  cartId: number;
  bookId: number;
}