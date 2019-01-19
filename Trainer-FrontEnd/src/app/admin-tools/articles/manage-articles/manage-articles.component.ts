import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { articleDetialsDto } from '../../../shared/models/article-details-dto';
import { AppService } from '../../../app.service';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { ArticleDetailsEditmodeComponent } from '../../../shared/article-details-editmode/article-details-editmode.component';
import { config } from '../../../config/pages-config';


@Component({
  selector: 'app-manage-articles',
  templateUrl: './manage-articles.component.html',
  styleUrls: ['./manage-articles.component.css'],
  providers: [AdminArticlesService]
})
export class ManageArticlesComponent implements OnInit {
  articleId: number;
  article: articleDetialsDto;
  viewMode: boolean = true;
  isNew: boolean = false;
  originalArticle: articleDetialsDto;

  @ViewChild(ArticleDetailsEditmodeComponent) articleDetailsEditmodeComponent: ArticleDetailsEditmodeComponent;

  constructor(private route: ActivatedRoute, private router: Router, private appService: AppService, private service: AdminArticlesService) {
    this.route.params.subscribe(params => {
      this.articleId = params['articleId'];
    });
  }

  ngOnInit() {

    if (this.articleId > 0)
      this.route.data.subscribe(result => {
        this.article = result.articleDetails.data;
        this.originalArticle = JSON.parse(JSON.stringify(this.article));
        this.appService.loading = false;
      });

    else {
      this.article = new articleDetialsDto();
      this.viewMode = false;
      this.isNew = true;
    }
  }

  // article main methods 

  approve() {
    if (confirm("هل انت متأكد من الموافقه على هذا المقال ؟ ")) {
      this.service.approve(this.articleId).subscribe(c => { alert('تمت الموافقه على المقال بنجاح'); this.returnToBase(); });
    }
  }

  reject() {
    if (confirm("هل انت متأكد من رفض هذا المقال ؟ ")) {
      this.service.reject(this.articleId, prompt("من فضلك ، ادخل سبب الرفض؟")).subscribe(c => { alert('تم رفض المقال بنجاح'); this.returnToBase(); });
    }
  }

  delete() {
    if (confirm("هل انت متأكد من مسح هذا المقال ؟ ")) {
      this.service.delete(this.articleId).subscribe(c => { console.log(c); alert('تم مسح المقال بنجاح'); this.returnToBase(); });
    }
  }

  update() {

    this.articleDetailsEditmodeComponent.submitted = true;
    if (!this.articleDetailsEditmodeComponent.articleForm.valid)
      return false;

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
    if (!this.articleDetailsEditmodeComponent.articleForm.valid)
      return false;

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

  prepareData(articleData: articleDetialsDto) {
    let formData = new FormData();
    formData.append('id', articleData.id ? articleData.id.toString() : "0");
    formData.append('name', articleData.name);
    formData.append('description', articleData.description);
    formData.append('categoryId', articleData.categoryId.toString());
    formData.append('profilePicture', articleData.profilePicture || "hamadaaaaa");
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
