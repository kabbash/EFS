import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { articleListItemDto } from '../../../shared/models/articles/article-list-item-dto';
import { environment } from '../../../../environments/environment';
import { config } from '../../../config/pages-config';
import { PagerDto } from '../../../shared/models/pager.dto';
import { AppService } from '../../../app.service';
import { SearchFilterComponent } from '../../../shared/search-filter/search-filter.component';
import { AppConfig } from '../../../../config/app.config';
import { PredefinedCategories } from '../../../shared/models/articles/articles-predefined-categories.enum';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css'],
  providers: [AdminArticlesService]
})
export class ArticlesListComponent implements OnInit {

  articlesList: articleListItemDto[];
  baseurl = environment.filesBaseUrl;

  //pager
  selectedPage = 1;
  pagesNumber: number;
  articles: articleListItemDto[];
  pagerData: PagerDto;
  public championshipsCategory= PredefinedCategories.Championships;
  private pageSize = AppConfig.settings.pagination.articlesForAdmin.pageSize;

  @ViewChild(SearchFilterComponent) searchFilterComponent: SearchFilterComponent;

  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminArticlesService, private appService: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.articlesList = result.articlesList.data.results;
      this.pagerData = result.articlesList.data;
    });
  }

  articlesDetails(articleId) {
    this.router.navigate([config.admin.manageArticles.route, articleId]);
  }
  addArticle() {
    this.router.navigate([config.admin.manageArticles.route, 0]);
  }
  filterItems() {

    this.appService.loading = true;
    let filter = `?pageNo=1&pageSize=${this.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&status=${this.searchFilterComponent.filterStatuses.selectedValue}`;
    this.service.getFilteredArticles(filter).subscribe(result => {
      this.articlesList = result.data.results;
      this.pagerData = result.data;
      this.appService.loading = false;
    });
  }
  getNextPage() {

    this.appService.loading = true;
    let filter = `?pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&status=${this.searchFilterComponent.filterStatuses.selectedValue}`;
    this.service.getFilteredArticles(filter).subscribe((response: any) => {

      this.articlesList = response.data.results;
      this.pagerData = response.data;
      this.appService.loading = false;
    });
  }
}
