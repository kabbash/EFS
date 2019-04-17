import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { productListItemDto } from '../../../shared/models/products/product-list-item-dto';
import { environment } from '../../../../environments/environment';
import { ProductCategoryDTO } from '../../../shared/models/products/product-category-dto';
import { debug } from 'util';
import { UtilitiesService } from '../../../shared/services/utilities.service';
import { AuthService } from '../../../auth/services/auth.service';

@Component({
  selector: 'app-product-list-item-edit',
  templateUrl: './product-list-item-edit.component.html',
  styleUrls: ['./product-list-item-edit.component.css']
})
export class ProductListItemEditComponent implements OnInit {

  @Input() product: productListItemDto;
  baseurl = environment.filesBaseUrl;
  uploadedFile: string | ArrayBuffer;
  editForm: FormGroup;
  submitted = false;
  showProductType  = false;
  @Input() categories: ProductCategoryDTO[];

  get imageSrc() {
    if (this.uploadedFile != null && this.uploadedFile != undefined)
      return this.uploadedFile;
    else
      return this.profilePicture;
  }
  get profilePicture() {
    return (this.product.profilePicture != null
      && this.product.profilePicture != undefined
      && this.product.profilePicture != ""
      ? this.baseurl + this.product.profilePicture
      : undefined)
  }

  constructor(private fb: FormBuilder, private util: UtilitiesService, private authService: AuthService) { }

  ngOnInit() {
    let currentUser = this.authService.getUserInfo();
    this.product.phoneNumber = this.product.phoneNumber || this.product.seller.phoneNumber || currentUser.phoneNumber || "";
    this.product.seller.fullName = this.product.seller.fullName || currentUser.fullName;
    this.showProductType = this.authService.isAdmin();

    this.editForm = this.fb.group({
      name: [this.product.name, Validators.required],
      price: [this.product.price, [Validators.required, Validators.pattern(/^\d+$/)]],
      description: [this.product.description, [Validators.required]],
      // profilePicture: [this.profilePicture, [Validators.required]],
      expDate: [this.product.expDate, [Validators.required]],
      isSpecial: [this.product.isSpecial, [Validators.required]],
      categoryId: [this.product.categoryId, [Validators.required]],
      phoneNumber: [this.product.phoneNumber, Validators.required]
    });

  }

  get f() { return this.editForm.controls; }


  getData(isUpdate?: boolean) {

    let editedProduct = new productListItemDto();
    editedProduct.name = this.f.name.value;
    editedProduct.price = this.f.price.value;
    editedProduct.description = this.f.description.value;
    editedProduct.isSpecial = this.f.isSpecial.value;
    editedProduct.expDate = this.f.expDate.value;
    editedProduct.categoryId = this.f.categoryId.value;
    editedProduct.updatedImages = this.product.updatedImages;
    editedProduct.isActive = this.product.isActive;
    editedProduct.phoneNumber = this.f.phoneNumber.value;

    this.util.setSliderProfilePic(editedProduct, this.product.id == 0);

    const formData = new FormData();

    this.util.appendFormData(formData, editedProduct);
    return formData;
  }




}
