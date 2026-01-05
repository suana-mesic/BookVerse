import { Component, input } from '@angular/core';
import { Book } from '../Petar/book/Book';
import { BookOverview } from '../Petar/book/BookOverview';

@Component({
  selector: 'app-book',
  imports: [],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
})
export class BookComponent {
  book = input.required<BookOverview>();
}
