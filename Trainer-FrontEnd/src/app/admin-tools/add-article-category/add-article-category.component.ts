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
    this.articleCategory = this.categoryService.articleCategoryToEdit;
  }
  addCategory() {
    if (this.categoryForm.valid) {
      this.reposatoryService.create('Articles/Categories', this.prepareData()).subscribe(data => {
        alert('success');
      }, error => {
        alert(error);
      });
    }
  }
  prepareData() {
    const formModel = this.categoryForm.value;

    const formData = new FormData();
    formData.append('name', formModel.name);
    formData.append('profilePictureFile', formModel.profilePictureFile);

    return formData;
  }

  onFileSelect(file) {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.articleCategory.profilePicture = e.target.result;
    };
    reader.readAsDataURL(file);
    this.imageAdded = true;
  }
}
