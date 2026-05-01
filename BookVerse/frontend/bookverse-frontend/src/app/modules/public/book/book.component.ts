import { Component, input } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { ApiUrlPipe } from '../../shared/pipes/api-url.pipe';
import { AppNumberPipe } from '../../shared/pipes/number-pipe';
import { BookOverview } from '../../../api-services/books/books-api.models';

@Component({
  selector: 'app-book',
  imports: [TranslateModule, ApiUrlPipe, AppNumberPipe],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
})
export class BookComponent {
  book = input.required<BookOverview>();
}
