import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-genres',
  templateUrl: './show-genres.component.html',
  styleUrls: ['./show-genres.component.css']
})
export class ShowGenresComponent implements OnInit {

  constructor(private service:SharedService) { }

  GenreList:any=[];

  ModalTitle!: string;
  ActivateAddEditGenreComp:boolean=false;
  Genre:any;

  GenreIdFilter:string="";
  GenreNameFilter:string="";
  GenreListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshGenreList();
  }

  addClick(){
    this.Genre={
      genreId:0,
      genreName:""
    }
    this.ModalTitle="Add Genre";
    this.ActivateAddEditGenreComp=true;

  }

  editClick(item: any){
    this.Genre=item;
    this.ModalTitle="Edit Genre";
    this.ActivateAddEditGenreComp=true;
  }

  deleteClick(item: { genreId: number; }){
    if(confirm('Are you sure??')){
      this.service.deleteGenre(item.genreId).subscribe(data=>{
        console.log(data);
        this.refreshGenreList();
      },err=>{
        console.log(err);

      }
      )
    }
  }

  closeClick(){
    this.ActivateAddEditGenreComp=false;
    this.refreshGenreList();
  }


  refreshGenreList(){
    this.service.getGenresList().subscribe(data=>{
      this.GenreList=data;
      this.GenreListWithoutFilter=data;
    });
  }

  FilterFn(){
    var GenreIdFilter = this.GenreIdFilter;
    var GenreNameFilter = this.GenreNameFilter;

    this.GenreList = this.GenreListWithoutFilter.filter(function (el: { genreId: { toString: () => string; }; genreName: { toString: () => string; }; }){
        return el.genreId.toString().toLowerCase().includes(
          GenreIdFilter.toString().trim().toLowerCase()
        )&&
        el.genreName.toString().toLowerCase().includes(
          GenreNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop: string | number,asc: any){
    this.GenreList = this.GenreListWithoutFilter.sort(function(a: { [x: string]: number; },b: { [x: string]: number; }){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }


}
