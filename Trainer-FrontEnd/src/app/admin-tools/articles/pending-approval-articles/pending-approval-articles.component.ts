import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ManageArticleService } from '../../services/manage-articles.services';
import { articleListItemDto } from '../../../shared/models/article-list-item-dto';
import { environment } from '../../../../environments/environment.prod';
import { config } from '../../../config/pages-config';

@Component({
  selector: 'app-pending-approval-articles',
  templateUrl: './pending-approval-articles.component.html',
  styleUrls: ['./pending-approval-articles.component.css']
})
export class PendingApprovalArticlesComponent implements OnInit {

  articlesList: articleListItemDto [];
  baseurl = environment.filesBaseUrl;

  constructor(private route: ActivatedRoute,
    private router: Router, private service: ManageArticleService) { }

    ngOnInit() {
      this.route.data.subscribe(result => {
        this.articlesList = result.articlesList.data;
      });
    }

    articlesDetails(articleId) {
      this.router.navigate([config.admin.manageArticles.route, articleId]);
    }

    approve(articleId) {
      if (confirm('هل انت متأكد من الموافقه على هذا المقال ؟ ')) {
        this.service.approve(articleId).subscribe(c => { console.log(c); alert('approved'); });
      }
    }
      reject(articleId) {
        if (confirm('هل انت متأكد من رفض هذا المقال ؟ ')) {
          this.service.reject(articleId).subscribe(c => { console.log(c); alert('rejected'); });
        }
    }
}
