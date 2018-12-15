import { Component, OnInit, Input, Output} from '@angular/core';
import { articleCategoryDto } from '../models/article-category-dto';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { Router } from '@angular/router';
import { ArticleCategoriesService } from '../../admin-tools/services/article-categories.service';
import { RepositoryService } from '../services/repository.service';

@Component({
  selector: 'app-articles-card',
  templateUrl: './articles-card.component.html',
  styleUrls: ['./articles-card.component.css']
})
export class ArticlesCardComponent implements OnInit {


  @Input() cardName: string;
  @Input() cardImage: string;
  @Input() editMode = false;
  @Input() articleCategory: articleCategoryDto;
  @Input() localImageUrl = false;
  baseurl = environment.filesBaseUrl;
  constructor(private router: Router,
    private categoriesService: ArticleCategoriesService,
    private repoService: RepositoryService) { }

  ngOnInit() {
  }
  editCategory() {
    this.router.navigate([config.admin.addArticleCategory.route]);
    this.categoriesService.articleCategoryToEdit = this.articleCategory;
  }

  deleteCategory() {
    const confirmed = confirm('Are you sure you want to delete this item');
    if (confirmed) {
      this.repoService.delete('Articles/Categories/' + this.articleCategory.id).subscribe(() => {
        alert('success');
        this.categoriesService.categoryList.splice(
          this.categoriesService.categoryList.findIndex(el => el.id === this.articleCategory.id),
          1
        );
      }, error => {
        alert(error);
      });
    }
  }

}
