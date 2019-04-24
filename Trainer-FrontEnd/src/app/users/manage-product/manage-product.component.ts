import { Component, OnInit, ViewChild } from '@angular/core';
import { UsersService } from '../services/users.service';
import { config } from '../../config/pages-config';
import { finalize, first } from 'rxjs/operators';
import { productListItemDto } from '../../shared/models/products/product-list-item-dto';
import { SliderItemDto } from '../../shared/models/slider/slider-item.dto';
import { UtilitiesService } from '../../shared/services/utilities.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../../app.service';
import { ProductCategoryDTO } from '../../shared/models/products/product-category-dto';
import { ProductListItemEditComponent } from '../../shared/products/product-list-item-edit/product-list-item-edit.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-manage-product',
  templateUrl: './manage-product.component.html',
  styleUrls: ['./manage-product.component.css'],
  providers: [UsersService]
})
export class ManageProductComponent implements OnInit {

  productId: number;
  product: productListItemDto;
  originalProduct: any;
  viewMode: boolean;
  isNew: boolean;
  categories: ProductCategoryDTO[];
  @ViewChild(ProductListItemEditComponent) productListItemEditComponent: ProductListItemEditComponent;

  constructor(private route: ActivatedRoute, private router: Router, private appService: AppService,
    private service: UsersService, private util: UtilitiesService,private toastrService: ToastrService) { }

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
    this.router.navigate([config.users.productslist.route]);
  }

  add() {
    this.productListItemEditComponent.submitted = true;
    // stop here if form is invalid
    if (this.productListItemEditComponent.editForm.invalid) {
      return;
    }

    if (!this.productListItemEditComponent.product.updatedImages || !this.productListItemEditComponent.product.updatedImages.length)
    {
      this.toastrService.error('يجب ادخال صور للمنتج')
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
            this.toastrService.info("تم إضافة المنتج بنجاح");
            this.router.navigate([config.users.productslist.route]);

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
            this.toastrService.info("تم تعديل المنتج بنجاح");
            this.router.navigate([config.users.productslist.route]);
          }
        });
  }

  delete() {
    if (confirm("هل انت متأكد من مسح هذا المقال ؟ ")) {
      this.service.delete(this.productId).subscribe(c => {
        this.toastrService.info('تم مسح المقال');
        this.router.navigate([config.users.productslist.route]);
      });
    }
  }

}
