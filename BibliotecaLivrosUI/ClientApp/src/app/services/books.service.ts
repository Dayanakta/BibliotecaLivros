import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Book } from '../models/book';


@Injectable({
  providedIn: 'root'
})
export class BooksService {

  urlBooks = 'https://localhost:44354/Book'; // api rest controller Books
  urlMyFavorites = 'https://localhost:44354/MyFavorite'; // api rest controller Books

  // injetando o HttpClient
  constructor(private httpClient: HttpClient) { }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os livros do favoritos
  getBooksFavorites(): Observable<Book[]> {
    return this.httpClient.get<Book[]>(this.urlMyFavorites)
      .pipe(
        catchError(this.handleError))
  }

  // Obtem todos os livros do Google API
  getBooks(search: string): Observable<Book[]> {
    return this.httpClient.get<Book[]>('https://localhost:44354/Book?search=' + search)
      .pipe(
        catchError(this.handleError))
  }

  // salva um livro no favoritos
  saveBooks(book: Book): Observable<Book> {
    return this.httpClient.post<Book>(this.urlMyFavorites, JSON.stringify(book), this.httpOptions)
      .pipe(
        catchError(this.handleError)
      )
  }


  // deleta um livros dos favoritos
  deleteBook(ID: string) {
    return this.httpClient.delete<string>('https://localhost:44354/MyFavorite?bookId=' + ID, this.httpOptions)
      .pipe(
        catchError(this.handleError)
      )
  }

  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };
}
