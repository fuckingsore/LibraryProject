import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl="https://localhost:5001/api";


  constructor(private http:HttpClient) { }

  getAuthorsList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/authors');
  }

  getAuthor(val:any){
    return this.http.get<any>(this.APIUrl+'/authors/'+ val);
  }

  addAuthor(val:any){
    return this.http.post(this.APIUrl+'/authors',val);
  }

  updateAuthor(val:any,id:number){

    return this.http.put(`${this.APIUrl+'/authors'}/${id}`, val);
  }

  deleteAuthor(id:number){
    return this.http.delete(`${this.APIUrl+'/authors'}/${id}`);
  }

  getBooksList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/books');
  }

  getBook(val:any){
    return this.http.get<any>(this.APIUrl+'/books/'+ val);
  }

  addBook(val:any){
    return this.http.post(this.APIUrl+'/books',val);
  }

  updateBook(val:any,id:number){
    return this.http.put(`${this.APIUrl+'/books'}/${id}`, val);
  }

  deleteBook(val:any){
    return this.http.delete(this.APIUrl+'/books/'+val);
  }
  getGenresList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/genres');
  }

  getGenre(val:any){
    return this.http.get<any>(this.APIUrl+'/genres/'+ val);
  }

  addGenre(val:any){
    return this.http.post(this.APIUrl+'/genres',val);
  }

  updateGenre(val:any,id:number){
    return this.http.put(`${this.APIUrl+'/genres'}/${id}`, val);
  }

  deleteGenre(id:number){
    return this.http.delete(`${this.APIUrl+'/genres'}/${id}`);
  }

  getUsersList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/users');
  }

  getUser(val:any){
    return this.http.get<any>(this.APIUrl+'/users/'+ val);
  }

  addUser(val:any){
    return this.http.post(this.APIUrl+'/users',val);
  }

  updateUser(val:any,id:number){
    return this.http.put(`${this.APIUrl+'/users'}/${id}`, val);
  }

  deleteUser(val:any){
    return this.http.delete(this.APIUrl+'/users/'+val);
  }

  getOrderList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/orders');
  }

  getOrder(val:any){
    return this.http.get<any>(this.APIUrl+'/orders/'+ val);
  }

  addOrder(val:any){
    return this.http.post(this.APIUrl+'/orders',val);
  }

  updateOrder(val:any,id:number){
    return this.http.put(`${this.APIUrl+'/orders'}/${id}`, val);
  }

  deleteOrder(val:any){
    return this.http.delete(this.APIUrl+'/orders/'+val);
  }
}
