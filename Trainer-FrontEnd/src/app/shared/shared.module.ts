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
import {RouterModule} from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    RouterModule
  ],
  exports: [
    TranslateModule, HeaderComponent, FooterComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent,
    ProductItemComponent, CommentsComponent, SiteMapComponent
  ],
  declarations: [FooterComponent, HeaderComponent, NotfoundComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent,
    ProductItemComponent, ProductItemComponent, CommentsComponent, SiteMapComponent],
  providers: [
    UtilitiesService
  ]
})
export class SharedModule { }
