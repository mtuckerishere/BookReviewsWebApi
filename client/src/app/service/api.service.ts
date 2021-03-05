import {Observable} from 'rxjs';
import {Book} from '../Interface/book';
import {catchError, tap,map} from 'rxjs/operators';
import { HttpClient, JsonpClientBackend } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  API_URL = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  public getBooks():Observable<Book []>{
    return this.http.get<Book[]>(`${this.API_URL}/books`)
    .pipe(
      tap(data=>
      console.log('All ' + JSON.stringify(data))));
  }
}


