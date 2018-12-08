import { Injectable } from '@angular/core';

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

    return day + '/' + month + '/' + (shortYear ? year.substring(2) : year);
  }
}
