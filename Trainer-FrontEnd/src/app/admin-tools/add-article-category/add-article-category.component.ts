import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { RepositoryService } from '../../shared/services/repository.service';

@Component({
  selector: 'app-add-article-category',
  templateUrl: './add-article-category.component.html',
  styleUrls: ['./add-article-category.component.css']
})
export class AddArticleCategoryComponent implements OnInit {

  constructor(private fb: FormBuilder, private reposatoryService: RepositoryService) { }
  categoryForm: FormGroup;
  ngOnInit() {
    this.categoryForm = this.fb.group({
      'name': ['', Validators.required],
      'profilePictureFile': [{}, Validators.required]
    });
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
  onSelectFile(file) {
    this.categoryForm.patchValue({
      profilePictureFile: file
    });
    // this.categoryForm.controls['profilePicture'].setValue(file);
  }

  prepareData() {
    const formModel = this.categoryForm.value;

    const formData = new FormData();
    formData.append('name', formModel.name);
    formData.append('profilePictureFile', formModel.profilePictureFile);

    return formData;
  }
}
