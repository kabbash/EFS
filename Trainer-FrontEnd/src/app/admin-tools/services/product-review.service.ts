import { Injectable } from "@angular/core";
import { ProductReviewDto } from "../../shared/models/product-review.dto";
import { productListItemDto } from "../../shared/models/product-list-item-dto";

@Injectable()
export class ProductReviewService {
    productReviewToUpdate: ProductReviewDto
    productReviewList: productListItemDto[];

}