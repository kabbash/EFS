import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Trainer-FrontEnd';
  constructor(translate: TranslateService, public appService: AppService) {
    translate.setDefaultLang('ar');
    translate.use('ar');
  }
}
