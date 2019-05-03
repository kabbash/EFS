import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AppService } from './app.service';
import { Router, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Trainer-FrontEnd';
  constructor(translate: TranslateService, public appService: AppService, private router: Router, private toaster: ToastrService) {
    translate.setDefaultLang('ar');
    translate.use('ar');
  }
  ngOnInit() {
    if (!this.appService.isBrowser()) {
      this.toaster.clear();
    }
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.appService.loading = true;
      }
      if (event instanceof NavigationEnd) {
        this.appService.loading = false;
      }
      if (event instanceof NavigationCancel) {
        this.appService.loading = false;
      }
      if (event instanceof NavigationError) {
        this.appService.loading = false;
      }
    });
  }
}
