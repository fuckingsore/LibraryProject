import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-genres',
  templateUrl: './add-edit-genres.component.html',
  styleUrls: ['./add-edit-genres.component.css']
})
export class AddEditGenresComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() Genre:any;
  genreId!:number;
  genreName!: string;

  ngOnInit(): void {
    this.genreId=this.Genre.genreId;
    this.genreName=this.Genre.genreName;
  }

  addGenre(){
    var val = {genreId:this.genreId,
      genreName:this.genreName};
    this.service.addGenre(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateGenre(){
    var val = {genreId:this.genreId,
      genreName:this.genreName};
    this.service.updateGenre(val,this.genreId).subscribe(res=>{
    alert(res.toString());
    });
  }

}
