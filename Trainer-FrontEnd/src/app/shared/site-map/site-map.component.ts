import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-site-map',
  templateUrl: './site-map.component.html',
  styleUrls: ['./site-map.component.css']
})
export class SiteMapComponent implements OnInit {

  map = [{ name: 'المقالات', route: 'go to route' },
  { name: 'العضضلات', route: 'go to route' },
  { name: 'السمانه', route: 'go to route' }];

  constructor() { }

  ngOnInit() {
  }

}
