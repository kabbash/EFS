import { Component, OnInit, Input} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { RepositoryService } from '../../shared/services/repository.service';
import {articleCategoryDto} from '../../shared/models/article-category-dto';
import { CategoriesService } from '../services/categories.service';
import { DropDownDto } from 'src/app/shared/models/drop-down.dto';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private reposatoryService: RepositoryService,
    public categoryService: CategoriesService) { }

  categoryForm: FormGroup;
  imageUrl: string;
  articleCategory: articleCategoryDto = new articleCategoryDto();
  imageAdded = false;
  dropDownData: DropDownDto[] = [];
  @Input() apiUrl: string;
  ngOnInit() {
    this.articleCategory = this.categoryService.articleCategoryToEdit || new articleCategoryDto();

    this.categoryForm = this.fb.group({
      'name': ['', Validators.required],
      'profilePictureFile': [null, !this.articleCategory.profilePicture ? Validators.required : null],
      'parentId': ['']
    });
    this.setDropDownData();
  }
  submit() {
    if (this.categoryForm.valid) {
      if (this.categoryService.articleCategoryToEdit) {
        this.updateCategory();
      } else {
        this.addCategory();
      }
    } else {
      alert('form not valid');
    }
  }
  addCategory() {
    this.reposatoryService.create(this.categoryService.apiUrl, this.prepareData(this.categoryForm.value)).subscribe(data => {
      alert('success');
    }, error => {
      alert(error);
    });
  }
  updateCategory() {
    this.reposatoryService.update(this.categoryService.apiUrl + this.articleCategory.id, this.prepareData(this.articleCategory)).subscribe(
      () => {
        alert('success');
      }, error => {
        alert(error);
      }
    );
  }
  prepareData(categoryData) {
    const formData = new FormData();
    formData.append('name', categoryData.name);
    formData.append('profilePictureFile', categoryData.profilePictureFile);
    formData.append('createdAt', categoryData.createdAt ? categoryData.createdAt : new Date().toISOString());
    formData.append('createdBy', categoryData.createdBy ? categoryData.createdBy : 'admin');
    formData.append('profilePicture', categoryData.profilePicture ? categoryData.profilePicture : '');
    categoryData.parentId ?  formData.append('parentId', categoryData.parentId) : null;
    return formData;
  }

  onFileSelect(file) {
    this.articleCategory.profilePictureFile = file;
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.articleCategory.profilePicture = e.target.result;
    };
    reader.readAsDataURL(file);
    this.imageAdded = true;
  }

  setDropDownData() {
    this.categoryService.allCategoriesList.forEach(category => {
      this.dropDownData.push({label: category.name, value: category.id});
    });
  }

  onSelectParentCategory(value) {
    this.categoryForm.controls['parentId'].setValue(value);
  }
}
