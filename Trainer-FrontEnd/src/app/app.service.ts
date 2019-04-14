import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
@Injectable({
  providedIn: 'root'
})
export class AppService {
  loading: boolean;
  platformId;
  constructor(@Inject(PLATFORM_ID) platformId: string) {
    this.platformId = platformId;
  }
  isBrowser() {
    return isPlatformBrowser(this.platformId);
  }

}
