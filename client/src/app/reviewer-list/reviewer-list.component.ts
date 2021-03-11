import { Component, OnInit } from '@angular/core';
import {Reviewer} from '../Interface/reviewer';
import { ReviewerListService } from '../service/reviewer-list.service';

@Component({
  selector: 'app-reviewer-list',
  templateUrl: './reviewer-list.component.html',
  styleUrls: ['./reviewer-list.component.css']
})
export class ReviewerListComponent implements OnInit {
  reviewers: Reviewer[] =[];
  constructor(private reviewerService:ReviewerListService) { }

  ngOnInit(): void {
    this.reviewerService.getReviewers().subscribe({
      next:reviewers=>{
        this.reviewers = reviewers
      }
    })

  }

}
