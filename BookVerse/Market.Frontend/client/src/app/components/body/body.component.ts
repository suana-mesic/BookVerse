import { Component, inject, OnInit, signal } from '@angular/core';
import { BookComponent } from '../book/book.component';
import { BooksService } from '../../services/books.service';
import { Book } from '../../models/book.type';
import { catchError } from 'rxjs';

@Component({
  selector: 'app-body',
  imports: [BookComponent],
  templateUrl: 'body.component.html',
  styleUrl: 'body.component.css',
})
export class BodyComponent implements OnInit {
  bookService = inject(BooksService);
  books = signal<Array<Book>>([]);

  ngOnInit(): void {
    this.bookService.getBooksFromApi().subscribe((book: any) => {
      this.books.set(book.items);
    });
  }
}
