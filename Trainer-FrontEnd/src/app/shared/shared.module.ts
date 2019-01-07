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
import { DashboardMenuComponent } from './components/dashboard-menu/dashboard-menu.component';
import { ProductsListComponent } from '../products/products-list/products-list.component';
import { ModalComponent } from '../products/modal/modal.component';
import { ProductReviewService } from '../admin-tools/services/product-review.service';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    TranslateModule, HeaderComponent, FooterComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent, ArticleDetailsCardComponent,
    ProductItemComponent, CommentsComponent, SiteMapComponent, FileUploaderComponent, DropDownComponent, DashboardMenuComponent,
    ProductsListComponent, ModalComponent
  ],
  declarations: [FooterComponent, HeaderComponent, NotfoundComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent, ArticleDetailsCardComponent,
    ProductItemComponent, ProductItemComponent, CommentsComponent, SiteMapComponent, FileUploaderComponent,
    DropDownComponent, DashboardMenuComponent, ProductsListComponent, ModalComponent],
  providers: [
    UtilitiesService,
    ArticleCategoriesResolver,
    CategoriesService,
    ProductsCategoriesResolver,
    ProductReviewService
  ]
})
export class SharedModule { }
