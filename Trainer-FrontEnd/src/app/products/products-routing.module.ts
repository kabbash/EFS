import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products.component';
import { config } from '../config/pages-config';
import { AllProductsComponent } from './all-products/all-products.component';
import { ProductsCatergoriesComponent } from './products-catergories/products-catergories.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsComponent,
    children: [
      {
        path: config.products.allProducts.name,
        component: AllProductsComponent
      },
      {
        path: config.products.productsCategories.name,
        component: ProductsCatergoriesComponent
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
