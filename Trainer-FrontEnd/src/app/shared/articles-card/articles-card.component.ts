import { Component, OnInit, Input, Output} from '@angular/core';
import { articleCategoryDto } from '../models/article-category-dto';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { Router } from '@angular/router';
import { RepositoryService } from '../services/repository.service';
import { CategoriesService } from '../../admin-tools/services/categories.service';
import { AppService } from '../../app.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-articles-card',
  templateUrl: './articles-card.component.html',
  styleUrls: ['./articles-card.component.css']
})
export class ArticlesCardComponent implements OnInit {

  @Input() cardName: string;
  @Input() cardImage: string;
  @Input() editMode = false;
  @Input() addMode = false;
  @Input() articleCategory: articleCategoryDto;
  @Input() localImageUrl: string;
  @Input() apiUrl: string;
  baseurl = environment.filesBaseUrl;
  constructor(private router: Router,
    private categoriesService: CategoriesService,
    private repoService: RepositoryService,
    private appService: AppService,
    private translate: TranslateService) { }

  ngOnInit() {
  }
  editCategory() {
    this.router.navigate([config.admin.addCategory.route]);
    this.categoriesService.articleCategoryToEdit = this.articleCategory;
    this.categoriesService.apiUrl = this.apiUrl;
  }

  deleteCategory(event) {
    event.stopPropagation();
    const subCategories = this.categoriesService.allCategoriesList.filter(category => {
      return category.parentId === this.articleCategory.id;
    });
    if (subCategories.length > 0) {

    }
    this.translate.get('manageCategories.messages').subscribe(data => {
      const confirmed = (subCategories.length > 0) ? confirm(data.confirmDeleteParent) : confirm(data.confirmDelete);
      if (confirmed) {
        this.appService.loading = true;
        this.repoService.delete(this.apiUrl + this.articleCategory.id).subscribe(() => {
          this.appService.loading = false;
          alert(data.success);
          this.categoriesService.allCategoriesList.splice(
            this.categoriesService.allCategoriesList.findIndex(el => el.id === this.articleCategory.id),
            1
          );
          this.categoriesService.displayedCategoryList.splice(
            this.categoriesService.displayedCategoryList.findIndex(el => el.id === this.articleCategory.id),
            1
          );
        }, error => {
          this.appService.loading = false;
          alert(error);
        });
      }  
    });
    
  }

}
