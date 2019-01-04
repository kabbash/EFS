import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import { articleListItemDto } from '../../shared/models/article-list-item-dto';
import { ArticlesService } from '../articles.service';
import { AppService } from 'src/app/app.service';


@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  selectedPage = 1;
  pagesNumber: number;
  articles: articleListItemDto[];
  baseurl = environment.filesBaseUrl;
  categoryId: number;
  itemsPerPage = 2;

  constructor(private router: Router, private appService: AppService, private repositoryService: RepositoryService,
    private articlesService: ArticlesService) {
  }

  ngOnInit() {
    this.getArticles(1, this.itemsPerPage);
    console.log(this.selectedPage);
    // this.route.data.subscribe(result => {
    //   this.articles = result.articleList.data;
    // });
  }

  getSelectedPage(page) {
    this.getArticles(page, this.itemsPerPage);
  }

  articlesDetails(articleId) {
    this.router.navigate([config.articles.articleDetails.route, articleId]);
  }

  getArticles(pageNumber, itemsPerPage) {
    this.appService.loading = true;
    this.articlesService.getArticles(pageNumber, itemsPerPage).subscribe((response: any) => {
      this.articles = [];
      this.appService.loading = false;
      this.pagesNumber = response.data.pagesCount * 10;
      this.articles = response.data.results;
    });
  }


}
