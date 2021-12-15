import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-books',
  templateUrl: './add-edit-books.component.html',
  styleUrls: ['./add-edit-books.component.css']
})
export class AddEditBooksComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() Book:any;
  bookId!:number ;
  name!: string;
  authorId!:number;
  genreId!:number

  ngOnInit(): void {
    this.bookId=this.Book.bookId;
    this.name=this.Book.name;
    this.authorId=this.Book.authorId;
    this.genreId=this.Book.genreId;
  }

  addBook(){
    var val = {bookId:this.bookId,
    name:this.name,
    authorId:this.authorId,
    genreId:this.genreId};
    this.service.addBook(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateBook(){
    var val = {bookId:this.bookId,
    name:this.name,
    authorId:this.authorId,
    genreId:this.genreId};
    this.service.updateBook(val,this.bookId).subscribe(res=>{
    alert(res.toString());
    });
  }

}
