import { imageWithTextDto } from './image-with-text-dto';
import { SliderItemDto } from './slider-item.dto';

export class ArticleDetialsDto {

    id: number;
    name: string;
    profilePicture: string;
    description: string;
    images: SliderItemDto[];
    isActive: boolean;
    categoryId: number;
    updatedImages: SliderItemDto[];

    constructor() {
      this.images = new Array<SliderItemDto>();
      this.updatedImages = new Array<SliderItemDto>();

    }
}
