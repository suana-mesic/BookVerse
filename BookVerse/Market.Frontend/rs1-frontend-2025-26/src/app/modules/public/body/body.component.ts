import { Component, inject, OnInit, signal } from '@angular/core';
import { BookComponent } from '../book/book.component';
import { CategoriesService } from '../Petar/categories.service';
import { Book } from '../Petar/book/Book';
import { BooksService } from '../Petar/books.service';
import { RouterModule } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { SharedModule } from '../../shared/shared-module';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-body',
  imports: [BookComponent, RouterModule, TranslateModule, SharedModule],
  templateUrl: 'body.component.html',
  styleUrl: 'body.component.css',
})
export class BodyComponent implements OnInit {
  bookService = inject(BooksService);
  categoryService = inject(CategoriesService);
  books = signal<Array<Book>>([]);
  language: 'bs' | 'en' = 'bs';
  translate = inject(TranslateService);
  private langChangeSub!: Subscription;

  totalItems = 0;
  totalPages = 0;
  isLoading = false;

  request = {
    paging: {
      page: 1,
      pageSize: 50,
    },
  };

  ngOnInit(): void {
    this.language = (this.translate.currentLang || this.translate.defaultLang || 'bs') as 'bs' | 'en';
    this.loadBooks();
    this.langChangeSub = this.translate.onLangChange.subscribe((event) => {
      this.language = event.lang as 'bs' | 'en';
      this.loadBooks();
    });
  }

  private loadBooks(): void {
    this.isLoading = true;
    this.bookService.page.set(this.request.paging.page);
    this.bookService.pageSize.set(this.request.paging.pageSize);
    this.bookService.getBooksFromApi(this.language).subscribe((response: any) => {
      this.books.set(response.items);
      this.totalItems = response.totalItems;
      this.totalPages = response.totalPages;
      this.isLoading = false;
    });
  }

  goToPage(page: number): void {
    if (page < 1 || (this.totalPages && page > this.totalPages)) return;
    this.request.paging.page = page;
    this.loadBooks();
  }

  nextPage(): void {
    this.goToPage(this.request.paging.page + 1);
  }
  prevPage(): void {
    this.goToPage(this.request.paging.page - 1);
  }

  changePageSize(size: number): void {
    this.request.paging.pageSize = size;
    this.request.paging.page = 1;
    this.loadBooks();
  }
}
