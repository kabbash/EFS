import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { config } from 'src/app/config/pages-config';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { environment } from 'src/environments/environment';
import { ProductCategoryDTO } from 'src/app/shared/models/product-category-dto';

@Component({
  selector: 'app-products-catergories',
  templateUrl: './products-catergories.component.html',
  styleUrls: ['./products-catergories.component.css']
})
export class ProductsCatergoriesComponent implements OnInit {

  categories: ProductCategoryDTO[];
  baseurl = environment.filesBaseUrl;
  private allCategories: ProductCategoryDTO[];
  userRate = 4;
  
  constructor(private router: Router, private repositoryService: RepositoryService) { }

  ngOnInit() {
    this.getCategories();
  }

  productsList(categoryId) {

    let subCategories = this.getSubCategories(categoryId);
    if (subCategories.length > 0)
      this.categories = subCategories;
    else
      this.router.navigate([config.products.productsList.route, categoryId]);
  }

  getCategories(): any {
    this.repositoryService.getData<ProductCategoryDTO[]>('products/categories').subscribe(result => {
      this.allCategories = result.data;
      this.categories = result.data.filter(item => !item.parentId);
    });
  }

  // HELP METHODS 
  getSubCategories(categoryId: number): ProductCategoryDTO[] {
    return this.allCategories.filter(c => c.parentId == categoryId);
  }
  //END HELP METHODS
}
