import { Injectable } from '@angular/core';
import { articleCategoryDto } from '../../shared/models/articles/article-category-dto';

@Injectable()
export class CategoriesService {
  articleCategoryToEdit: articleCategoryDto;
  allCategoriesList: articleCategoryDto[];
  displayedCategoryList: articleCategoryDto[];
  apiUrl = 'Articles/Categories/';
  showParentDdl = false;
  manageProducts = false;
  constructor() {}
}
