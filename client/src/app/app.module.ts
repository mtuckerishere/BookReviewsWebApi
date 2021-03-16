import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import {MatCardModule} from '@angular/material/card';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './book-list/book-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthorListComponent } from './author-list/author-list.component';
import { ReviewListComponent } from './review-list/review-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { CountryListComponent } from './country-list/country-list.component';
import { ReviewerListComponent } from './reviewer-list/reviewer-list.component';
import { BookDetailsComponent } from './book-list/book-details/book-details.component';


@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    AuthorListComponent,
    ReviewListComponent,
    CategoryListComponent,
    CountryListComponent,
    ReviewerListComponent,
    BookDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
