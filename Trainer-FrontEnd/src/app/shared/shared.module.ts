import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ArticlesCardComponent } from './articles-card/articles-card.component';
import { ArticlesPagingComponent } from './articles-paging/articles-paging.component';
import { ArticlesListItemComponent } from './articles-list-item/articles-list-item.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    TranslateModule, HeaderComponent, FooterComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent
  ],
  declarations: [FooterComponent, HeaderComponent, NotfoundComponent,
    ArticlesCardComponent, ArticlesPagingComponent, ArticlesListItemComponent]
})
export class SharedModule { }
