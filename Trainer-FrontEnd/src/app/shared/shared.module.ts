import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { FooterComponent } from 'src/app/shared/components/footer/footer.component';
import { HeaderComponent } from 'src/app/shared/components/header/header.component';
import { NotfoundComponent } from './notfound/notfound.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    TranslateModule, HeaderComponent, FooterComponent
  ],
  declarations: [FooterComponent, HeaderComponent, NotfoundComponent]
})
export class SharedModule { }
