import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminToolsComponent } from './admin-tools.component';
import { config } from '../config/pages-config';
import { AdminArticlesListResolver } from './resolvers/articles-list-resolver';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';
import { ArticleDetailsResolver } from '../articles/resolvers/article-details.resolver';
import { ArticleCategoriesResolver } from '../shared/resolvers/article-categories.resolver';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';
import { ProductsCategoriesResolver } from '../products/resolvers/products-categories.resolver';
import { AddItemForReviewComponent } from './add-item-for-review/add-item-for-review.component';
import { ItemReviewResolver } from './resolvers/item-review.resolver';
import { ArticlesListComponent } from './articles/articles-list/articles-list.component';
import { AdminProductsListComponent } from './products/admin-products-list/admin-products-list.component';
import { AdminProductsListResolver } from './resolvers/products-list-resolver';
import { ProductsListComponent } from '../shared/products-list/products-list.component';
import { ManageProductsComponent } from './products/manage-products/manage-products.component';
import { ProductResolver } from './resolvers/product.resolver';
import { LeafProductCategoriesResolver } from './resolvers/product-leaf-categories.resolver';
import { UserManagementComponent } from './user-management/user-management.component';

import { RolesResolver } from './resolvers/roles-list.resolver';
import { UsersListResolver } from './resolvers/users-list.resolver';


const routes: Routes = [
  {
    path: '',
    component: AdminToolsComponent,
    children: [
      {
        path: config.admin.manageArticlesCategories.name,
        component: ManageArticlesCategoriesComponent,
        resolve: { categories: ArticleCategoriesResolver }
      },
      {
        path: config.admin.addCategory.name,
        component: AddCategoryComponent
      },

      {
        path: config.admin.manageArticles.name,
        component: ManageArticlesComponent,
        resolve: { articleDetails: ArticleDetailsResolver }
      },
      {
        path: config.admin.articleslist.name,
        component: ArticlesListComponent,
        resolve: { articlesList: AdminArticlesListResolver }
      },
      {
        path: config.admin.manageProductsCategories.name,
        component: ManageProductsCategoriesComponent,
        resolve: { categories: ProductsCategoriesResolver }
      },
      {
        path: config.admin.addItemForReview.name,
        component: AddItemForReviewComponent
      }
      ,
      {
        path: config.admin.itemReviewList.name,
        component: ProductsListComponent,
        resolve: { productList: ItemReviewResolver }
      },
      {
        path: config.admin.manageProducts.name,
        component: ManageProductsComponent,
        resolve: { productDetails: ProductResolver, productCategories: LeafProductCategoriesResolver }
      },
      {
        path: config.admin.ProductsList.name,
        component: AdminProductsListComponent,
        resolve: { productsList: AdminProductsListResolver }
      },
      {
        path: config.admin.users.name,
        component: UserManagementComponent,
        resolve: { users: UsersListResolver}
      }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminToolsRoutingModule { }
