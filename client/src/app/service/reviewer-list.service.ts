import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reviewer } from '../Interface/reviewer';

@Injectable({
  providedIn: 'root'
})
export class ReviewerListService {

  API_URL = 'http://localhost:5000/api';
  constructor(private http:HttpClient) { }
    public getReviewers() :Observable<Reviewer[]>{
      return this.http.get<Reviewer[]>(`${this.API_URL}/reviewers`);
    }
}
