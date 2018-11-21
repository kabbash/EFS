import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';

@Component({
  selector: 'app-products-catergories',
  templateUrl: './products-catergories.component.html',
  styleUrls: ['./products-catergories.component.css']
})
export class ProductsCatergoriesComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  productsList() {
     this.router.navigate([config.products.allProducts.route]);
  }

}
