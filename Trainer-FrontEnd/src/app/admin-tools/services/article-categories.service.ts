import { Injectable } from '@angular/core';
import { articleCategoryDto } from 'src/app/shared/models/article-category-dto';

@Injectable()
export class ArticleCategoriesService {
  articleCategoryToEdit: articleCategoryDto;
  constructor() {}
}
