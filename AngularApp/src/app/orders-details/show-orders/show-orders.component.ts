import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-orders',
  templateUrl: './show-orders.component.html',
  styleUrls: ['./show-orders.component.css']
})
export class ShowOrdersComponent implements OnInit {

  constructor(private service:SharedService) { }

  OrderList:any=[];

  ModalTitle!: string;
  ActivateAddEditOrderComp:boolean=false;
  Order:any;

  OrderIdFilter:string="";
  OrderListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshOrderList();
  }

  addClick(){
    this.Order={
      orderId:0,
      userId:0,
      bookId:0
    }
    this.ModalTitle="Add Order";
    this.ActivateAddEditOrderComp=true;

  }

  editClick(item: any){
    this.Order=item;
    this.ModalTitle="Edit Order";
    this.ActivateAddEditOrderComp=true;
  }

  deleteClick(item: { orderId: any; }){
    if(confirm('Are you sure??')){
      this.service.deleteOrder(item.orderId).subscribe(data=>{
        console.log(data);
        this.refreshOrderList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditOrderComp=false;
    this.refreshOrderList();
  }


  refreshOrderList(){
    this.service.getOrderList().subscribe(data=>{
      this.OrderList=data;
      this.OrderListWithoutFilter=data;
    });
  }

  FilterFn(){
    var OrderIdFilter = this.OrderIdFilter;
    

    this.OrderList = this.OrderListWithoutFilter.filter(function (el: { orderId: { toString: () => string; }; }){
        return el.orderId.toString().toLowerCase().includes(
          OrderIdFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop: string | number,asc: any){
    this.OrderList = this.OrderListWithoutFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }

}
