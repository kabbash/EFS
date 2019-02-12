import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../../app.service';
import { productListItemDto } from '../models/products/product-list-item-dto';
import { environment } from '../../../environments/environment';
import { RepositoryService } from '../../shared/services/repository.service';
import { config } from '../../config/pages-config';
import { ProductReviewService } from '../../admin-tools/services/product-review.service';
import { PagerDto } from '../../shared/models/pager.dto';
import { ModalComponent } from '../modal/modal.component';
import { ProductsService } from '../../products/products.service';
import { ClientFilterComponent } from '../client-filter/client-filter.component';

@Component({
  selector: 'app-all-products',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  selectedProduct: productListItemDto;
  categoryId: number;
  categoryDescription: string;
  isProductReview = false;
  isManageProductReview = false;
  pagerData: PagerDto;
  nextPageUrl: string;
  @ViewChild(ClientFilterComponent) searchFilterComponent: ClientFilterComponent;

  @ViewChild('modal') productModal: ModalComponent;
  constructor(private router: Router, private route: ActivatedRoute,
    private repositoryService: RepositoryService,
    private appService: AppService,
    private productsService: ProductsService,
    private productReviewService: ProductReviewService) {
    this.route.params.subscribe(params => {
      this.categoryId = params['categoryId'];
    });
    this.categoryDescription = this.productsService.selectedCategory ? this.productsService.selectedCategory.description : '';
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.productList.data;
      this.productReviewService.productReviewList = result.productList.data.results;
      this.products = this.productReviewService.productReviewList;
      this.appService.loading = false;
    });
    this.isProductReview = this.router.url === config.products.productReviews.route;
    this.isManageProductReview = this.router.url === config.admin.itemReviewList.route;
    this.nextPageUrl = (this.isProductReview || this.isManageProductReview) ? 'itemsreview' : 'products'

  }



  openProductDetails(product) {
    if (this.isProductReview) {
      this.router.navigate([config.products.productRating.route + '/' + product.id]);
    } else {
      this.selectedProduct = product;
    }
  }

  gotoAddProductReview() {
    this.router.navigate([config.admin.addItemForReview.route]);
  }

  getNextPage() {
    this.appService.loading = true;
    this.repositoryService.getData(`${this.nextPageUrl}?pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&categoryId=${this.categoryId}`).subscribe((data: any) => {
      this.pagerData = data.data;
      this.productReviewService.productReviewList = data.data.results;
      this.products = this.productReviewService.productReviewList;
      this.appService.loading = false;
    }, error => {
      this.appService.loading = false;
    });
  }

  filterItems() {
    this.pagerData.currentPage = 1;
    this.getNextPage();
  }
}
