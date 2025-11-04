import { Component, inject, OnInit, signal } from '@angular/core';
import { BookComponent } from '../book/book.component';
import { BooksService } from '../../services/books.service';
import { catchError } from 'rxjs';
import { Book } from '../../shared/models/book/Book';
import { CategoriesService } from '../../services/categories.service';
import { Categories } from '../../shared/models/book/Categories';

@Component({
  selector: 'app-body',
  imports: [BookComponent],
  templateUrl: 'body.component.html',
  styleUrl: 'body.component.css',
})
export class BodyComponent implements OnInit {
  bookService = inject(BooksService);
  categoryService = inject(CategoriesService);
  books = signal<Array<Book>>([]);

  totalSize = 0;

  pageSize = 10;
  booksSize = 0;
  pageNumber = signal(1);

  pageNumberArray = signal<Array<Number>>([]);

  ngOnInit(): void {
    this.bookService.getBooksFromApi().subscribe((book: any) => {
      this.books.set(book.items);
      this.totalSize = this.books().length;

      this.pageNumber.set(Math.ceil(this.totalSize / this.pageSize));

      this.setPageArray();
    });
  }

  setPageArray() {
    this.pageNumberArray.set(Array.from({ length: this.pageNumber() }, (_, i) => i + 1));
  }

  setCurrentPage(page: number) {
    this.bookService.page.set(page);

    this.bookService.getBooksFromApi().subscribe((book: any) => {
      this.books.set(book.items);
    });
  }

  setPageSize(event: Event) {
    const select = event.target as HTMLSelectElement;
    this.pageSize = Number(select.value);
    this.bookService.pageSize.set(this.pageSize);

    this.bookService.getBooksFromApi().subscribe((book: any) => {
      this.books.set(book.items);
      this.pageNumber.set(Math.ceil(this.totalSize / this.pageSize));
      console.log(this.pageNumber());

      this.setPageArray();
    });
  }
}
