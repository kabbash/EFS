import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../../app.service';
import { productListItemDto } from '../../shared/models/product-list-item-dto';
import { environment } from '../../../environments/environment';
import { RepositoryService } from '../../shared/services/repository.service';
import { config } from '../../config/pages-config';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-all-products',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {


  currentPage = 3;
  page = 4;
  pageAdvanced = 2;
  products: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  selectedProduct: productListItemDto;
  categoryId: number;
  isProductReview = false;
  @ViewChild('modal') productModal: ModalComponent;
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
    this.isProductReview = this.router.url === config.products.productReviews.route;
  }



  openProductDetails(product) {
    if (this.isProductReview) {
      this.router.navigate([config.products.productRating.route + '/' + product.id]);
    } else {
      this.selectedProduct = product;    
    }
  }
}
