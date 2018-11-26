import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.css']
})
export class AllProductsComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }


  goToProductRating() {
    this.router.navigate([config.products.productRating.route]);
  }
}
