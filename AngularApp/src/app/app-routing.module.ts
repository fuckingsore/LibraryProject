import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorsDetailsComponent } from './authors-details/authors-details.component';
import { BooksDetailsComponent } from './books-details/books-details.component';
import { GenresDetailsComponent } from './genres-details/genres-details.component';
import { OrdersDetailsComponent } from './orders-details/orders-details.component';
import { UsersDetailsComponent } from './users-details/users-details.component';

const routes: Routes = [
  {path:'authors',component:AuthorsDetailsComponent},
  {path:'genres',component:GenresDetailsComponent},
  {path:'books',component:BooksDetailsComponent},
  {path:'users',component:UsersDetailsComponent},
  {path:'orders',component:OrdersDetailsComponent}
  
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
