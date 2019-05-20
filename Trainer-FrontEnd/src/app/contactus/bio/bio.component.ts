import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-bio',
  templateUrl: './bio.component.html',
  styleUrls: ['./bio.component.css']
})
export class BioComponent implements OnInit {
  opinionBanners = [];
  transformBanners = [];

  constructor() { }

  ngOnInit() {
    for (let index = 1; index < 43; index++) {

      this.transformBanners.push({
        imagePath: `assets/images/transform/${index}.jpg`
      });
    };

    for (let index = 1; index < 69; index++) {

      this.opinionBanners.push({
        imagePath: `assets/images/opinions/${index}.jpg`
      });
    };
  }
}
