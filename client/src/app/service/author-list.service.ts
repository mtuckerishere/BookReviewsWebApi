import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Author } from '../Interface/author';

@Injectable({
  providedIn: 'root'
})
export class AuthorListService {
  API_URL = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }
  public getAuthors() :Observable<Author []>{
    return this.http.get<Author[]>(`${this.API_URL}/authors`)
      .pipe(
        tap(data=>
          console.log('All ' + JSON.stringify(data))
        )
      );
  }
}
