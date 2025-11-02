export type Book = {
    id: number;
    isbn: string;
    title: string;
    publisherId: number;
    publisherName: string;
    bookFormatId: number;
    bookFormatName: string;
    price: number;
    language: string;
    description?: string;
    pageCount: number;
    quantityInStockForOnlineOrders?: number;
    imageUrl?: string;
    publishedDate: Date;
}