import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { NotfoundComponent } from './notfound/notfound.component';
import { ArticlesCardComponent } from './articles/articles-card/articles-card.component';
import { ArticlesPagingComponent } from './articles-paging/articles-paging.component';
import { ArticlesListItemComponent } from './articles/articles-list-item/articles-list-item.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommentsComponent } from './comments/comments.component';
import { SiteMapComponent } from './site-map/site-map.component';
import { UtilitiesService } from './services/utilities.service';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FileUploaderComponent } from './file-uploader/file-uploader.component';
import { ArticleCategoriesResolver } from './resolvers/article-categories.resolver';
import { ArticleDetailsCardComponent } from './articles/article-details-card/article-details-card.component';
import { CategoriesService } from '../admin-tools/services/categories.service';
import { ProductsCategoriesResolver } from '../products/resolvers/products-categories.resolver';
import { DropDownComponent } from './drop-down/drop-down.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { DashboardMenuComponent } from './components/dashboard-menu/dashboard-menu.component';
import { ProductReviewService } from '../admin-tools/services/product-review.service';
import { ModalComponent } from './modal/modal.component';
import { SliderEditModeComponent } from './slider-edit-mode/slider-edit-mode.component';
import { ArticleDetailsResolver } from '../articles/resolvers/article-details.resolver';
import { SearchFilterComponent } from './search-filter/search-filter.component';
import { ProductsService } from '../products/products.service';
import { ClientFilterComponent } from './client-filter/client-filter.component';
import { ErrorHandlingService } from '../shared/services/error-handling.service';
import { ImageCropperModule } from 'ngx-image-cropper';
import { ImageCropperComponent } from './image-cropper/image-cropper.component';
import { ArticleDetailsEditmodeComponent } from './articles/article-details-editmode/article-details-editmode.component';
import { ProductsListComponent } from './products/products-list/products-list.component';
import { ProductItemComponent } from './products/product-item/product-item.component';
import { ProductListItemEditComponent } from './products/product-list-item-edit/product-list-item-edit.component';
import { ProductListItemComponent } from './products/product-list-item/product-list-item.component';
import { ScrollbarHelper } from '@swimlane/ngx-datatable/release/services';
import { ServerScrollBarHelper } from './services/ServerScrollBarHelper';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
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
    ImageCropperModule,
    NgxDatatableModule
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
    ArticleDetailsEditmodeComponent,
    ProductListItemComponent,
    ProductListItemEditComponent,
    ProductItemComponent,
    CommentsComponent,
    SiteMapComponent,
    FileUploaderComponent,
    DropDownComponent,
    DashboardMenuComponent,
    SliderEditModeComponent,
    SearchFilterComponent,
    ClientFilterComponent,
    ImageCropperModule,
    ImageCropperComponent,
    NgxDatatableModule
  ],
  declarations: [
    FooterComponent,
    HeaderComponent,
    NotfoundComponent,
    ArticlesCardComponent,
    ArticlesPagingComponent,
    ArticlesListItemComponent,
    ArticleDetailsCardComponent,
    ArticleDetailsEditmodeComponent,
    ProductListItemComponent,
    ProductListItemEditComponent,
    ProductItemComponent,
    CommentsComponent,
    SiteMapComponent,
    FileUploaderComponent,
    DropDownComponent,
    DashboardMenuComponent,
    ProductsListComponent,
    ModalComponent,
    SliderEditModeComponent,
    SearchFilterComponent,
    ClientFilterComponent,
    ImageCropperComponent
  ],
  providers: [
    UtilitiesService,
    ArticleCategoriesResolver,
    CategoriesService,
    ProductsCategoriesResolver,
    ProductReviewService,
    ArticleDetailsResolver,
    ProductsService,
    ErrorHandlingService,
    {
      provide: ScrollbarHelper,
      useClass: ServerScrollBarHelper
    }
  ]
})
export class SharedModule { }
