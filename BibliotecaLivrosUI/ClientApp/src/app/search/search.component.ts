import { Component, ElementRef, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { AppComponent } from '../app.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatRippleModule } from '@angular/material';
import { BooksService } from '../services/books.service';
import { Book } from '../models/book';



@Component({
  selector: 'app-search-component',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})

export class SearchComponent {

  constructor(private booksService: BooksService) { }
  buscaLivros = 'Nenhum livro pesquisado';
  book : Book;
  books: Book[];
  valuePesquisa: string;
  @ViewChild('pesquisa',{ static: false }) pesquisa: ElementRef;

  public pesquisar($event: any) {
    const valueInput = this.pesquisa.nativeElement.value
    this.valuePesquisa = valueInput;
    if (valueInput === null) {
      window.alert('Informe um valor na pesquisa!');
    }
    else {
      this.getBooks(valueInput);
    }

  }

  public favoritos(object: any) {
    this.book = object;
    this.saveBooks(this.book);
  }


  getBooks(valuePesquisa: string) {
    this.booksService.getBooks(valuePesquisa).subscribe((book: Book[]) => {
      this.books = book;
      this.buscaLivros = '';
    });
  }

  saveBooks(book: Book) {
    this.booksService.saveBooks(this.book).subscribe((book: Book) => {
      this.book = book;
      var title = this.book.title;
      if (title === null) {
        window.alert('Não foi possivél adicionar o livro aos meus favoritos!');
      } else {
        window.alert('Livro ' +title+ ' adicionado aos meus favoritos com successo!');
      }
      this.getBooks(this.valuePesquisa);
    });
  }

  
}

