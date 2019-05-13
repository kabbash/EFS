import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  // footerLogo = false;
  constructor(private router: Router) {
    // router.events.subscribe((val: any) => {
    //   // see also
    //   if (val && val.route && val.route.path && val.route.path === 'home') {
    //     this.footerLogo = true;
    //   } else if (val && val.route && val.route.path && val.route.path !== 'home') {
    //     this.footerLogo = false;
    //   }
    // });
  }

  ngOnInit() {
  }

}
