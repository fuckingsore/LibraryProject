import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-authors',
  templateUrl: './show-authors.component.html',
  styleUrls: ['./show-authors.component.css']
})
export class ShowAuthorsComponent implements OnInit {

  constructor(private service:SharedService) { }

  AuthorList:any=[];

  ModalTitle!: string;
  ActivateAddEditAuthorComp:boolean=false;
  Author:any;

  AuthorIdFilter:string="";
  AuthorNameFilter:string="";
  AuthorListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshAuthorList();
  }

  addClick(){
    this.Author={
      authorId:0,
      name:"",
      surname:"",
    }
    this.ModalTitle="Add Author";
    this.ActivateAddEditAuthorComp=true;

  }

  editClick(item: any){
    this.Author=item;
    this.ModalTitle="Edit Author";
    this.ActivateAddEditAuthorComp=true;
  }

  deleteClick(item: { authorId: number; }){
    if(confirm('Are you sure??')){
      this.service.deleteAuthor(item.authorId).subscribe(data=>{
        console.log(data);
        this.refreshAuthorList();
      }, err=>{
        console.log(err);
      })
    }
  }

  closeClick(){
    this.ActivateAddEditAuthorComp=false;
    this.refreshAuthorList();
  }


  refreshAuthorList(){
    this.service.getAuthorsList().subscribe(data=>{
      this.AuthorList=data;
      this.AuthorListWithoutFilter=data;
    });
  }

  FilterFn(){
    var AuthorIdFilter = this.AuthorIdFilter;
    var AuthorNameFilter = this.AuthorNameFilter;

    this.AuthorList = this.AuthorListWithoutFilter.filter(function (el: { authorId: { toString: () => string; }; surname: { toString: () => string; }; }){
        return el.authorId.toString().toLowerCase().includes(
          AuthorIdFilter.toString().trim().toLowerCase()
        )&&
        el.surname.toString().toLowerCase().includes(
          AuthorNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop: string | number,asc: any){
    this.AuthorList = this.AuthorListWithoutFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }


}
