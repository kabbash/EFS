import { Component, OnInit, Input } from '@angular/core';
import { config } from '../../config/pages-config';
import { Router } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { productListItemDto } from 'src/app/shared/models/product-list-item-dto';
import { ProductReviewService } from 'src/app/admin-tools/services/product-review.service';
import { ProductReviewDto } from 'src/app/shared/models/product-review.dto';

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
  isAddItemForReview = false;
  constructor(private route: Router,
     private repository: RepositoryService,
     private productReviewService: ProductReviewService) { }

  ngOnInit() {
    this.isAddItemForReview = this.route.url === config.admin.itemReviewList.route;
  }
  delete() {
    this.repository.delete('itemsreview/' + this.product.id).subscribe(data => {
      alert('success');
    }, error => {
      alert(error);
    });
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

}
