import { Injectable } from '@angular/core';
import { SliderItemDto } from '../models/slider-item.dto';

@Injectable()
export class UtilitiesService {

  getDateFormatted(date: string, shortYear: boolean = false): string {
    if (!date) {
      return '';
    }
    const splitDate = date.split('-');
    const year = splitDate[0];
    const month = splitDate[1];
    const day = splitDate[2].split('T')[0];

    return  (shortYear ? year.substring(2) : year) + '/' + month + '/' + day ;
  }
  mapToSliderDto(data) {
    const sliderDto = new SliderItemDto();
    sliderDto.description = data.text;
    sliderDto.filePath = data.path;
    sliderDto.id = data.id;
    sliderDto.title = data.title;
    return sliderDto;
  }
  mapToSliderDtoArray(data: any[]) {
    const result = new Array<SliderItemDto>();
    data.forEach(item => {
      result.push(this.mapToSliderDto(item));
    });
    return result;
  }
}
