import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import { articleCategoryDto } from '../../shared/models/articles/article-category-dto';
import { AppService } from '../../app.service';


@Component({
  selector: 'app-articles-catergories',
  templateUrl: './articles-catergories.component.html',
  styleUrls: ['./articles-catergories.component.css']
})
export class ArticlesCatergoriesComponent implements OnInit {

  currentPage = 3;
  page = 4;
  pageAdvanced = 2;
  categories: articleCategoryDto[];
  baseurl = environment.filesBaseUrl;

  articlesMap = [{ name: 'المقالات', route: '/products/productsCategories' },
  { name: 'العضلات', route: '/products/allProducts' },
  { name: 'السمانه', route: 'anything it will not be routed because it is the last' }];

  constructor(private router: Router, private repositoryService: RepositoryService,
    private appService: AppService,
    private route: ActivatedRoute) { }

  ngOnInit() {

    this.appService.loading = true;
    this.route.data.subscribe(result => {
      this.categories = result.categories.data;
      if(result.categories.data.length){
        this.categories = result.categories.data.sort((a, b) => {
          return b.id - a.id;
        });
      }
      this.appService.loading = false;
    });
  }

  articlesList(categoryId) {
    this.router.navigate([config.articles.articlesList.route, categoryId]);
  }
}
