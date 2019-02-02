import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { productListItemDto, Review, Reviewer } from '../../shared/models/products/product-list-item-dto';
import { RatingDto } from '../../shared/models/rating.dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';
import { UtilitiesService } from '../../shared/services/utilities.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-product-rating',
  templateUrl: './product-rating.component.html',
  styleUrls: ['./product-rating.component.css']
})
export class ProductRatingComponent implements OnInit {
  userRate = 0;
  product: productListItemDto;
  rate = new RatingDto();
  baseurl = environment.filesBaseUrl;
  constructor(private route: ActivatedRoute, 
    private repositoryService: RepositoryService,
  private router: Router,
  public util: UtilitiesService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.product = result.product.data;
    });
    this.rate.createdAt = new Date();
  }

  submitRate() {
    const user = JSON.parse(localStorage.getItem('currentUser'));
    const reveiw = new Review();
    reveiw.comment = this.rate.comment;
    reveiw.rate = this.rate.rate;
    reveiw.reviwer = new Reviewer();
    reveiw.reviwer.fullName = user.fullName;
    if (!user) {
      alert('login first');
      this.router.navigate([config.userAccount.loginPage.route]);
      return;
    } else {
      this.rate.createdBy = user.id;
      this.rate.entityId = this.product.id;
      this.rate.entityTypeId = 1;
      this.repositoryService.create('itemsreview/AddRate', this.rate).subscribe(data => {
        alert('success');
        this.product.reviews.push(reveiw);
      }, error => {
        alert(error);
      });
    }
    
  }

}
