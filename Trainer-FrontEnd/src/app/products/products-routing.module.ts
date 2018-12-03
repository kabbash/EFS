import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products.component';
import { config } from '../config/pages-config';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsCatergoriesComponent } from './products-catergories/products-catergories.component';
import { ProductRatingComponent } from './product-rating/product-rating.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsComponent,
    children: [
      {
        path: config.products.productsList.name,
        component: ProductsListComponent
      },
      {
        path: config.products.productsCategories.name,
        component: ProductsCatergoriesComponent
      },
      {
        path: config.products.productRating.name,
        component: ProductRatingComponent
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
