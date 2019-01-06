import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminToolsComponent } from './admin-tools.component';
import { config } from '../config/pages-config';
import { PendingApprovalArticlesComponent } from './articles/pending-approval-articles/pending-approval-articles.component';
import { PendingApprovalArticlesResolver } from './resolvers/pending-approval-articles-resolver';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';
import { ArticleDetailsResolver } from '../articles/resolvers/article-details.resolver';
import { ArticleCategoriesResolver } from '../shared/resolvers/article-categories.resolver';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';
import { ProductsCategoriesResolver } from '../products/resolvers/products-categories.resolver';
import { AddItemForReviewComponent } from './add-item-for-review/add-item-for-review.component';
import { ProductsListComponent } from 'src/app/products/products-list/products-list.component';
import { ItemReviewResolver } from './resolvers/item-review.resolver';

const routes: Routes = [
  {
    path: '',
    component: AdminToolsComponent
  },
  {
    path: config.admin.addCategory.name,
    component: AddCategoryComponent
  },
  {
    path: config.admin.manageArticlesCategories.name,
    component: ManageArticlesCategoriesComponent,
    resolve: { categories: ArticleCategoriesResolver }
  },
  {
    path: config.admin.manageArticles.name,
    component: ManageArticlesComponent,
    resolve: {articleDetails: ArticleDetailsResolver}
  },
  {
    path: config.admin.pendingApprovalArticles.name,
    component: PendingApprovalArticlesComponent,
    resolve: { articlesList: PendingApprovalArticlesResolver }
  },
  {
    path: config.admin.manageProductsCategories.name,
    component: ManageProductsCategoriesComponent,
    resolve: {categories: ProductsCategoriesResolver}
  },
  {
    path: config.admin.addItemForReview.name,
    component: AddItemForReviewComponent
  },
  {
    path: config.admin.itemReviewList.name,
    component: ProductsListComponent,
    resolve: {productList: ItemReviewResolver}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminToolsRoutingModule { }
