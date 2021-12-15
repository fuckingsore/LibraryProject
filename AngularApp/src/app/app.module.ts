import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorsDetailsComponent } from './authors-details/authors-details.component';
import { ShowAuthorsComponent } from './authors-details/show-authors/show-authors.component';
import { AddEditAuthorsComponent } from './authors-details/add-edit-authors/add-edit-authors.component';
import { BooksDetailsComponent } from './books-details/books-details.component';
import { ShowBooksComponent } from './books-details/show-books/show-books.component';
import { AddEditBooksComponent } from './books-details/add-edit-books/add-edit-books.component';
import { GenresDetailsComponent } from './genres-details/genres-details.component';
import { ShowGenresComponent } from './genres-details/show-genres/show-genres.component';
import { AddEditGenresComponent } from './genres-details/add-edit-genres/add-edit-genres.component';
import { UsersDetailsComponent } from './users-details/users-details.component';
import { ShowUsersComponent } from './users-details/show-users/show-users.component';
import { AddEditUsersComponent } from './users-details/add-edit-users/add-edit-users.component';
import { OrdersDetailsComponent } from './orders-details/orders-details.component';
import { ShowOrdersComponent } from './orders-details/show-orders/show-orders.component';
import { AddEditOrdersComponent } from './orders-details/add-edit-orders/add-edit-orders.component';
import { SharedService } from './shared.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    AuthorsDetailsComponent,
    ShowAuthorsComponent,
    AddEditAuthorsComponent,
    BooksDetailsComponent,
    ShowBooksComponent,
    AddEditBooksComponent,
    GenresDetailsComponent,
    ShowGenresComponent,
    AddEditGenresComponent,
    UsersDetailsComponent,
    ShowUsersComponent,
    AddEditUsersComponent,
    OrdersDetailsComponent,
    ShowOrdersComponent,
    AddEditOrdersComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
