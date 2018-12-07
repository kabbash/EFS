import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AppService } from '../../app.service';
import { ProductCategoryDTO } from '../../shared/models/product-category-dto';
import { environment } from '../../../environments/environment';
import { RepositoryService } from '../../shared/services/repository.service';
import { config } from '../../config/pages-config';

@Component({
  selector: 'app-products-catergories',
  templateUrl: './products-catergories.component.html',
  styleUrls: ['./products-catergories.component.css']
})
export class ProductsCatergoriesComponent implements OnInit {

  categories: ProductCategoryDTO[];
  baseurl = environment.filesBaseUrl;
  private allCategories: ProductCategoryDTO[];

  constructor(private router: Router,
    private repositoryService: RepositoryService,
    private route: ActivatedRoute,
    private appSrevice: AppService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.allCategories = result.categories.data;
      this.appSrevice.loading = false;
    });
    // this.getCategories();
  }

  productsList(categoryId) {

    const subCategories = this.getSubCategories(categoryId);
    if (subCategories.length > 0) {
      this.categories = subCategories;
    } else {
      this.router.navigate([config.products.productsList.route, categoryId]);
    }
  }

  getCategories(): any {
    this.repositoryService.getData<ProductCategoryDTO[]>('products/categories').subscribe(result => {
      this.allCategories = result.data;
      this.categories = result.data.filter(item => !item.parentId);
    });
  }

  // HELP METHODS
  getSubCategories(categoryId: number): ProductCategoryDTO[] {
    return this.allCategories.filter(c => c.parentId === categoryId);
  }
  // END HELP METHODS
}
