import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { config } from 'src/app/config/pages-config';
import { environment } from 'src/environments/environment';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { productListItemDto } from 'src/app/shared/models/product-list-item-dto';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-all-products',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  products: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  categoryId: number;
  constructor(private router: Router, private route: ActivatedRoute,
     private repositoryService: RepositoryService,
     private appService: AppService) {
    this.route.params.subscribe(params => {
      this.categoryId = params['categoryId'];
    });
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.products = result.productList.data;
      this.appService.loading = false;
    });
    this.getProducts();
  }

  getProducts() {
    this.repositoryService.getData<productListItemDto[]>('products/category/' + this.categoryId).subscribe(result => {
      this.products = result.data;
      console.log(this.products);
    });
  }

  goToProductRating() {
    this.router.navigate([config.products.productRating.route]);
  }
}
