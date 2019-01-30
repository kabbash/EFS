import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { articleListItemDto } from '../../../shared/models/article-list-item-dto';
import { environment } from '../../../../environments/environment';
import { config } from '../../../config/pages-config';
import { ArticlesFilter } from '../../../shared/models/articles-filter';
import { PagerDto } from '../../../shared/models/pager.dto';
import { AppService } from '../../../app.service';
import { SearchFilterComponent } from 'src/app/shared/search-filter/search-filter.component';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css'],
  providers: [AdminArticlesService]
})
export class ArticlesListComponent implements OnInit {

  articlesList: articleListItemDto[];
  baseurl = environment.filesBaseUrl;
  articleFilter= new ArticlesFilter();

  //pager
  selectedPage = 1;
  pagesNumber: number;
  articles: articleListItemDto[];
  pagerData: PagerDto;
  
  @ViewChild(SearchFilterComponent) searchFilterComponent: SearchFilterComponent;

  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminArticlesService, private appService: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.articlesList = result.articlesList.data.results;
      this.pagerData = result.articlesList.data;
    });
    
    this.articleFilter.pageNo = 1;
    this.articleFilter.pageSize = 10;
  }

  articlesDetails(articleId) {
    this.router.navigate([config.admin.manageArticles.route, articleId]);
  }
  addArticle() {
    this.router.navigate([config.admin.manageArticles.route, 0]);
  }
  setArticleFilter() {
    this.articleFilter.searchText = this.searchFilterComponent.searchTxt;
    this.articleFilter.status = this.searchFilterComponent.filterStatuses.selectedValue;
  }
  reloadItems() {

    this.setArticleFilter();
    let filter = `?pageNo=${this.articleFilter.pageNo}&pageSize=${this.articleFilter.pageSize}&searchText=${this.articleFilter.searchText}&status=${this.articleFilter.status}`;
    this.service.getFilteredArticles(filter).subscribe(result => {
      this.articlesList = result.data.results;
    });
  }
  getNextPage() {

    this.setArticleFilter();
    this.appService.loading = true;

    let filter = `?pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}&searchText=${this.articleFilter.searchText}&status=${this.articleFilter.status}`;

    this.service.getFilteredArticles(filter).subscribe((response: any) => {

      this.articlesList = response.data.results;
      this.pagerData = response.data;
      this.appService.loading = false;
    });
  }
}
