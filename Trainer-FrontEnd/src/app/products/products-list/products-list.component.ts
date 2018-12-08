import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../../app.service';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
import { environment } from '../../../environments/environment';
import { RepositoryService } from '../../shared/services/repository.service';
import { config } from '../../config/pages-config';

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
  }



  goToProductRating() {
    this.router.navigate([config.products.productRating.route]);
  }
}
