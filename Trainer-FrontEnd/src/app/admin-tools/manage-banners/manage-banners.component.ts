import { Component, OnInit, Sanitizer, SecurityContext } from '@angular/core';
import { ManageBannerService } from '../services/manage-banner.service';
import { BannerDto } from '../../shared/models/banner.dto';
import { ActivatedRoute, Router } from '@angular/router';
import { PagerDto } from '../../shared/models/pager.dto';
import { AppService } from '../../app.service';
import { environment } from '../../../environments/environment';
import { config } from '../../config/pages-config';
import { ErrorHandlingService } from '../../shared/services/error-handling.service';
import { PAGES } from '../../config/defines';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-manage-banners',
  templateUrl: './manage-banners.component.html',
  styleUrls: ['./manage-banners.component.css']
})
export class ManageBannersComponent implements OnInit {
  banners: BannerDto[];
  pagerData: PagerDto;
  baseurl = environment.filesBaseUrl;
  constructor(private sanitizer: Sanitizer,
  private bannerService: ManageBannerService,
  private route: ActivatedRoute,
  private appService: AppService,
  private router: Router,
  private toastrService: ToastrService,
  private errorHandlingService: ErrorHandlingService) { }

  ngOnInit() {
    this.route.data.subscribe(result => {
      this.pagerData = result.banners.data;
      this.banners = result.banners.data.results;
      this.prepareBannersHTMLData(this.banners);
    })
  }

  
  getNextPage() {

    this.appService.loading = true;
    let filter = `?pageNo=${this.pagerData.currentPage}&pageSize=${this.pagerData.pageSize}`;
    this.bannerService.gitPagedBanners(filter).subscribe((response: any) => {

      this.banners = response.data.results;
      this.pagerData = response.data;
      this.appService.loading = false;
    });
  }

  prepareBannersHTMLData(banners: BannerDto[]) {
    banners.forEach(banner => {
      banner.buttonText = this.sanitizer.sanitize(SecurityContext.NONE , banner.buttonText);
      banner.title = this.sanitizer.sanitize(SecurityContext.NONE , banner.title);
      
    })
  }

  deleteBanner(bannerId){
    const confirmMessage = confirm('are you sure?');
    if (confirmMessage) {
      this.appService.loading = true;
      this.bannerService.delete(bannerId).subscribe(data => {
        this.toastrService.info('تم مسح البانر');
        this.appService.loading = false;
        this.banners.splice(this.banners.findIndex(banner => banner.id === bannerId), 1);
      }, error => {
        this.appService.loading = false;
        this.errorHandlingService.handle(error, PAGES.BANNER);
      });
    }
  }

  gotoAddBanner() {
    this.router.navigate([config.admin.addBanner.route]);
  }

}
