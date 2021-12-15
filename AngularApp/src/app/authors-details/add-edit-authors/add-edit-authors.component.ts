import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-add-edit-authors',
  templateUrl: './add-edit-authors.component.html',
  styleUrls: ['./add-edit-authors.component.css']
})
export class AddEditAuthorsComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() Author:any;
  authorId!:number;
  name!: string;
  surname!: string;

  ngOnInit(): void {
    this.authorId=this.Author.authorId;
    this.name=this.Author.name;
    this.surname=this.Author.surname;
  }

  addAuthor(){
    var val = {authorId:this.authorId,
    name:this.name,
    surname:this.surname};
    this.service.addAuthor(val).subscribe(res=>{
      alert(res.toString());
      
    });
  }

  updateAuthor(){
    var val = {authorId:this.authorId,
      name:this.name,
      surname:this.surname};
    this.service.updateAuthor(val,this.authorId).subscribe(res=>{
    alert(res.toString());
    
    });
  }

}
