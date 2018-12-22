import { Injectable } from '@angular/core';
import { articleCategoryDto } from '../../shared/models/article-category-dto';

@Injectable()
export class CategoriesService {
  articleCategoryToEdit: articleCategoryDto;
  categoryList: articleCategoryDto[];
  apiUrl: string;
  constructor() {}
}
