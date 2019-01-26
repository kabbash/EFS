import { Component, OnInit, Input } from '@angular/core';
import { productListItemDto } from 'src/app/shared/models/product-list-item-dto';
import { environment } from 'src/environments/environment';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { ProductCategoryDTO } from 'src/app/shared/models/product-category-dto';

@Component({
  selector: 'app-product-list-item-edit',
  templateUrl: './product-list-item-edit.component.html',
  styleUrls: ['./product-list-item-edit.component.css']
})
export class ProductListItemEditComponent implements OnInit {

  @Input() product: productListItemDto
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

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.editForm = this.fb.group({
      name: [this.product.name, Validators.required],
      price: [this.product.price, [Validators.required, Validators.pattern(/^\d+$/)]],
      description: [this.product.description, [Validators.required]],
      profilePicture: [this.profilePicture, [Validators.required]],
      expDate: [this.product.expDate, [Validators.required]],
      isSpecial: [this.product.isSpecial, [Validators.required]],
      categoryId: [this.product.categoryId, [Validators.required]]
    });

  }

  // convenience getter for easy access to form fields
  get f() { return this.editForm.controls; }

  readURL(event?: HTMLInputEvent): void {
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];
      this.product.profilePictureFile = file;

      const reader = new FileReader();
      reader.onload = e => this.uploadedFile = reader.result;

      reader.readAsDataURL(file);
    }
  }

  getData() {
    let profilePicture = this.product.profilePicture;
    if (this.uploadedFile != null && this.uploadedFile != undefined)
      profilePicture = this.uploadedFile.toString();
    const formData = new FormData();
    formData.append('name', this.f.name.value);
    formData.append('profilePictureFile', this.product.profilePictureFile);
    formData.append('price', this.f.price.value);
    formData.append('description', this.f.description.value);
    formData.append('isSpecial', this.f.isSpecial.value);
    formData.append('expDate', this.f.expDate.value);
    formData.append('categoryId', this.f.categoryId.value);
    formData.append('profilePicture', profilePicture);

    return formData;
    // var product = new productListItemDto()
    // product.name = this.f.name.value;
    // product.profilePictureFile = this.product.profilePictureFile;
    // product.price = this.f.price.value;
    // product.description = this.f.description.value;
    // product.isSpecial = this.f.isSpecial.value;
    // product.expDate = this.f.expDate.value;
    // product.categoryId = this.f.categoryId.value;
    // product.profilePicture = this.uploadedFile.toString() || this.product.profilePicture;

    // return product;

  }




}
