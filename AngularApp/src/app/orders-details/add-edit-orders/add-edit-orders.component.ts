import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-orders',
  templateUrl: './add-edit-orders.component.html',
  styleUrls: ['./add-edit-orders.component.css']
})
export class AddEditOrdersComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() Order:any;
  orderId!:number ;
  userId!:number;
  bookId!:number;

  ngOnInit(): void {
    this.orderId=this.Order.orderId;
    this.userId=this.Order.userId;
    this.bookId=this.Order.bookId;
    
  }

  addOrder(){
    var val = {orderId:this.orderId,
    userId:this.orderId,
    bookId:this.bookId};
    this.service.addOrder(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateOrder(){
    var val = {orderId:this.orderId,
    userId:this.orderId,
    bookId:this.bookId};
    this.service.updateOrder(val,this.orderId).subscribe(res=>{
    alert(res.toString());
    });
  }

}