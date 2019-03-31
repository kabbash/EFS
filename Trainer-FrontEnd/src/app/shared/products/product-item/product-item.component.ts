import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { config } from '../../../config/pages-config';
import { Router } from '@angular/router';
import { RepositoryService } from '../../../shared/services/repository.service';
import { productListItemDto } from '../../models/products/product-list-item-dto';
import { ProductReviewService } from '../../../admin-tools/services/product-review.service';
import { ProductReviewDto } from '../../models/products/product-review.dto';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() cardName: string;
  @Input() cardImage: string;
  @Input() price: string;
  @Input() currentRate: number;
  @Input() isSpecial: boolean;
  @Input() shortDesc: string;
  @Input() showDetailsButton = true;
  @Input() product : productListItemDto;
  @Input() showImageCropIcon = false;
  @Output() cropEvent = new EventEmitter();
  isAddItemForReview = false;
  constructor(private route: Router,
     private repository: RepositoryService,
     private productReviewService: ProductReviewService) { }

  ngOnInit() {
    this.isAddItemForReview = this.route.url === config.admin.itemReviewList.route;
  }
  
  delete() {
    if (confirm('هل انت متاكد من حذف المنتج؟')) {
      this.repository.delete('itemsreview/' + this.product.id).subscribe(data => {
        this.productReviewService.productReviewList.splice(
          this.productReviewService.productReviewList.findIndex(el => el.id === this.product.id),
          1
        );
        alert('success');
      }, error => {
        alert(error);
      });
    }
  }

  edit() {
    this.setSelectedProductReview();
    this.route.navigate([config.admin.addItemForReview.route]);
  }

  setSelectedProductReview() {
    this.productReviewService.productReviewToUpdate = new ProductReviewDto();
    this.productReviewService.productReviewToUpdate.id = this.product.id;
    this.productReviewService.productReviewToUpdate.description = this.product.description;
    this.productReviewService.productReviewToUpdate.name = this.product.name;
    this.productReviewService.productReviewToUpdate.profilePicture = this.product.profilePicture;
    this.productReviewService.productReviewToUpdate.profilePictureFile = null;
    
    
  }

  cropClicked() {
    this.cropEvent.emit();
  }

}
