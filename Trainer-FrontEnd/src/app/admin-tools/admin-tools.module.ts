import { NgModule } from '@angular/core';

import { AdminToolsRoutingModule } from './admin-tools-routing.module';
import { AdminArticlesListResolver } from './resolvers/articles-list-resolver';
import { AdminToolsComponent } from './admin-tools.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCategoryComponent } from './add-category/add-category.component';
import { ManageCategoriesComponent } from './manage-categories/manage-categories.component';
import { ManageProductsCategoriesComponent } from './manage-products-categories/manage-products-categories.component';
import { ManageArticlesCategoriesComponent } from './articles/manage-articles-categories/manage-articles-categories.component';
import { ManageArticlesComponent } from './articles/manage-articles/manage-articles.component';
import { AddItemForReviewComponent } from './add-item-for-review/add-item-for-review.component';
import { ArticlesListComponent } from './articles/articles-list/articles-list.component';
import { ArticleDetailsEditmodeComponent } from '../shared/article-details-editmode/article-details-editmode.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { AdminProductsListComponent } from './products/admin-products-list/admin-products-list.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { AdminProductsListResolver } from './resolvers/products-list-resolver';
import { ManageProductsComponent } from './products/manage-products/manage-products.component';
import { ProductListItemComponent } from './products/product-list-item/product-list-item.component';
import { ProductResolver } from './resolvers/product.resolver';
import { ProductListItemEditComponent } from './products/product-list-item-edit/product-list-item-edit.component';
import { NgbUTCStringAdapter } from '../shared/services/ngb-string.adapter';
import { LeafProductCategoriesResolver } from './resolvers/product-leaf-categories.resolver';
import { AdminArticlesService } from './services/admin.articles.services';
import { UserManagementComponent } from './user-management/user-management.component';
import { RolesResolver } from './resolvers/roles-list.resolver';
import { UsersListResolver } from './resolvers/users-list.resolver';



@NgModule({
  imports: [
    AdminToolsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    NgxDatatableModule
  ],
  declarations:
    [
      AddCategoryComponent,
      AdminToolsComponent,
      ManageCategoriesComponent,
      ManageProductsCategoriesComponent,
      ManageArticlesCategoriesComponent,
      ManageArticlesComponent,
      AddItemForReviewComponent,
      ArticlesListComponent,
      ArticleDetailsEditmodeComponent,
      AdminProductsListComponent,
      ManageProductsComponent,
      ProductListItemComponent,
      ProductListItemEditComponent,
      UserManagementComponent
    ],

  providers: [
    AdminArticlesListResolver,
    AdminProductsListResolver,
    ProductResolver,
    LeafProductCategoriesResolver,
    { provide: NgbDateAdapter, useClass: NgbUTCStringAdapter },
    AdminArticlesService,
    RolesResolver,
    UsersListResolver
  ]
})
export class AdminToolsModule { }
