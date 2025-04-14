import { Component } from '@angular/core';
import { UrlService } from '../Services/url.service';
import { Snapshot } from 'jest-editor-support';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-category',
  standalone: false,
  templateUrl: './edit-category.component.html',
  styleUrl: './edit-category.component.css'
})
export class EditCategoryComponent {

  constructor(private _url: UrlService, private _Route: ActivatedRoute) { }


  ngOnInit() {
    this.CategoryId = this._Route.snapshot.paramMap.get('id');
    this.CategoryContainer = this._url.GetCategoryById(this.CategoryId).
      subscribe((data) => { this.CategoryContainer = data; });
  }


  CategoryId:any
  CategoryContainer: any

  UpdateCategory( data: any) {
    var formData: any = new FormData();
    formData.append("Name", data.Name); //same as  in the Dto (from here it send it to the Dto and From the Dto to the DataBase)
    formData.append("Description", data.Description);
    
    this._url.UpdateCategory(this.CategoryId, formData).subscribe((res: any) => {
      alert("Updated Successfully!")
    });
  }


}
