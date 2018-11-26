import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from '../../config/pages-config';
import { RepositoryService } from '../../shared/services/repository.service';
import { environment } from '../../../environments/environment';
import {articleCategoryDto} from '../../shared/models/article-category-dto';


@Component({
  selector: 'app-articles-catergories',
  templateUrl: './articles-catergories.component.html',
  styleUrls: ['./articles-catergories.component.css']
})
export class ArticlesCatergoriesComponent implements OnInit {

  categories:articleCategoryDto[];
  baseurl = environment.filesBaseUrl;
  constructor(private router: Router, private repositoryService: RepositoryService) { }

  ngOnInit() {
    this.getCategories();
  }
 
  articlesList(categoryId) {
    this.router.navigate([config.articles.articlesList.route,categoryId]);
  }

  getCategories() {
    this.repositoryService.getData<articleCategoryDto[]>('articles/categories').subscribe(result => {
      this.categories = result.data;
    });
  }

}
