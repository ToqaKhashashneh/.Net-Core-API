import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UrlService } from '../Services/url.service';

@Component({
  selector: 'app-category-details',
  standalone: false,
  templateUrl: './category-details.component.html',
  styleUrl: './category-details.component.css'
})
export class CategoryDetailsComponent {

  constructor(private _url: UrlService, private _router: ActivatedRoute) { }

  ngOnInit() {

    this.GetCategoryById();
  }

  CategoryId: any;
  CategoryContainer: any;

  GetCategoryById() {
    this.CategoryId = this._router.snapshot.paramMap.get('id');
    this._url.GetCategoryById(this.CategoryId).subscribe((data) => {
      this.CategoryContainer = data;
    });

    }
    

  }


