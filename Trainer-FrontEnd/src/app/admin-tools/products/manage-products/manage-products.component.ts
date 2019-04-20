import { Component, OnInit, ViewChild } from '@angular/core';
import { AdminProductsService } from '../../services/admin.products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { first, finalize } from 'rxjs/operators';
import { productListItemDto } from '../../../shared/models/products/product-list-item-dto';
import { ProductCategoryDTO } from '../../../shared/models/products/product-category-dto';
import { config } from '../../../config/pages-config';
import { AppService } from '../../../app.service';
import { UtilitiesService } from '../../../shared/services/utilities.service';
import { SliderItemDto } from '../../../shared/models/slider/slider-item.dto';
import { ErrorHandlingService } from '../../../shared/services/error-handling.service';
import { PAGES } from '../../../config/defines';
import { ProductListItemEditComponent } from '../../../shared/products/product-list-item-edit/product-list-item-edit.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-manage-products',
  templateUrl: './manage-products.component.html',
  styleUrls: ['./manage-products.component.css']
})
export class ManageProductsComponent implements OnInit {
  productId: number;
  product: productListItemDto;
  originalProduct: any;
  viewMode: boolean;
  isNew: boolean;
  categories: ProductCategoryDTO[];
  @ViewChild(ProductListItemEditComponent) productListItemEditComponent: ProductListItemEditComponent;

  constructor(private route: ActivatedRoute, private router: Router, private appService: AppService,private toastrService : ToastrService,
    private service: AdminProductsService, private util: UtilitiesService, private errorHandlingService: ErrorHandlingService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.productId = params['productId'];
      this.route.data.subscribe(result => {
        this.categories = result.productCategories.data;
        this.categories = this.categories.filter(c => c.hasSubCategory == null || !c.hasSubCategory);
      });
      if (this.productId > 0) {
        this.route.data.subscribe(result => {
          this.originalProduct = result.productDetails.data;
          this.product = result.productDetails.data;
          this.product.updatedImages = new Array<SliderItemDto>()
          this.appService.loading = false;
          this.viewMode = true;
        });
      }
      else {
        this.product = new productListItemDto();
        this.viewMode = false;
        this.isNew = true;
      }
    });
  }

  openEditForm() {
    this.viewMode = false;
  }

  cancelUpdates() {
    this.viewMode = true;
  }
  cancelAdd() {
    this.router.navigate([config.admin.ProductsList.route]);
  }

  add() {
    this.productListItemEditComponent.submitted = true;
    // stop here if form is invalid
    if (false) {
      return;
    }

    this.appService.loading = true;

    this.service.add(this.productListItemEditComponent.getData())
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          if (data.status === 200) {
            this.product = data.data;
            this.viewMode = true;
            this.isNew = false;
            this.productId = this.product.id;
            this.product.categoryName = this.categories.find(c => c.id === this.product.categoryId).name;
            this.toastrService.info("تم إضافة المنتج بنجاح");
            this.router.navigate([config.admin.ProductsList.route]);

          }
        }, error => {
          this.errorHandlingService.handle(error, PAGES.PRODUCTS);
        });
  }

  update() {
    this.productListItemEditComponent.submitted = true;
    if (this.productListItemEditComponent.editForm.invalid) {
      return;
    }
    this.appService.loading = true;
    this.service.update(this.productId, this.productListItemEditComponent.getData(true))
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      }))
      .subscribe(
        data => {
          if (data.status === 200) {
            this.product = data.data;
            this.viewMode = true;
            this.toastrService.info("تم تعديل المنتج بنجاح");
            this.router.navigate([config.admin.ProductsList.route]); 
            
          }
        }, error => {
          this.errorHandlingService.handle(error, PAGES.PRODUCTS);
        });
  }

  approve() {
    if (confirm("هل انت متأكد من الموافقه على هذا المنتج ؟ ")) {
      this.service.approve(this.productId).subscribe(c => { 
        this.toastrService.info('تمت الموافقه على المنتج');
        this.product.isActive = true;
      }, error => {
        this.errorHandlingService.handle(error, PAGES.PRODUCTS);
      } );
    }
  }

  reject() {
    if (confirm("هل انت متأكد من رفض هذا المنتج ؟ ")) {
      this.service.reject(this.productId, prompt("من فضلك ، ادخل سبب الرفض؟")).subscribe(c => { 
        this.toastrService.info('تم رفض المنتج');
        this.product.isActive = false;
       }, error => {
        this.errorHandlingService.handle(error, PAGES.PRODUCTS);
      });
    }
  }

  delete() {
    if (confirm("هل انت متأكد من مسح هذا المنتج ؟ ")) {
      this.service.delete(this.productId).subscribe(c => { 
        console.log(c);
        this.toastrService.info('تم مسح المنتج');
        this.router.navigate([config.admin.ProductsList.route]); 
      }, error => {
        this.errorHandlingService.handle(error, PAGES.PRODUCTS);
      });
    }
  }

}
