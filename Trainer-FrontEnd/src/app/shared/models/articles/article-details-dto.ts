import { SliderItemDto } from '../slider/slider-item.dto';
import { ISliderDto } from '../slider/ISlider.dto';

export class ArticleDetialsDto implements ISliderDto  {

    id: number;
    name: string;
    profilePicture: string;
    description: string;
    date: string;
    place: string;
    isActive: boolean;
    categoryId: number;
    images: SliderItemDto[];
    updatedImages: SliderItemDto[];

    constructor() {
      this.images = new Array<SliderItemDto>();
      this.updatedImages = new Array<SliderItemDto>();

    }
}
