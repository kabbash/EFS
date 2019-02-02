import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { articleCategoryDto } from '../../shared/models/articles/article-category-dto';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-manage-categories',
  templateUrl: './manage-categories.component.html',
  styleUrls: ['./manage-categories.component.css']
})
export class ManageCategoriesComponent implements OnInit {
  categories: articleCategoryDto [];
  baseurl = environment.filesBaseUrl;
  @Input() addUrl: string;
  @Input() apiUrl: string;
  constructor(private route: ActivatedRoute,
    private router: Router,
    public categoryService: CategoriesService) { }

  ngOnInit() {
    this.categoryService.displayedCategoryList = this.categoryService.allCategoriesList.filter(item => !item.parentId);    
  }

  gotoAddCategory() {
    this.categoryService.articleCategoryToEdit = null;
    this.categoryService.apiUrl = this.apiUrl;
    this.router.navigate([this.addUrl]);
  }

  categoryList(categoryId) {

    const subCategories = this.getSubCategories(categoryId);
    if (subCategories.length > 0) {
      this.categoryService.displayedCategoryList = subCategories;
    }
  }

  // HELP METHODS
  getSubCategories(categoryId: number) {
    return this.categoryService.allCategoriesList.filter(c => c.parentId === categoryId);
  }

}
