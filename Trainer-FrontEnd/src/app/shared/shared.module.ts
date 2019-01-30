import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { NotfoundComponent } from './notfound/notfound.component';
import { ArticlesCardComponent } from './articles-card/articles-card.component';
import { ArticlesPagingComponent } from './articles-paging/articles-paging.component';
import { ArticlesListItemComponent } from './articles-list-item/articles-list-item.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommentsComponent } from './comments/comments.component';
import { SiteMapComponent } from './site-map/site-map.component';
import { UtilitiesService } from './services/utilities.service';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FileUploaderComponent } from './file-uploader/file-uploader.component';
import { ArticleCategoriesResolver } from './resolvers/article-categories.resolver';
import { ArticleDetailsCardComponent } from './article-details-card/article-details-card.component';
import { CategoriesService } from '../admin-tools/services/categories.service';
import { ProductsCategoriesResolver } from '../products/resolvers/products-categories.resolver';
import { DropDownComponent } from './drop-down/drop-down.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { DashboardMenuComponent } from './components/dashboard-menu/dashboard-menu.component';
import { ProductReviewService } from '../admin-tools/services/product-review.service';
import { ProductsListComponent } from './products-list/products-list.component';
import { ModalComponent } from './modal/modal.component';
import { ProductResolver } from '../admin-tools/resolvers/product.resolver';
import { SliderEditModeComponent } from './slider-edit-mode/slider-edit-mode.component';
import { ArticleDetailsResolver } from '../articles/resolvers/article-details.resolver';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
  ],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    TranslateModule,
    HeaderComponent,
    FooterComponent,
    ArticlesCardComponent,
    ArticlesPagingComponent,
    ArticlesListItemComponent,
    ArticleDetailsCardComponent,
    ProductItemComponent,
    CommentsComponent,
    SiteMapComponent,
    FileUploaderComponent,
    DropDownComponent,
    DashboardMenuComponent,
    SliderEditModeComponent
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    NotfoundComponent,
    ArticlesCardComponent,
    ArticlesPagingComponent,
    ArticlesListItemComponent,
    ArticleDetailsCardComponent,
    ProductItemComponent,
    CommentsComponent,
    SiteMapComponent,
    FileUploaderComponent,
    DropDownComponent,
    DashboardMenuComponent,
    ProductsListComponent,
    ModalComponent,
    SliderEditModeComponent
  ],
  providers: [
    UtilitiesService,
    ArticleCategoriesResolver,
    CategoriesService,
    ProductsCategoriesResolver,
    ProductReviewService,
    ArticleDetailsResolver
  ]
})
export class SharedModule { }
