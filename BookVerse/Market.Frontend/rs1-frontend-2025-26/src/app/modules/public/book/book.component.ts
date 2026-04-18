import { Component, input } from '@angular/core';
import { Book } from '../Petar/book/Book';
import { BookOverview } from '../Petar/book/BookOverview';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-book',
  imports: [TranslateModule],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
})
export class BookComponent {
  book = input.required<BookOverview>();
}
