import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../../../app.service';
import { productListItemDto } from '../../models/products/product-list-item-dto';
import { environment } from '../../../../environments/environment';
import { RepositoryService } from '../../../shared/services/repository.service';
import { config } from '../../../config/pages-config';
import { ProductReviewService } from '../../../admin-tools/services/product-review.service';
import { PagerDto } from '../../../shared/models/pager.dto';
import { ModalComponent } from '../../modal/modal.component';
import { ProductsService } from '../../../products/products.service';
import { ClientFilterComponent } from '../../client-filter/client-filter.component';
import { RatingDto } from '../../models/rating.dto';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-all-products',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products: productListItemDto[];
  specialProducts: productListItemDto[];
  filteredSpecialProducts: productListItemDto[];
  currentPageSpecialProducts: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  selectedProduct: productListItemDto;
  categoryId: number;
  categoryDescription: string;
  isProductReview = false;
  isManageProductReview = false;
  hasSpecialProducts = false;
  pagerData: PagerDto;
  nextPageUrl: string;
  hasItems = false;
  specialProductsPageSize: number = environment.specialProductsForAnyPageSize;

  @ViewChild(ClientFilterComponent) searchFilterComponent: ClientFilterComponent;

  @ViewChild('modal') productModal: ModalComponent;
  constructor(private router: Router, private route: ActivatedRoute,
    private repositoryService: RepositoryService,
    private appService: AppService,
    private productsService: ProductsService,
    private toastr: ToastrService,
    private productReviewService: ProductReviewService) {
    this.route.params.subscribe(params => {
      this.categoryId = params['categoryId'];
    });
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.productList.data;
      this.specialProducts = result.productSpecialList ? result.productSpecialList.data.results : [];
      this.currentPageSpecialProducts = this.specialProducts.slice(0, this.specialProductsPageSize);
      this.productReviewService.productReviewList = result.productList.data.results;
      this.products = this.productReviewService.productReviewList;
      this.hasItems = (this.productReviewService.productReviewList && this.productReviewService.productReviewList.length > 0)
        || this.specialProducts.length > 0;

      this.categoryDescription = this.productsService.selectedCategory ? this.productsService.selectedCategory.description : '';
      this.appService.loading = false;

      if (this.router.url !== config.products.productReviews.route && this.router.url !== config.admin.itemReviewList.route) {
        this.hasSpecialProducts = this.currentPageSpecialProducts.length > 0;
        if (this.currentPageSpecialProducts.length < 8) {
          let adsCount = 8 - this.currentPageSpecialProducts.length;
          for (let index = 0; index < adsCount; index++) {
            let p = new productListItemDto();
            p.isForAd = true;
            this.currentPageSpecialProducts.push(p);
          }
        }
      }
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
      //console.log(product);
    }
  }

  gotoAddProductReview() {
    this.router.navigate([config.admin.addItemForReview.route]);
  }

  setSpecialProducts() {

    if (this.searchFilterComponent.searchTxt)
      this.filteredSpecialProducts = this.specialProducts.filter(c => c.name.indexOf(this.searchFilterComponent.searchTxt) != -1);
    else
      this.filteredSpecialProducts = Object.assign([], this.specialProducts);

    if (this.pagerData.currentPage <= 3) {  //this.filteredSpecialProducts.length
      this.currentPageSpecialProducts = this.filteredSpecialProducts.slice(((this.pagerData.currentPage - 1) * this.specialProductsPageSize), this.pagerData.currentPage * this.specialProductsPageSize);

      this.hasSpecialProducts = this.currentPageSpecialProducts.length > 0;
      if (this.currentPageSpecialProducts.length < 8) {
        let adsCount = 8 - this.currentPageSpecialProducts.length;
        for (let index = 0; index < adsCount; index++) {
          let p = new productListItemDto();
          p.isForAd = true;
          this.currentPageSpecialProducts.push(p);
        }
      }
    }
    else
      this.currentPageSpecialProducts = [];
  }
  getNextPage() {
    this.appService.loading = true;

    if (this.nextPageUrl === 'products')
      this.setSpecialProducts();

    this.repositoryService.getData(`${this.nextPageUrl}?isSpecial=false&pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&categoryId=${this.categoryId}`).subscribe((data: any) => {
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


  rateUpdated(event) {

    let rateDto = new RatingDto();
    this.appService.loading = true;
    rateDto.entityId = event.productId;
    rateDto.rate = event.rate;
    this.repositoryService.create('products/addrate', rateDto).subscribe(data => {
      this.toastr.info('تم تعديل التقييم');
      this.appService.loading = false;
    }, error => {
      this.toastr.error(error);
      this.appService.loading = false;
    });
  }
}
