import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';

import {MatCardModule} from '@angular/material/card';
import {ApiService} from '../service/api.service';
import {Book} from '../Interface/book';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[] = []


  constructor(private apiService:ApiService) { }

  ngOnInit() {
    this.apiService.getBooks().subscribe({
      next: books=>{
        this.books=books
      }
    })
  }

}
