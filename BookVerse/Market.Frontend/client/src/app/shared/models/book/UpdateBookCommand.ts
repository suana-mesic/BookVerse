export type UpdateBookCommand = {
    id: number;
    isbn?: string;
    title?: string;
    publisherId?: number;
    bookFormatId?: number;
    price?: number;
    language?: string;
    description?: string;
    pageCount?: number;
    quantityInStockForOnlineOrders?: number;
    imageUrl?: string;
    publishedDate?: Date;
}