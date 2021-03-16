import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/Interface/book';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
books: any;

  constructor(private route:ActivatedRoute, private apiService:ApiService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params=>{
      this.apiService.getBookById(params.get('id')).subscribe(b=>{
        this.books =b
      })
    })
  }

}
