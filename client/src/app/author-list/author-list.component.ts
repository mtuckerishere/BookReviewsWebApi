import { Component, OnInit } from '@angular/core';
import { Author } from '../Interface/author';
import { AuthorListService } from '../service/author-list.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})
export class AuthorListComponent implements OnInit {

  authors: Author[] = [];
  constructor(private authorService:AuthorListService) { }

  ngOnInit() {
    this.authorService.getAuthors().subscribe({
      next: authors=>{
        this.authors = authors
      }
    })
  }

}
