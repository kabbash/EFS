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


@NgModule({
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    TranslateModule, HeaderComponent, FooterComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent,
    ProductItemComponent
  ],
  declarations: [FooterComponent, HeaderComponent, NotfoundComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent,
    ProductItemComponent, ProductItemComponent]
})
export class SharedModule { }
