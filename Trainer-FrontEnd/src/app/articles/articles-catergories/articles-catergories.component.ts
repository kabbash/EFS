import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import { articleCategoryDto } from '../../shared/models/article-category-dto';
import { AppService } from 'src/app/app.service';


@Component({
  selector: 'app-articles-catergories',
  templateUrl: './articles-catergories.component.html',
  styleUrls: ['./articles-catergories.component.css']
})
export class ArticlesCatergoriesComponent implements OnInit {

  categories: articleCategoryDto[];
  baseurl = environment.filesBaseUrl;

  articlesMap = [{ name: 'المقالات', route: '/products/productsCategories' },
  { name: 'العضلات', route: '/products/allProducts' },
  { name: 'السمانه', route: 'anything it will not be routed because it is the last' }];

  constructor(private router: Router, private repositoryService: RepositoryService,
    private appService: AppService) { }

  ngOnInit() {
    // start loading
    this.appService.loading = true;
    setTimeout(() => {
      // stop loading
      this.appService.loading = false;
    }, 3000);
    this.getCategories();
  }

  articlesList(categoryId) {
    this.router.navigate([config.articles.articlesList.route, categoryId]);
  }

  getCategories() {
    this.repositoryService.getData<articleCategoryDto[]>('articles/categories').subscribe(result => {
      this.categories = result.data;
    });
  }

}
