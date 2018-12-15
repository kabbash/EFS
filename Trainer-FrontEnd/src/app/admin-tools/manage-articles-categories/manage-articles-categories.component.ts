import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { articleCategoryDto } from '../../shared/models/article-category-dto';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { ArticleCategoriesService } from '../services/article-categories.service';

@Component({
  selector: 'app-manage-articles-categories',
  templateUrl: './manage-articles-categories.component.html',
  styleUrls: ['./manage-articles-categories.component.css']
})
export class ManageArticlesCategoriesComponent implements OnInit {
  categories: articleCategoryDto [];
  baseurl = environment.filesBaseUrl;
  constructor(private route: ActivatedRoute,
    private router: Router,
    public categoryService: ArticleCategoriesService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.categoryService.categoryList = result.categories.data;
    });
  }

  gotoAddArticleCategory() {
    this.categoryService.articleCategoryToEdit = new articleCategoryDto();
    this.router.navigate([config.admin.addArticleCategory.route]);
  }

}
