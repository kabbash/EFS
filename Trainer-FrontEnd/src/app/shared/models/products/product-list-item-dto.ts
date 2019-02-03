import { SliderItemDto } from "../slider/slider-item.dto";
import { ISliderDto } from "../slider/ISlider.dto";

export class productListItemDto implements ISliderDto {

  id: number = 0;
  name: string = '';
  profilePicture: string = null;
  profilePictureFile: File;
  description: string = '';
  expDate: string = '';
  price: number = null;
  categoryId: number = null;
  categoryName: string = '';
  rate: number = 0;
  seller: Seller = new Seller();
  reviews: Review[];
  isSpecial: boolean = null;
  isActive: boolean = null;
  images: SliderItemDto[];
  updatedImages: SliderItemDto[];

  constructor() {
    this.images = new Array<SliderItemDto>();
    this.updatedImages = new Array<SliderItemDto>();
  }
}

export class Seller {
  fullName: string;
  phoneNumber: string;
}
export class Review {
  comment : string;
  cratedAt: string;
  rate: Number;
  reviwer: Reviewer
}
export class Reviewer {
  fullName: string;
}