import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FooterComponent } from 'src/app/shared/components/footer/footer.component';
import { HeaderComponent } from 'src/app/shared/components/header/header.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ArticlesCardComponent } from './articles-card/articles-card.component';
import { ArticlesPagingComponent } from './articles-paging/articles-paging.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    TranslateModule, HeaderComponent, FooterComponent, ArticlesCardComponent, ArticlesPagingComponent
  ],
  declarations: [FooterComponent, HeaderComponent, NotfoundComponent, ArticlesCardComponent, ArticlesPagingComponent]
})
export class SharedModule { }
