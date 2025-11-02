import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormField, MatLabel, MatHint } from "@angular/material/form-field";
import { MatSelect, MatOption } from '@angular/material/select';
import { CreateBookCommand } from '../../../shared/models/book/CreateBookCommand';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { BooksService } from '../../../services/books.service';

@Component({
  selector: 'app-book-crud',
  imports: [ReactiveFormsModule, MatInputModule, MatFormField, MatLabel, MatSelect, MatOption, MatHint, MatNativeDateModule, MatDatepickerModule],
  templateUrl: './book-crud.html',
  styleUrl: './book-crud.scss',
})
export class BookCrud {
  bookForm: FormGroup;
  book?: CreateBookCommand;


  constructor(private fb: FormBuilder, private bookService: BooksService) {
    this.bookForm = this.fb.group({
      isbn: ['', Validators.required],
      title: ['', Validators.required],
      publisherId: ['', Validators.required],
      bookFormatId: ['', Validators.required],
      price: ['', Validators.required],
      language: ['', Validators.required],
      description: [''],
      pageCount: ['', Validators.required],
      quantityInStockForOnlineOrders: ['', Validators.required],
      publishedDate: ['', Validators.required]
    });
  }

  createBook() {
    console.log("Šaljem podatke...");

    const bookData: CreateBookCommand = {
      isbn: this.bookForm.value.isbn,
      title: this.bookForm.value.isbn,
      publisherId: Number(this.bookForm.value.publisherId),
      bookFormatId: Number(this.bookForm.value.bookFormatId),
      price: parseFloat(this.bookForm.value.price),
      language: this.bookForm.value.language,
      description: this.bookForm.value.description,
      pageCount: Number(this.bookForm.value.pageCount),
      quantityInStockForOnlineOrders: Number(this.bookForm.value.quantityInStockForOnlineOrders),
      publishedDate: this.bookForm.value.publishedDate
    };

    this.bookService.createBook(bookData).subscribe({
      next: (response) => {
        console.log("Knjiga je uspješno dodana u bazu", response);
      },
      error: (error) => {
        console.log("Došlo je do greške prilikom slanja podataka o knjizi", error);
      }
    });

  }
}
