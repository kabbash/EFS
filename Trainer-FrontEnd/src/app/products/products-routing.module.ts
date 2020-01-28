import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products.component';
import { config } from '../config/pages-config';
import { ProductsCatergoriesComponent } from './products-catergories/products-catergories.component';
import { ProductRatingComponent } from './product-rating/product-rating.component';
import { ProductsListResolver } from './resolvers/products-list.resolver';
import { ProductsCategoriesResolver } from './resolvers/products-categories.resolver';
import { ItemReviewResolver } from '../admin-tools/resolvers/item-review.resolver';
import { ProdcutRatingResolver } from './resolvers/product-rating.resolver';
import { ProductsListComponent } from '../shared/products/products-list/products-list.component';
import { ProductsSpecialListResolver } from './resolvers/products-special-list.resolver';

const routes: Routes = [
  {
    path: '',
    component: ProductsComponent,
    children: [
      {
        path: config.products.productsList.name,
        component: ProductsListComponent,
        resolve: {productList: ProductsListResolver, productSpecialList: ProductsSpecialListResolver}
      },
      {
        path: config.products.productsCategories.name,
        component: ProductsCatergoriesComponent,
        resolve: {categories: ProductsCategoriesResolver}
      },
      {
        path: config.products.productRating.name,
        component: ProductRatingComponent,
        resolve: {product: ProdcutRatingResolver}
      },
      {
        path: config.products.productReviews.name,
        component: ProductsListComponent,
        resolve: {productList: ItemReviewResolver}
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
