import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-users',
  templateUrl: './add-edit-users.component.html',
  styleUrls: ['./add-edit-users.component.css']
})
export class AddEditUsersComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() User:any;
  userId!:number;
  name!: string;
  surname!: string;
  email!: string;

  ngOnInit(): void {
    this.userId=this.User.userId;
    this.name=this.User.name;
    this.surname=this.User.surname;
    this.email=this.User.email;
  }

  addUser(){
    var val = {userId:this.userId,
    name:this.name,
    surname:this.surname,
    email:this.email};
    this.service.addUser(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateUser(){
    var val = {userId:this.userId,
      name:this.name,
      surname:this.surname,
      email:this.email};
    this.service.updateUser(val,this.userId).subscribe(res=>{
    alert(res.toString());
    });
  }

}
