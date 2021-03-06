import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { productListItemDto, Review, Reviewer } from '../../shared/models/products/product-list-item-dto';
import { RatingDto } from '../../shared/models/rating.dto';
import { RepositoryService } from '../../shared/services/repository.service';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';
import { UtilitiesService } from '../../shared/services/utilities.service';
import { environment } from '../../../environments/environment';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';
import { ToastrService } from 'ngx-toastr';

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
    public util: UtilitiesService,
    private toastr :ToastrService,
    private errorHandlingService: ErrorHandlingService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.product = result.product.data;
    });
    this.rate.createdAt = new Date();
  }

  submitRate() {
    const user = JSON.parse(localStorage.getItem('currentUser'));
    if (!user) {
      this.toastr.error('برجاء تسجيل الدخول اولا ');
      this.router.navigate([config.userAccount.loginPage.route]);
      return;
    } else {
      const reveiw = new Review();
      reveiw.comment = this.rate.comment;
      reveiw.rate = this.rate.rate;
      reveiw.isCurrent = true;
      reveiw.reviwer = new Reviewer();
      reveiw.reviwer.fullName = user.fullName;
      reveiw.createdAt = this.util.getDateFormatted((new Date()).toISOString());
      this.rate.entityId = this.product.id;
      this.repositoryService.create('itemsreview/AddRate', this.rate).subscribe(data => {
        this.toastr.info('تم اضافة التقييم');

        this.product.reviews = this.product.reviews.filter(function (item, idx) {
          return item.isCurrent !== true;
        });

        this.product.reviews.push(reveiw);
      }, error => {
        this.errorHandlingService.handle(error, PAGES.RATING);
      });
    }
   
  }

}
