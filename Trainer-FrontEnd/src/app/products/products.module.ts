import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products.component';
import { SharedModule } from '../shared/shared.module';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductsCatergoriesComponent } from './products-catergories/products-catergories.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductRatingComponent } from './product-rating/product-rating.component';
import { ProductsCategoriesResolver } from './resolvers/products-categories.resolver';
import { ProductsListResolver } from './resolvers/products-list.resolver';
import { ModalComponent } from './modal/modal.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
  ],
  declarations: [ProductsComponent, ProductsListComponent, ProductsCatergoriesComponent, ProductRatingComponent, ModalComponent],
  providers: [
    ProductsCategoriesResolver,
    ProductsListResolver
  ]
})
export class ProductsModule { }
