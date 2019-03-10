import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ArticleDetialsDto } from '../../../shared/models/articles/article-details-dto';
import { AppService } from '../../../app.service';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { ArticleDetailsEditmodeComponent } from '../../../shared/articles/article-details-editmode/article-details-editmode.component';
import { config } from '../../../config/pages-config';
import { SliderItemDto } from '../../../shared/models/slider/slider-item.dto';
import { UtilitiesService } from '../../../shared/services/utilities.service';
import { PredefinedCategories } from '../../../shared/models/articles/articles-predefined-categories.enum';


@Component({
  selector: 'app-manage-articles',
  templateUrl: './manage-articles.component.html',
  styleUrls: ['./manage-articles.component.css']
  
})
export class ManageArticlesComponent implements OnInit {
  articleId: number;
  article: ArticleDetialsDto;
  viewMode = true;
  isNew = false;
  originalArticle: ArticleDetialsDto;
  isChampionshipModule: boolean = false;

  @ViewChild(ArticleDetailsEditmodeComponent) articleDetailsEditmodeComponent: ArticleDetailsEditmodeComponent;

  constructor(private route: ActivatedRoute,
    private router: Router,
     private appService: AppService,
      private service: AdminArticlesService,
      private util: UtilitiesService) {
    this.route.params.subscribe(params => {
      this.articleId = params['articleId'];
    });
  }

  ngOnInit() {

    if (this.articleId > 0) {
      this.route.data.subscribe(result => {
        this.article = result.articleDetails.data;
        this.article.updatedImages = new Array<SliderItemDto>();
        this.originalArticle = JSON.parse(JSON.stringify(this.article));
        this.appService.loading = false;        
        this.isChampionshipModule = this.article.categoryId === PredefinedCategories.Championships;
      });

    } else {
      this.article = new ArticleDetialsDto();
      this.viewMode = false;
      this.isNew = true;
    }    
  }

  // article main methods

  approve() {
    if (confirm('هل انت متأكد من الموافقه على هذا المقال ؟ ')) {
      this.appService.loading = true;
      this.service.approve(this.articleId).subscribe(c => { 
        alert('تمت الموافقه على المقال بنجاح');
         this.returnToBase();
         this.appService.loading = false;
         }, error => {
           this.appService.loading = false;
         });
    }
  }

  reject() {
    if (confirm('هل انت متأكد من رفض هذا المقال ؟ ')) {
      this.appService.loading = true;
      this.service.reject(this.articleId, prompt('من فضلك ، ادخل سبب الرفض؟'))
      .subscribe(c => {
         alert('تم رفض المقال بنجاح');
          this.returnToBase();
          this.appService.loading = false; 
        }, error => {
          this.appService.loading = false;
        });
    }
  }

  delete() {
    if (confirm('هل انت متأكد من مسح هذا المقال ؟ ')) {
      this.appService.loading = true;
      this.service.delete(this.articleId).subscribe(c => { 
        console.log(c);
         alert('تم مسح المقال بنجاح');
          this.returnToBase();
          this.appService.loading = false;
         }, error => {
           this.appService.loading = false;
         });
    }
  }

  update() {

    this.articleDetailsEditmodeComponent.submitted = true;
    if (!this.articleDetailsEditmodeComponent.articleForm.valid) {
      return false;
    }
    this.util.setSliderProfilePic(this.articleDetailsEditmodeComponent.modifiedArticle, false);        
    const articleToUpdate = Object.assign({}, this.articleDetailsEditmodeComponent.modifiedArticle)
    delete articleToUpdate.images;
    const formData = new FormData();
    this.util.appendFormData(formData, articleToUpdate);
    this.appService.loading = true;
    this.service.update(this.articleId, formData).subscribe(
      () => {
        alert('تم تعديل المقال بنجاح');
        this.enableViewMode();
        this.appService.loading = false;

      }, error => {
        alert(error);
        this.appService.loading = false;
      }
    );
  }

  add() {

    this.articleDetailsEditmodeComponent.submitted = true;
    if (!this.articleDetailsEditmodeComponent.articleForm.valid) {
      return false;
    }

    this.util.setSliderProfilePic(this.articleDetailsEditmodeComponent.modifiedArticle, true);    
    const formData = new FormData();
    this.util.appendFormData(formData, this.articleDetailsEditmodeComponent.modifiedArticle);
    this.appService.loading = true;
    this.service.add(formData).subscribe(
      () => {
        alert('تم اضافة المقال بنجاح');
        this.returnToBase();
        this.appService.loading = false;
      }, error => {
        alert(error);
        this.appService.loading = false;
      }
    );
  }

  // end main methods




  enableEditMode() {
    this.viewMode = false;
  }

  enableViewMode() {
    this.viewMode = true;
  }

  cancelUpdates() {

    this.article = JSON.parse(JSON.stringify(this.originalArticle));
    this.enableViewMode();
  }

  cancelAdd() {
    this.returnToBase();
  }

  showPendingButtons() {
    return !this.article.isActive;
  }

  showAddbtn() {
    return this.isNew;
  }

  returnToBase() {
    this.router.navigate([config.admin.articleslist.route]);
  }
}
