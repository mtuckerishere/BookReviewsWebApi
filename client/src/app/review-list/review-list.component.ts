import { Component, OnInit } from '@angular/core';
import { ReviewListService } from '../service/review-list.service';
import {Review} from '../Interface/review';

@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {

  reviews:Review[] = [];
  constructor(private reviewService: ReviewListService){ }

  ngOnInit(): void {
    this.reviewService.getReviews().subscribe({
      next:reviews=>{
        this.reviews=reviews
      }
    }

    )
  }

}
