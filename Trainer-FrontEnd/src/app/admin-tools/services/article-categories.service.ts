import { Injectable } from '@angular/core';
import { articleCategoryDto } from '../../shared/models/article-category-dto';

@Injectable()
export class ArticleCategoriesService {
  articleCategoryToEdit: articleCategoryDto;
  categoryList: articleCategoryDto[];
  constructor() {}
}
