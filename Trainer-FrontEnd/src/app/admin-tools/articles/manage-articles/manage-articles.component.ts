import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { articleDetialsDto } from '../../../shared/models/article-details-dto';
import { AppService } from '../../../app.service';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { config } from 'src/app/config/pages-config';


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
  private originalArticle: articleDetialsDto;

  constructor(private route: ActivatedRoute,private router: Router, private appService: AppService, private service: AdminArticlesService) {
    this.route.params.subscribe(params => {
      this.articleId = params['articleId'];
    });
  }

  ngOnInit() {
    if (this.articleId != 0)
      this.route.data.subscribe(result => {
        this.originalArticle = result.articleDetails.data;
        this.article = result.articleDetails.data;
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
      this.service.approve(this.articleId).subscribe(c => { console.log(c); alert('approved'); });
    }
  }

  reject() {
    if (confirm("هل انت متأكد من رفض هذا المقال ؟ ")) {
      this.service.reject(this.articleId).subscribe(c => { console.log(c); alert('rejected'); });
    }
  }

  delete() {
    if (confirm("هل انت متأكد من مسح هذا المقال ؟ ")) {
      this.service.delete(this.articleId).subscribe(c => { console.log(c); alert('deleted'); });
    }
  }

  update() {

    this.service.update(this.articleId, this.prepareData(this.article)).subscribe(
      () => {
        alert('success');
      }, error => {
        alert(error);
      }
    );
  }

  add(){

    this.service.update(this.articleId, this.prepareData(this.article)).subscribe(
      () => {
        alert('success');
      }, error => {
        alert(error);
      }
    );
  }

  // end main methods 


  // help methods 

  prepareData(articleData: articleDetialsDto) {
    debugger;
    let formData = new FormData();
    formData.append('id', articleData.id.toString());
    formData.append('name', articleData.name);
    formData.append('description', articleData.description);
    // formData.append('createdAt', categoryData.createdAt ? categoryData.createdAt : new Date().toISOString());
    // formData.append('createdBy', categoryData.createdBy ? categoryData.createdBy : 'admin');
    // formData.append('profilePicture', categoryData.profilePicture ? categoryData.profilePicture : '');
    // categoryData.parentId ?  formData.append('parentId', categoryData.parentId) : null;
    console.log(formData);
    return formData;
  }

  // end help methods 

  openEditForm() {
    // this.article = this.originalArticle;
    this.viewMode = false;
  }

  cancelUpdates() {
    //this.article = this.originalArticle;
    this.viewMode = true;
  }

  cancelAdd(){
    
  }

  showPendingButtons() {
    return !this.article.isActive;
  }

  showAddbtn(){
    return this.isNew;
  }
}
