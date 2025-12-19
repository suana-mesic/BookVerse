import { Component, inject, input, signal } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { BooksService } from '../Petar/books.service';
import { AuthorsService } from '../Petar/authors.service';
import { Book } from '../Petar/book/Book';
import { Author } from '../Petar/author/Author';
import { Review } from '../Petar/book/Review';
import { ReviewsService } from '../Petar/reviews.service';

@Component({
  standalone: true,
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.scss',
  imports: [HeaderComponent, RouterLink],
})
export class BookDetailsComponent {
  book = signal<Book | null>(null);
  authors = signal<Array<Author>>([]);
  reviews = signal<Array<Review>>([]);

  bookService = inject(BooksService);
  authorService = inject(AuthorsService);
  reviewService = inject(ReviewsService);
  bookId!: string;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.bookId = this.route.snapshot.paramMap.get('id')!;

    this.bookService.getBookDetailsFromApi(this.bookId).subscribe((book: any) => {
      this.book.set(book);
      console.log(this.book());
      for (let i = 0; i < this.book()!.authorIds.length; i++) {
        this.authorService.getAuthorFromApi(this.book()!.authorIds[i]).subscribe((author: any) => {
          this.authors.update((arr) => [...arr, author]);
        });
      }
      this.reviewService.getReviewsByBookIdFromApi(Number(this.bookId)).subscribe((review: any) => {
        this.reviews.update((arr) => [...arr, review]);
        console.log('izvrsavanje...');
        console.log(this.reviews());
      });
    });
  }
}
