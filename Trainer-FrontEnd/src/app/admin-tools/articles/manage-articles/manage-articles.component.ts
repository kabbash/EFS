import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ArticleDetialsDto } from '../../../shared/models/article-details-dto';
import { AppService } from '../../../app.service';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { ArticleDetailsEditmodeComponent } from '../../../shared/article-details-editmode/article-details-editmode.component';
import { config } from '../../../config/pages-config';
import { SliderItemDto } from '../../../shared/models/slider-item.dto';
import { UtilitiesService } from '../../../shared/services/utilities.service';


@Component({
  selector: 'app-manage-articles',
  templateUrl: './manage-articles.component.html',
  styleUrls: ['./manage-articles.component.css'],
  providers: [AdminArticlesService]
})
export class ManageArticlesComponent implements OnInit {
  articleId: number;
  article: ArticleDetialsDto;
  viewMode = true;
  isNew = false;
  originalArticle: ArticleDetialsDto;

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
      this.service.approve(this.articleId).subscribe(c => { alert('تمت الموافقه على المقال بنجاح'); this.returnToBase(); });
    }
  }

  reject() {
    if (confirm('هل انت متأكد من رفض هذا المقال ؟ ')) {
      this.service.reject(this.articleId, prompt('من فضلك ، ادخل سبب الرفض؟'))
      .subscribe(c => { alert('تم رفض المقال بنجاح'); this.returnToBase(); });
    }
  }

  delete() {
    if (confirm('هل انت متأكد من مسح هذا المقال ؟ ')) {
      this.service.delete(this.articleId).subscribe(c => { console.log(c); alert('تم مسح المقال بنجاح'); this.returnToBase(); });
    }
  }

  update() {

    this.articleDetailsEditmodeComponent.submitted = true;
    if (!this.articleDetailsEditmodeComponent.articleForm.valid) {
      return false;
    }
    // const formData = new FormData();
    // this.util.appendFormData(formData, this.articleDetailsEditmodeComponent.modifiedArticle);
    this.service.update(this.articleId, this.prepareData(this.articleDetailsEditmodeComponent.modifiedArticle)).subscribe(
      () => {
        alert('تم تعديل المقال بنجاح');
        this.enableViewMode();

      }, error => {
        alert(error);
      }
    );
  }

  add() {

    this.articleDetailsEditmodeComponent.submitted = true;
    if (!this.articleDetailsEditmodeComponent.articleForm.valid) {
      return false;
    }

    this.service.add(this.prepareData(this.articleDetailsEditmodeComponent.modifiedArticle)).subscribe(
      () => {
        alert('تم اضافة المقال بنجاح');
        this.returnToBase();
      }, error => {
        alert(error);
      }
    );
  }

  // end main methods


  // help methods

  prepareData(articleData: ArticleDetialsDto) {
    const formData = new FormData();
    formData.append('id', articleData.id ? articleData.id.toString() : '0');
    formData.append('name', articleData.name);
    formData.append('description', articleData.description);
    formData.append('categoryId', articleData.categoryId.toString());
    formData.append('profilePicture', articleData.profilePicture || '');
    articleData.updatedImages.forEach((image, index) => {
      formData.append(`images[${index}]]['id']`, image.id ? image.id.toString() : '');
      formData.append(`images[${index}]]['isDeleted']`, image.isDeleted ? image.isDeleted.toString() : '');
      formData.append(`images[${index}]]['isNew']`, image.isNew ? image.isNew.toString() : '');
      formData.append(`images[${index}]]['isUpdated']`, image.isUpdated ? image.isUpdated.toString() : '');
      formData.append(`images[${index}]]['path']`, image.path ? image.path.toString() : '');
      formData.append(`images[${index}]]['title']`, image.title ? image.title.toString() : '');
      formData.append(`images[${index}]]['description']`, image.description ? image.description.toString() : '');
      formData.append(`images[${index}]]['iFormFile']`, image.iFormFile);
      formData.append(`images[${index}]]['isProfilePicture']`, image.isProfilePicture ? image.isProfilePicture.toString() : '');
      formData.append(`images[${index}]]['isProfilePictureUpdated']`,
        image.isProfilePictureUpdated ? image.isProfilePictureUpdated.toString() : '');

    });
    formData.append('images', JSON.stringify(articleData.updatedImages));
    return formData;
  }

  // end help methods

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
