import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { productListItemDto } from '../../../shared/models/products/product-list-item-dto';
import { environment } from '../../../../environments/environment';
import { ProductCategoryDTO } from '../../../shared/models/products/product-category-dto';
import { debug } from 'util';
import { UtilitiesService } from 'src/app/shared/services/utilities.service';

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

  constructor(private fb: FormBuilder, private util: UtilitiesService) { }

  ngOnInit() {
    this.editForm = this.fb.group({
      name: [this.product.name, Validators.required],
      price: [this.product.price, [Validators.required, Validators.pattern(/^\d+$/)]],
      description: [this.product.description, [Validators.required]],
      // profilePicture: [this.profilePicture, [Validators.required]],
      expDate: [this.product.expDate, [Validators.required]],
      isSpecial: [this.product.isSpecial, [Validators.required]],
      categoryId: [this.product.categoryId, [Validators.required]]
    });

  }

  get f() { return this.editForm.controls; }

  getData() {

    // let profilePicture = this.product.profilePicture;
    // if (this.uploadedFile != null && this.uploadedFile != undefined)
    //   profilePicture = this.uploadedFile.toString();
    // const formData = new FormData();
    // formData.append('name', this.f.name.value);
    // formData.append('price', this.f.price.value);
    // formData.append('description', this.f.description.value);
    // formData.append('isSpecial', this.f.isSpecial.value);
    // formData.append('expDate', this.f.expDate.value);
    // formData.append('categoryId', this.f.categoryId.value);
    // formData.append('profilePicture', profilePicture);
    // formData.append('updatedImages', this.product.updatedImages);

    let editedProduct = new productListItemDto();
    editedProduct.name = this.f.name.value;
    editedProduct.price = this.f.price.value;
    editedProduct.description = this.f.description.value;
    editedProduct.isSpecial = this.f.isSpecial.value;
    editedProduct.expDate = this.f.expDate.value;
    editedProduct.categoryId = this.f.categoryId.value;
    editedProduct.images = this.product.images;
    editedProduct.updatedImages = this.product.updatedImages;

    this.util.setSliderProfilePic(editedProduct, this.product.id == 0);

    const formData = new FormData();
    this.util.appendFormData(formData, editedProduct);
    return formData;
  }




}
