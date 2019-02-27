import { Component, OnInit, Input} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { RepositoryService } from '../../shared/services/repository.service';
import {articleCategoryDto} from '../../shared/models/articles/article-category-dto';
import { CategoriesService } from '../services/categories.service';
import { DropDownDto } from '../../shared/models/drop-down.dto';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';
import { AppService } from '../../app.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private reposatoryService: RepositoryService,
    public categoryService: CategoriesService,
    private router: Router,
    private appService: AppService,
    private translate: TranslateService) { }

  categoryForm: FormGroup;
  imageUrl: string;
  articleCategory: articleCategoryDto = new articleCategoryDto();
  dropDownData: DropDownDto[] = [];
  addedImageUrl: string;
  successMessage: string;
  @Input() isAddArticleCategory = false;
  @Input() apiUrl = 'Articles/Categories/';
  ngOnInit() {
    this.articleCategory = this.categoryService.articleCategoryToEdit || new articleCategoryDto();

    this.categoryForm = this.fb.group({
      'name': ['', Validators.required],
      'profilePictureFile': [null, !this.articleCategory.profilePicture ? Validators.required : null],
      'parentId': [''],
      'description': ['']
    });
    this.setDropDownData();
    this.translate.get('manageCategories.messages.success').subscribe(data => {
      this.successMessage = data;
    })
  }
  submit() {
    this.categoryForm.controls['profilePictureFile'].markAsTouched();
    this.categoryForm.controls['name'].markAsTouched();
    this.appService.loading = true;
    
    if (this.categoryForm.valid) {
      if (this.categoryService.articleCategoryToEdit) {
        this.updateCategory();
      } else {
        this.addCategory();
      }
    } else {
      this.appService.loading = false;      
      alert('form not valid');
    }
  }
  addCategory() {
    this.reposatoryService.create(this.categoryService.apiUrl, this.prepareData(this.categoryForm.value)).subscribe(data => {
      
      alert(this.successMessage);
      this.navigateToListing();
    }, error => {
      this.appService.loading = false;
      alert(error);
    });
  }
  updateCategory() {
    this.reposatoryService.update(this.categoryService.apiUrl + this.articleCategory.id, this.prepareData(this.articleCategory)).subscribe(
      () => {
        alert(this.successMessage);
        this.navigateToListing();

      }, error => {
        this.appService.loading = false;
        alert(error);
      }
    );
  }
  prepareData(categoryData) {
    const formData = new FormData();
    formData.append('name', categoryData.name);
    formData.append('description', categoryData.description);
    formData.append('profilePictureFile', categoryData.profilePictureFile);
    formData.append('profilePicture', categoryData.profilePicture ? categoryData.profilePicture : '');
    categoryData.parentId ?  formData.append('parentId', categoryData.parentId) : null;
    return formData;
  }

  onFileSelect(file) {
    file.name = 'image.'+ file.type.split('/')[1];
    this.articleCategory.profilePictureFile = file;
    this.categoryForm.controls['profilePictureFile'].setValue(file)
    const reader = new FileReader();
    reader.onload = (e: any) => {
      // this.articleCategory.profilePicture = e.target.result;
      this.addedImageUrl = e.target.result;
    };
    reader.readAsDataURL(file);
  }

  setDropDownData() {
    this.categoryService.allCategoriesList.forEach(category => {
      if (!this.categoryService.articleCategoryToEdit || 
        (this.categoryService.articleCategoryToEdit && this.categoryService.articleCategoryToEdit.id !== category.id)) {
          this.dropDownData.push({label: category.name, value: category.id}); 
        }
    });
  }

  onSelectParentCategory(value) {
    this.categoryForm.controls['parentId'].setValue(value);
  }
  navigateToListing() {
    if (this.categoryService.manageProducts) {
      this.router.navigate([config.admin.manageProductsCategories.route]);
    } else {
      this.router.navigate([config.admin.manageArticlesCategories.route]);
    }
  }
}
