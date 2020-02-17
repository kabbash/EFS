import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PredefinedCategories } from '../../shared/models/articles/articles-predefined-categories.enum';
import { WritersService } from '../services/articles-writers.services';
import { articleListItemDto } from '../../shared/models/articles/article-list-item-dto';
import { environment } from '../../../environments/environment';
import { PagerDto } from '../../shared/models/pager.dto';
import { SearchFilterComponent } from '../../shared/search-filter/search-filter.component';
import { AppService } from '../../app.service';
import { config } from '../../config/pages-config';

@Component({
  selector: 'app-writers-articleslist',
  templateUrl: './writers-articles-list.component.html',
  styleUrls: ['./writers-articles-list.component.css'],
  providers: [WritersService]
})
export class WritersArticlesListComponent implements OnInit {

  articlesList: articleListItemDto[];
  baseurl = environment.filesBaseUrl;

  //pager
  selectedPage = 1;
  pagesNumber: number;
  articles: articleListItemDto[];
  pagerData: PagerDto;
  public championshipsCategory= PredefinedCategories.Championships;
  private pageSize = environment.articlesForWritersPageSize;
  hasItems: boolean;

  @ViewChild(SearchFilterComponent) searchFilterComponent: SearchFilterComponent;

  constructor(private route: ActivatedRoute,
    private router: Router, private service: WritersService, private appService: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.articlesList = result.articlesList.data.results;
      this.pagerData = result.articlesList.data;
      this.hasItems = result.articlesList.data.results.length > 0;
    });
  }

  articlesDetails(articleId) {

    this.router.navigate([config.writers.manageArticle.route, articleId]);
  }
  addArticle() {
    this.router.navigate([config.writers.manageArticle.route, 0]);
  }
  filterItems() {

    this.pagerData.currentPage = 1;
    this.pagerData.pageSize= this.pageSize;

    this.getNextPage();

    // let filter = `?pageNo=1&pageSize=${this.pageSize}&searchText=${this.searchFilterComponent.searchTxt}&status=${this.searchFilterComponent.filterStatuses.selectedValue}`;
    // this.service.getFilteredArticles(filter).subscribe(result => {
    //   this.articlesList = result.data.results;
    //   this.pagerData = result.data;
    //   this.appService.loading = false;
    // });
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
