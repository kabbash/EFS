import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-site-map',
  templateUrl: './site-map.component.html',
  styleUrls: ['./site-map.component.css']
})
export class SiteMapComponent implements OnInit {
  @Input() map = [];

  constructor(private router: Router) { }

  ngOnInit() {
  }

  navigateTo(route, index) {
    if (index === this.map.length - 1) {
      return;
    }
    this.router.navigate([route]);
  }

}
