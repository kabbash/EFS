import { Component, OnInit, ViewChild } from '@angular/core';
import { config } from '../../../config/pages-config';
import { productListItemDto } from '../../../shared/models/product-list-item-dto';
import { ddlDto } from '../../../shared/models/ddl-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminProductsService } from '../../services/admin.products.service';
import { ProductsFilter } from '../../../shared/models/products-filter';
import { environment } from '../../../../environments/environment';
import { PagerDto } from '../../../shared/models/pager.dto';
import { SearchFilterComponent } from '../../../shared/search-filter/search-filter.component';

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
  productsFilter = new ProductsFilter();
  @ViewChild(SearchFilterComponent) searchFilterComponent: SearchFilterComponent;


  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminProductsService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.productsList.data;
      // this.pagerData.itmesCount = 6;
      this.productsList = result.productsList.data.results;
    });

    this.searchFilterComponent.filterStatuses.selectedValue = 1;
    this.productsFilter.pageNo = 1;
    this.productsFilter.pageSize = 6;
  }

  getFilter() {
    this.productsFilter.searchText = this.searchFilterComponent.searchTxt;
    this.productsFilter.status = this.searchFilterComponent.filterStatuses.selectedValue;
    this.productsFilter.pageNo = this.pagerData.currentPage;
    this.productsFilter.pageSize = this.pagerData.pageSize;
  }

  reloadItems() {
    this.getFilter();
    let filter = `?pageNo=${this.productsFilter.pageNo}&pageSize=${this.productsFilter.pageSize}&searchText=${this.productsFilter.searchText}&status=${this.productsFilter.status}`;
    this.service.getFilteredProducts(filter).subscribe(result => {
      this.productsList = result.data.results;
    });
  }

  openProductModal(product) {
    this.router.navigate([config.admin.manageProducts.route, product.id]);
  }

  addProduct() {
    this.router.navigate([config.admin.manageProducts.route, 0]);
  }

}
