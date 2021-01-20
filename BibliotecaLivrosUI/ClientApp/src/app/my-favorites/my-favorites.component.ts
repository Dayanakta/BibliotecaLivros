import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppComponent } from '../app.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatRippleModule } from '@angular/material';
import { BooksService } from '../services/books.service';
import { Book } from '../models/book';



@NgModule({
  declarations: [],
  imports: [],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})

@Component({
  selector: 'app-my-favorites',
  templateUrl: './my-favorites.component.html',
  styleUrls: ['./my-favorites.component.css']
})

export class MyFavoritesComponent implements OnInit {

  constructor(private booksService: BooksService) { }

  ngOnInit(): void {
    this.getBooks();
  }

  book: Book;
  books: Book[];

  public excluir(object: any) {
    var id = object;
    var teste = this.deleteBooks(id);
  }

  getBooks() {
    this.booksService.getBooksFavorites().subscribe((volumes: Book[]) => {
      this.books = volumes;
    });
  }

  deleteBooks(ID: string) {
    this.booksService.deleteBook(ID).subscribe(() => {
      window.alert('Livro excluido dos meus favoritos com successo!');
      this.getBooks();
    });
  }
 
}

