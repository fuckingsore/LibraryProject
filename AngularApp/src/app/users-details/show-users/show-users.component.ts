import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-users',
  templateUrl: './show-users.component.html',
  styleUrls: ['./show-users.component.css']
})
export class ShowUsersComponent implements OnInit {

  constructor(private service:SharedService) { }

  UserList:any=[];

  ModalTitle!: string;
  ActivateAddEditUserComp:boolean=false;
  User:any;

  UserIdFilter:string="";
  UserNameFilter:string="";
  UserListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshUserList();
  }

  addClick(){
    this.User={
      userId:0,
      name:"",
      surname:"",
      email:""
    }
    this.ModalTitle="Add User";
    this.ActivateAddEditUserComp=true;

  }

  editClick(item: any){
    this.User=item;
    this.ModalTitle="Edit User";
    this.ActivateAddEditUserComp=true;
  }

  deleteClick(item: { userId: number; }){
    if(confirm('Are you sure??')){
      this.service.deleteUser(item.userId).subscribe(data=>{
        console.log(data);
        this.refreshUserList();
      },err=>{console.log(err);})
    }
  }

  closeClick(){
    this.ActivateAddEditUserComp=false;
    this.refreshUserList();
  }


  refreshUserList(){
    this.service.getUsersList().subscribe(data=>{
      this.UserList=data;
      this.UserListWithoutFilter=data;
    });
  }

  FilterFn(){
    var UserIdFilter = this.UserIdFilter;
    var UserNameFilter = this.UserNameFilter;

    this.UserList = this.UserListWithoutFilter.filter(function (el: { userId: { toString: () => string; }; surname: { toString: () => string; }; }){
        return el.userId.toString().toLowerCase().includes(
          UserIdFilter.toString().trim().toLowerCase()
        )&&
        el.surname.toString().toLowerCase().includes(
          UserNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop: string | number,asc: any){
    this.UserList = this.UserListWithoutFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }

}
