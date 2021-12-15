import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-books',
  templateUrl: './show-books.component.html',
  styleUrls: ['./show-books.component.css']
})
export class ShowBooksComponent implements OnInit {

  constructor(private service:SharedService) { }

  BookList:any=[];

  ModalTitle!: string;
  ActivateAddEditBookComp:boolean=false;
  Book:any;

  BookIdFilter:string="";
  BookNameFilter:string="";
  BookListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshBookList();
  }

  addClick(){
    this.Book={
      bookId:0,
      name:"",
      authorId:0,
      genreId:0
    }
    this.ModalTitle="Add Book";
    this.ActivateAddEditBookComp=true;

  }

  editClick(item: any){
    this.Book=item;
    this.ModalTitle="Edit Book";
    this.ActivateAddEditBookComp=true;
  }

  deleteClick(item: { bookId: number; }){
    if(confirm('Are you sure??')){
      this.service.deleteBook(item.bookId).subscribe(data=>{
        console.log(data);
        this.refreshBookList();
      }, err=>{
        console.log(err);
      })
    }
  }

  closeClick(){
    this.ActivateAddEditBookComp=false;
    this.refreshBookList();
  }


  refreshBookList(){
    this.service.getGenresList().subscribe(data=>{
      this.BookList=data;
      this.BookListWithoutFilter=data;
    });
  }

  FilterFn(){
    var BookIdFilter = this.BookIdFilter;
    var BookNameFilter = this.BookNameFilter;

    this.BookList = this.BookListWithoutFilter.filter(function (el: { bookId: { toString: () => string; }; name: { toString: () => string; }; }){
        return el.bookId.toString().toLowerCase().includes(
          BookIdFilter.toString().trim().toLowerCase()
        )&&
        el.name.toString().toLowerCase().includes(
          BookNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop: string | number,asc: any){
    this.BookList = this.BookListWithoutFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }


}
