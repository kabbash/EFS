import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { SharedModule } from '../shared/shared.module';
import { ProductsRoutingModule } from './products-routing.module';
import { AllProductsComponent } from './all-products/all-products.component';
import { ProductsCatergoriesComponent } from './products-catergories/products-catergories.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductRatingComponent } from './product-rating/product-rating.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [ProductsComponent, AllProductsComponent, ProductsCatergoriesComponent, ProductRatingComponent]
})
export class ProductsModule { }
