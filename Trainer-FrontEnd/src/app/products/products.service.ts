import { ProductCategoryDTO } from "../shared/models/products/product-category-dto";
import { Injectable } from "@angular/core";

@Injectable()
export class ProductsService {
    public selectedCategory: ProductCategoryDTO;
    constructor() {}
}