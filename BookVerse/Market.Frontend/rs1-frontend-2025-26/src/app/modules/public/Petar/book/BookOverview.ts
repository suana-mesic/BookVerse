import { Author } from '../author/Author';

export type BookOverview = {
  id: number;
  isbn: string;
  title: string;
  authors: Author[];
  language: string;
  price: number;
  pageCount: number;
  imageUrl?: string;
};
