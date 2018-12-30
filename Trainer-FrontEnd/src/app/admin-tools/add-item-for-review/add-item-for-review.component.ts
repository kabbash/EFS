import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RepositoryService } from '../../shared/services/repository.service';
import { ProductItemComponent } from '../../shared/product-item/product-item.component';

@Component({
  selector: 'app-add-item-for-review',
  templateUrl: './add-item-for-review.component.html',
  styleUrls: ['./add-item-for-review.component.css']
})
export class AddItemForReviewComponent implements OnInit {
  reviewForm: FormGroup;
  imageAdded = false;
  @ViewChild('itemForReview') item: ProductItemComponent;
  constructor(private fb: FormBuilder,
    private repositoryService: RepositoryService) { }

  ngOnInit() {
    this.reviewForm = this.fb.group({
      'name': ['', Validators.required] ,
      'description': [''],
      'profilePictureFile': [],
      'profilePicture': ['']

    });
  }
  submit() {
    if (this.reviewForm.valid) {
      this.repositoryService.create('', this.reviewForm.value).subscribe(data => {
        alert('success');
      }, error => {
        alert(error);
      });
    }
  }

  onFileSelect(file) {
    this.reviewForm.controls['profilePictureFile'].setValue(file);
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.item.cardImage = e.target.result;
    };
    reader.readAsDataURL(file);
    this.imageAdded = true;
  }

}
