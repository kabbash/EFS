import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, Route, ActivatedRoute } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { AppService } from '../../app.service';
import { PagerDto } from '../../shared/models/pager.dto';
import { debug } from 'util';
import { ClientFilterComponent } from '../../shared/client-filter/client-filter.component';
import { PredefinedCategories } from '../../shared/models/articles/articles-predefined-categories.enum';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';


@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css']
})
export class ArticlesListComponent implements OnInit {

  articles: articleListItemDto[];
  baseurl = environment.filesBaseUrl;
  categoryId: number;
  pagerData: PagerDto;
  public hideSearch: boolean = false;
  private isChampionShipsModule = false;

  @ViewChild(ClientFilterComponent) searchFilterComponent: ClientFilterComponent;


  constructor(private router: Router, private appService: AppService, private repositoryService: RepositoryService,
    private route: ActivatedRoute, private errorHandlingService: ErrorHandlingService) {
  }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.articleList.data;
      this.articles = result.articleList.data.results;
      this.appService.loading = false;
    });
    //  this.categoryId = Number(this.route.snapshot.paramMap.get("categoryId"));

    this.categoryId = this.route.snapshot.params.categoryId;
    this.hideSearch =  (! this.route.snapshot.data ||  ! this.route.snapshot.data.articleList.data.results.length);
    if (! this.categoryId)
      this.categoryId = this.route.snapshot.data && this.route.snapshot.data.articleList.data.results.length ? this.route.snapshot.data.articleList.data.results[0].categoryId : 0;
    this.isChampionShipsModule = this.categoryId === PredefinedCategories.Championships;
  }


  articlesDetails(articleId) {
    this.router.navigate([config.articles.articleDetails.route, articleId]);
  }

  getNextPage() {
    this.appService.loading = true;
    this.repositoryService.getData(`articles?categoryId=${this.categoryId}&pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}&searchText=${this.searchFilterComponent.searchTxt}`).subscribe((response: any) => {
      this.pagerData = response.data;
      this.articles = response.data.results;
      this.appService.loading = false;
    }, error => {
      this.appService.loading = false;
      this.errorHandlingService.handle(error, PAGES.ARTICLES);
    });
  }

  filterItems() {
    debugger;
    this.pagerData.currentPage = 1;
    this.getNextPage();
  }
}
