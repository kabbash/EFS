import { Component, OnInit, ViewChild } from '@angular/core';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { environment } from '../../../environments/environment';
import { PagerDto } from '../../shared/models/pager.dto';
import { SearchFilterComponent } from '../../shared/search-filter/search-filter.component';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../../app.service';
import { UsersService } from '../services/users.service';
import { config } from '../../config/pages-config';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
  providers: [UsersService]
})
export class ProductsListComponent implements OnInit {

  productsList: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  selectedProduct: productListItemDto;
  pagerData: PagerDto;
  hasItems = false;
  private pageSize = environment.productsForAdminPageSize;

  @ViewChild(SearchFilterComponent) searchFilterComponent: SearchFilterComponent;


  constructor(private route: ActivatedRoute,
    private router: Router, private service: UsersService, private appService: AppService) { }

  ngOnInit() {

    this.route.data.subscribe(result => {
      this.pagerData = result.productsList.data;
      this.productsList = result.productsList.data.results;
      this.hasItems = result.productsList.data.results.length > 0 ;
    });

    // this.searchFilterComponent.filterStatuses.selectedValue = 1;
  }

  reloadItems() {
    this.appService.loading = true;
    let filter = `?pageNo=1&pageSize=${this.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&status=${this.searchFilterComponent.filterStatuses.selectedValue}`;
    this.service.getFilteredProducts(filter).subscribe(result => {
      this.productsList = result.data.results;
      this.pagerData = result.data;
      this.appService.loading = false;
    });
  }

  openProductModal(product) {
    this.router.navigate([config.users.manageproduct.route, product.id]);
  }

  addProduct() {
    this.router.navigate([config.users.manageproduct.route, 0]);
  }

  getNextPage() {

    this.appService.loading = true;
    let filter = `?pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&status=${this.searchFilterComponent.filterStatuses.selectedValue}`;
    this.service.getFilteredProducts(filter).subscribe((response: any) => {

      this.productsList = response.data.results;
      this.pagerData = response.data;
      this.appService.loading = false;
    });
  }

}
