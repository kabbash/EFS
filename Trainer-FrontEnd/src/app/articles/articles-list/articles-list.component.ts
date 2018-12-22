import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import { articleListItemDto } from '../../shared/models/article-list-item-dto';


@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  currentPage = 3;
  page = 4;
  pageAdvanced = 2;
  articles: articleListItemDto[];
  baseurl = environment.filesBaseUrl;
  categoryId: number;

  constructor(private router: Router, private route: ActivatedRoute, private repositoryService: RepositoryService) {
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.articles = result.articleList.data;
    });
  }

  articlesDetails(articleId) {
    this.router.navigate([config.articles.articleDetails.route, articleId]);
  }


}
