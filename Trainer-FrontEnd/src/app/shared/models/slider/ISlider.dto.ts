import { SliderItemDto } from "./slider-item.dto";

export interface ISliderDto {
    profilePicture: string;
    images: SliderItemDto[];
    updatedImages: SliderItemDto[];
}