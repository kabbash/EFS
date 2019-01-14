import { Component, OnInit, ViewChild } from '@angular/core';
import { config } from '../../../config/pages-config';
import { productListItemDto } from '../../../shared/models/product-list-item-dto';
import { environment } from 'src/environments/environment';
import { ddlDto } from '../../../shared/models/ddl-dto';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminProductsService } from '../../services/admin.products.service';
import { ProductsFilter } from '../../../shared/models/products-filter';
import { ModalComponent } from '../../../shared/modal/modal.component';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class AdminProductsListComponent implements OnInit {
  @ViewChild('modal') productModal: ModalComponent;
  productsList: productListItemDto[];
  baseurl = environment.filesBaseUrl;
  productsStatuses = new ddlDto();
  searchTxt: string = "";
  selectedProduct: productListItemDto;

  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminProductsService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.productsList = result.productsList.data.results;
    });

    this.productsStatuses.items = [{ value: 0, text: "الكل" }
      , { value: 1, text: "النشط" }
      , { value: 2, text: "المتوقف" }
    ]
    this.productsStatuses.selectedValue = 1;
  }

  // approve(productId){
  //   if(confirm("هل انت متأكد من الموافقه على هذا المقال ؟ ")){      
  //     this.service.approve(productId).subscribe(c=> { console.log(c); alert('approved'); });
  //   }
  // }

  //   reject(productId){
  //     if(confirm("هل انت متأكد من رفض هذا المقال ؟ ")){
  //       this.service.reject(productId).subscribe(c=> { console.log(c); alert('rejected'); });
  //     }
  // }

  reloadItems() {
    debugger;
    let productFilter: ProductsFilter = {
      pageNo: 1,
      pageSize: 10,
      searchText: this.searchTxt,
      status: this.productsStatuses.selectedValue
    };

    let filter = `?pageNo=${productFilter.pageNo}&pageSize=${productFilter.pageSize}&searchText=${productFilter.searchText}&status=${productFilter.status}`;
    this.service.getFilteredProducts(filter).subscribe(result => {
      this.productsList = result.data.results;
    });
  }

  openProductModal(product) {
    this.selectedProduct = product;
  }
}
