import { Injectable } from "@angular/core";
import { ProductReviewDto } from "../../shared/models/products/product-review.dto";
import { productListItemDto } from "../../shared/models/products/product-list-item-dto";

@Injectable()
export class ProductReviewService {
    productReviewToUpdate: ProductReviewDto
    productReviewList: productListItemDto[];

}