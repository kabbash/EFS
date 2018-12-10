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
      'profilePicture': ['', Validators.required]
    });
  }
  addCategory() {
    if (this.categoryForm.valid) {
      this.reposatoryService.create('Articles/Categories', this.categoryForm.value).subscribe(data => {
        alert('success');
      }, error => {
        alert(error);
      });
    }
  }
  onSelectFile(file) {
    this.categoryForm.controls['profilePicture'].setValue(file);
  }
}
