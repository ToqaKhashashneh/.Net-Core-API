import { Component } from '@angular/core';
import { UrlService } from '../Services/url.service';

@Component({
  selector: 'app-category',
  standalone: false,
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {

  constructor(private _url: UrlService) { }

  ngOnInit() {
    this.GetCategories()
  }


  categoryContainer: any

  GetCategories() {
    this._url.GetCategories().subscribe((data) => {
      this.categoryContainer = data;
    })
  }
    



}
