import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ManageArticleService } from '../../services/manage-articles.services';
import { articleDetialsDto } from '../../../shared/models/article-details-dto';
import { AppService } from '../../../app.service';

@Component({
  selector: 'app-manage-articles',
  templateUrl: './manage-articles.component.html',
  styleUrls: ['./manage-articles.component.css']
})
export class ManageArticlesComponent implements OnInit {
  articleId: number;
  article: articleDetialsDto;

  constructor(private router: Router,
    private route: ActivatedRoute, private appService: AppService, private service: ManageArticleService) {
    this.route.params.subscribe(params => {
      this.articleId = params['articleId'];
    });
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.article = result.articleDetails.data;
      this.appService.loading = false;
    });
  }

  approveArticle() {
    if (confirm('هل انت متأكد من الموافقه على هذا المقال ؟ ')) {
      this.service.approve(this.articleId).subscribe(c => { console.log(c); alert('approved'); });
    }
  }

  rejectArticle() {
    if (confirm('هل انت متأكد من رفض هذا المقال ؟ ')) {
      this.service.reject(this.articleId).subscribe(c => { console.log(c); alert('rejected'); });
    }
  }

}
