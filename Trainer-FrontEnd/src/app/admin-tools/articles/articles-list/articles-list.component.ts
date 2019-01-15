import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminArticlesService } from '../../services/admin.articles.services';
import { articleListItemDto } from '../../../shared/models/article-list-item-dto';
import { environment } from '../../../../environments/environment';
import { ddlDto } from '../../../shared/models/ddl-dto';
import { config } from '../../../config/pages-config';
import { ArticlesFilter } from '../../../shared/models/articles-filter';
import { PagerDto } from '../../../shared/models/pager.dto';
import { AppService } from '../../../app.service';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./articles-list.component.css'],
  providers: [AdminArticlesService]
})
export class ArticlesListComponent implements OnInit {

  articlesList: articleListItemDto[];
  baseurl = environment.filesBaseUrl;
  articlesStatuses = new ddlDto();
  searchTxt: string = "";
  articleFilter= new ArticlesFilter();

  //pager
  selectedPage = 1;
  pagesNumber: number;
  articles: articleListItemDto[];
  pagerData: PagerDto;

  constructor(private route: ActivatedRoute,
    private router: Router, private service: AdminArticlesService, private appService: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.articlesList = result.articlesList.data.results;
      this.pagerData = result.articlesList.data;
    });

    this.articlesStatuses.items = [{ value: 0, text: "الكل" }
      , { value: 1, text: "النشط" }
      , { value: 2, text: "المتوقف" }
      , { value: 3, text: "المرفوض" }
    ]
    this.articlesStatuses.selectedValue = 0;

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
    this.articleFilter.searchText = this.searchTxt;
    this.articleFilter.status = this.articlesStatuses.selectedValue;
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
      console.log(response);
      this.articlesList = response.data.results;
      this.pagerData = response.data;
      this.appService.loading = false;
    });
  }
}
