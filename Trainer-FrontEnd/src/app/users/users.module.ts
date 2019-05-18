import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsListComponent } from './products-list/products-list.component';
import { ManageProductComponent } from './manage-product/manage-product.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule, NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { UsersComponent } from './users.component';
import { ProductsListResolver } from './resolvers/products-list-resolver';
import { ProductDetailsResolver } from './resolvers/product.resolver';
import { UsersRoutingModule } from './users-routing.module';
import { LeafProductCategoriesResolver } from './resolvers/product-leaf-categories.resolver';
import { ManageProductGuard } from './guards/manage-product.guard';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    UsersRoutingModule
  ],
  declarations: [ProductsListComponent, ManageProductComponent,UsersComponent],
  providers: [ProductsListResolver,ProductDetailsResolver,LeafProductCategoriesResolver, ManageProductGuard]
})
export class UsersModule { }
