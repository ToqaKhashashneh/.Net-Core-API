import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditCategoryComponent } from './edit-category/edit-category.component';
import { CategoryComponent } from './category/category.component';
import { AddCategoryComponent } from './add-category/add-category.component';
import { CategoryDetailsComponent } from './category-details/category-details.component';


const routes: Routes = [
  { path: "AllCategories", component: CategoryComponent },
  { path: "EditCategory/:id", component: EditCategoryComponent },
  { path: "AddCategory", component: AddCategoryComponent },
  { path: "CategoryDetails/:id", component: CategoryDetailsComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
