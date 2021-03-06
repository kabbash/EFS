import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { SharedModule } from '../shared/shared.module';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductsCatergoriesComponent } from './products-catergories/products-catergories.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductRatingComponent } from './product-rating/product-rating.component';
import { ProductsListResolver } from './resolvers/products-list.resolver';
import { ProdcutRatingResolver } from './resolvers/product-rating.resolver';
import { ProductsSpecialListResolver } from './resolvers/products-special-list.resolver';



@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [ProductsComponent, ProductsCatergoriesComponent, ProductRatingComponent],
  providers: [
    ProductsListResolver,
    ProductsSpecialListResolver,
    ProdcutRatingResolver
  ]
})
export class ProductsModule { }
