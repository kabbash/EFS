import { Injectable } from "@angular/core";
import { ProductReviewDto } from "src/app/shared/models/product-review.dto";
import { productListItemDto } from "src/app/shared/models/product-list-item-dto";

@Injectable()
export class ProductReviewService {
    productReviewToUpdate: ProductReviewDto
    productReviewList: productListItemDto[];

}