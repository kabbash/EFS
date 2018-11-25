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

  articles: articleListItemDto[];
  baseurl = environment.filesBaseUrl;
  categoryId: number;

  constructor(private router: Router, private route: ActivatedRoute, private repositoryService: RepositoryService) {
    this.route.params.subscribe(params => {
      this.categoryId = params['categoryId'];
    });
  }

  ngOnInit() {
    this.getArticles();
  }

  articlesDetails(articleId) {
    debugger;
    this.router.navigate([config.articles.articleDetails.route, articleId]);
  }

  getArticles() {
    this.repositoryService.getData<articleListItemDto[]>('articles/getbycategory/' + this.categoryId).subscribe(result => {
      this.articles = result.data;
    });
  }

}
