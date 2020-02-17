import { Component, OnInit, ViewChild } from '@angular/core';
import { config } from '../../../config/pages-config';
import { productListItemDto } from '../../../shared/models/products/product-list-item-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminProductsService } from '../../services/admin.products.service';
import { environment } from '../../../../environments/environment';
import { PagerDto } from '../../../shared/models/pager.dto';
import { SearchFilterComponent } from '../../../shared/search-filter/search-filter.component';
import { AppService } from '../../../../app/app.service';

@Component({
  selector: 'app-admin-products-list',
  templateUrl: './admin-products-list.component.html',
  styleUrls: ['./admin-products-list.component.css']
})
export class AdminProductsListComponent implements OnInit {
  productsList: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  selectedProduct: productListItemDto;
  pagerData: PagerDto;
  private pageSize = environment.productsForAdminPageSize;

  @ViewChild(SearchFilterComponent) searchFilterComponent: SearchFilterComponent;


  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminProductsService, private appService: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.productsList.data;
      this.productsList = result.productsList.data.results;
    });

    this.searchFilterComponent.filterStatuses.selectedValue = 1;
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
    this.router.navigate([config.admin.manageProducts.route, product.id]);
  }

  addProduct() {
    this.router.navigate([config.admin.manageProducts.route, 0]);
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
