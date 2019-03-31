import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { config } from '../config/pages-config';
import { UsersComponent } from './users.component';
import { ManageProductComponent } from './manage-product/manage-product.component';
import { ProductsListComponent } from './products-list/products-list.component';
import { ProductDetailsResolver } from './resolvers/product.resolver';
import { ProductsListResolver } from './resolvers/products-list-resolver';
import { LeafProductCategoriesResolver } from './resolvers/product-leaf-categories.resolver';


const routes: Routes = [
    {
        path: '',
        component: UsersComponent,
        children: [
            {
                path: config.users.manageproduct.name,
                component: ManageProductComponent,
                resolve: { productDetails: ProductDetailsResolver, productCategories: LeafProductCategoriesResolver }
            },
            {
                path: config.users.productslist.name,
                component: ProductsListComponent,   
                resolve: { productsList: ProductsListResolver }
            }
        ]
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class UsersRoutingModule { }
