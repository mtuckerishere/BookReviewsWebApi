import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Review } from '../Interface/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewListService {
  API_URL:string = "http://localhost:5000/api";
  constructor(private http: HttpClient) { }

  public getReviews():Observable<Review []>{
    return this.http.get<Review []>(`${this.API_URL}/reviews`);

  }
}
