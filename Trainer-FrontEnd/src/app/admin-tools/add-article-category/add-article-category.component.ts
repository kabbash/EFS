import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { RepositoryService } from '../../shared/services/repository.service';
import {articleCategoryDto} from '../../shared/models/article-category-dto';
import { ArticleCategoriesService } from '../services/article-categories.service';

@Component({
  selector: 'app-add-article-category',
  templateUrl: './add-article-category.component.html',
  styleUrls: ['./add-article-category.component.css']
})
export class AddArticleCategoryComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private reposatoryService: RepositoryService,
    private categoryService: ArticleCategoriesService) { }

  categoryForm: FormGroup;
  imageUrl: string;
  articleCategory: articleCategoryDto = new articleCategoryDto();
  imageAdded = false;
  ngOnInit() {
    this.categoryForm = this.fb.group({
      'name': ['', Validators.required],
      'profilePictureFile': [{}, Validators.required]
    });
    this.articleCategory = this.categoryService.articleCategoryToEdit || new articleCategoryDto();
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
    this.reposatoryService.create('Articles/Categories', this.prepareData(this.categoryForm.value)).subscribe(data => {
      alert('success');
    }, error => {
      alert(error);
    });
  }
  updateCategory() {
    this.reposatoryService.update('Articles/Categories/' + this.articleCategory.id, this.prepareData(this.articleCategory)).subscribe(
      () => {
        alert('success');
      }, error => {
        alert(error);
      }
    )
  }
  prepareData(categoryData) {
    const formData = new FormData();
    formData.append('name', categoryData.name);
    formData.append('profilePictureFile', categoryData.profilePictureFile);
    formData.append('createdAt', categoryData.createdAt);
    formData.append('createdBy', categoryData.createdBy);
    

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
}
