import { Injectable } from '@angular/core';
import { articleCategoryDto } from '../../shared/models/article-category-dto';

@Injectable()
export class CategoriesService {
  articleCategoryToEdit: articleCategoryDto;
  allCategoriesList: articleCategoryDto[];
  displayedCategoryList: articleCategoryDto[];
  apiUrl: string;
  showParentDdl = false;
  manageArticles = false;
  constructor() {}
}
