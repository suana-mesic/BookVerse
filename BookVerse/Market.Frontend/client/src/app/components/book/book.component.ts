import { Component, input } from '@angular/core';
import { Book } from '../../shared/models/book/Book';

@Component({
  selector: 'app-book',
  imports: [],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
})
export class BookComponent {
  book = input.required<Book>();
}
