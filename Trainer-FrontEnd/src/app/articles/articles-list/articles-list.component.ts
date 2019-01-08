import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute, Route } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import { articleListItemDto } from '../../shared/models/article-list-item-dto';
import { ArticlesService } from '../articles.service';
import { AppService } from '../../app.service';
import { PagerDto } from '../../shared/models/pager.dto';


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
  pagerData: PagerDto;

  constructor(private router: Router, private appService: AppService, private repositoryService: RepositoryService,
    private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.articleList.data;
      this.pagerData.itmesCount = 6;
      this.articles = result.articleList.data.results;
      this.appService.loading = false;
    });
  }


  articlesDetails(articleId) {
    this.router.navigate([config.articles.articleDetails.route, articleId]);
  }

  getNextPage() {
    this.appService.loading = true;
    this.repositoryService.getData(`articles/${this.route.params['categoryId']}?pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}`).subscribe((response: any) => {
      this.pagerData = response.productList.data;
      this.pagerData.itmesCount = 6;
      this.articles = response.productList.data.results;
      this.appService.loading = false;
    });
  }


}
