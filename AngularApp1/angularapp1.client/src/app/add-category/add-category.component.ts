import { Component } from '@angular/core';
import { UrlService } from '../Services/url.service';

@Component({
  selector: 'app-add-category',
  standalone: false,
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {


  ngOnInit() { }


  constructor(private _url: UrlService) { }


  AddCategory(data: any) {

    var formData: any = new FormData();
    formData.append("Name", data.Name); //same as  in the Dto (from here it send it to the Dto and From the Dto to the DataBase)
    formData.append("Description", data.Description);

    this._url.AddCategory(formData).subscribe(() => {
      alert("Added Successfuly!")

    });

  }

}
