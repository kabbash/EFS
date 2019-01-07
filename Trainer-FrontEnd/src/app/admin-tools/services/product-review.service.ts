import { Injectable } from "@angular/core";
import { ProductReviewDto } from "src/app/shared/models/product-review.dto";

@Injectable()
export class ProductReviewService {
    productReviewToUpdate: ProductReviewDto

}