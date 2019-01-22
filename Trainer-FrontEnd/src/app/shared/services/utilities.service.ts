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
    sliderDto.path = data.path;
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
  appendFormData(formData, data, root = null) {
    root = root || '';
    if (data instanceof File) {
      formData.append(root, data);
    } else if (Array.isArray(data)) {
      for (let i = 0; i < data.length; i++) {
        if (data[i] instanceof File) {
          this.appendFormData(formData, data[i], root);
        } else {
          this.appendFormData(formData, data[i], root + '[' + i + ']');
        }
      }
    } else if (typeof data === 'object' && data) {
      for (const key in data) {
        if (data.hasOwnProperty(key)) {
          if (root === '') {
            this.appendFormData(formData, data[key], key);
          } else {
            this.appendFormData(formData, data[key], root + '.' + key);
          }
        }
      }
    } else {
      if (data !== null && typeof data !== 'undefined') {
        formData.append(root, data);
      }
    }
  }
}
