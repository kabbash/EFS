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
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { AdminProductsListComponent } from './products/admin-products-list/admin-products-list.component';
import { NgbModule, NgbPaginationModule, NgbAlertModule, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { AdminProductsListResolver } from './resolvers/products-list-resolver';
import { ManageProductsComponent } from './products/manage-products/manage-products.component';
import { ProductResolver } from './resolvers/product.resolver';
import { NgbUTCStringAdapter } from '../shared/services/ngb-string.adapter';
import { LeafProductCategoriesResolver } from './resolvers/product-leaf-categories.resolver';
import { AdminArticlesService } from './services/admin.articles.services';
import { AddBannerComponent } from './add-banner/add-banner.component';
import { ManageBannerService } from './services/manage-banner.service';
import { ManageBannersComponent } from './manage-banners/manage-banners.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { RolesResolver } from './resolvers/roles-list.resolver';
import { UsersListResolver } from './resolvers/users-list.resolver';
import { BrowserModule } from '@angular/platform-browser';
import { ManageNeutrintsComponent } from './neutrints/manage-neutrints/manage-neutrints.component';
import { FoodItemsListComponent } from './neutrints/food-items-list/food-items-list.component';
import { FoodItemResolver } from './resolvers/food-item-resolver';
import { FoodItemsListResolver } from './resolvers/food-items-list.resolver';
import { ManageOnlineTrainingComponent } from './manage-online-training/manage-online-training.component';
import { TrainingResolver } from './resolvers/training-resolver';
import { ManageProgramsComponent } from './manage-programs/manage-programs.component';
import { ProgramDetailsResolver } from './resolvers/program-details-resolver';



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
    NgbAlertModule
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
      AdminProductsListComponent,
      ManageProductsComponent,
      // ProductListItemComponent,
      // ProductListItemEditComponent,
      AddBannerComponent,
      ManageBannersComponent,
      // ProductListItemEditComponent,
      UserManagementComponent,
      ManageNeutrintsComponent,
      FoodItemsListComponent,
      ManageOnlineTrainingComponent,
      ManageProgramsComponent
    ],

  providers: [
    AdminArticlesListResolver,
    AdminProductsListResolver,
    ProductResolver,
    TrainingResolver,
    LeafProductCategoriesResolver,
    ProgramDetailsResolver,
    { provide: NgbDateAdapter, useClass: NgbUTCStringAdapter },

    AdminArticlesService,
    ManageBannerService,
    RolesResolver,
    UsersListResolver,
    FoodItemResolver,
    FoodItemsListResolver
  ]
})
export class AdminToolsModule { }
