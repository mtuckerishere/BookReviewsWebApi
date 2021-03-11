import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorListComponent } from './author-list/author-list.component';
import { BookListComponent } from './book-list/book-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { CountryListComponent } from './country-list/country-list.component';
import { ReviewListComponent } from './review-list/review-list.component';
import { ReviewerListComponent } from './reviewer-list/reviewer-list.component';

const routes: Routes = [
  {path:'books', component:BookListComponent},
  {path:'authors',component:AuthorListComponent},
  {path: 'reviews', component:ReviewListComponent},
  {path: 'categories', component: CategoryListComponent},
  {path: 'countries', component:CountryListComponent},
  {path: 'reviewers', component: ReviewerListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
