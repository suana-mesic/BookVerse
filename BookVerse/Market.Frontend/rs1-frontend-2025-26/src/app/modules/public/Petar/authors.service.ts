import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Author } from './author/Author';

@Injectable({
  providedIn: 'root',
})
export class AuthorsService {
  http = inject(HttpClient);

  getAuthorFromApi(authorId: number) {
    const url = `https://localhost:7260/Authors/${authorId}`;
    // console.log(url);
    return this.http.get<Author>(url);
  }
}
