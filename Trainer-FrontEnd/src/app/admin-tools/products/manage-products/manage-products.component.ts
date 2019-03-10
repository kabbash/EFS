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
import { ProductListItemEditComponent } from '../../../shared/products/product-list-item-edit/product-list-item-edit.component';

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

  constructor(private route: ActivatedRoute, private router: Router, private appService: AppService,
    private service: AdminProductsService, private util: UtilitiesService) { }

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
    if (this.productListItemEditComponent.editForm.invalid) {
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
            this.product.categoryName = this.categories.find(c => c.id == this.product.categoryId).name;
            alert("تم إضافة المنتج بنجاح");
            this.router.navigate([config.admin.ProductsList.route]); 
            
          }
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
            alert("تم تعديل المنتج بنجاح");
            this.router.navigate([config.admin.ProductsList.route]); 
            
          }
        });
  }

  approve() {
    if (confirm("هل انت متأكد من الموافقه على هذا المنتج ؟ ")) {
      this.service.approve(this.productId).subscribe(c => { 
        console.log(c);
        alert('approved'); 
        this.product.isActive = true;   
      });
    }
  }

  reject() {
    if (confirm("هل انت متأكد من رفض هذا المنتج ؟ ")) {
      this.service.reject(this.productId, prompt("من فضلك ، ادخل سبب الرفض؟")).subscribe(c => { 
        console.log(c); 
        alert('rejected');
        this.product.isActive = false;
        
       });
    }
  }

  delete() {
    if (confirm("هل انت متأكد من مسح هذا المقال ؟ ")) {
      this.service.delete(this.productId).subscribe(c => { 
        console.log(c);
        alert('deleted');
        this.router.navigate([config.admin.ProductsList.route]); 
      });
    }
  }

}
