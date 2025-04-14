import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor(private _http: HttpClient) { }


  CategoryUrl: string = "https://localhost:7107/api/Category";


  GetCategories() {
    return this._http.get(this.CategoryUrl);
  }

  AddCategory(FormData: any) {

    return this._http.post("https://localhost:7107/api/Category/add", FormData);

  }


  UpdateCategory(id:any ,data: any) {

    return this._http.put(`https://localhost:7107/api/Category/update/${id}`, data)
  }


  GetCategoryById(id: any) {
    return this._http.get(`https://localhost:7107/api/Category/getCategorybyId/${id}`);
  }


    DeleteCategory(id: any) {
      return this._http.delete(`https://localhost:7107/api/Category/DeleteCategory/${id}`);
    }
  }



