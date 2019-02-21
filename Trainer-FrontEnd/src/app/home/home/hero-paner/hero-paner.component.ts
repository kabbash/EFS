import { Component, OnInit, Sanitizer, SecurityContext } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { BannerDto } from 'src/app/shared/models/banner.dto';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hero-paner',
  templateUrl: './hero-paner.component.html',
  styleUrls: ['./hero-paner.component.css']
})
export class HeroPanerComponent implements OnInit {
  banners: BannerDto[];
  baseurl = environment.filesBaseUrl
  constructor(private repositoryService: RepositoryService,
  private sanitizer: Sanitizer,
  private route: ActivatedRoute) {
    this.banners = this.route.snapshot.data.banners.data.results;
    this.prepareBannerHTMLData(this.banners);  
   }

  ngOnInit() {
    // this.banners = this.route.snapshot.data.banners.data.results;
    // this.prepareBannerHTMLData(this.banners);    
  }
  prepareBannerHTMLData(banners: BannerDto[]) {
    banners.forEach(banner => {
      banner.buttonText = this.sanitizer.sanitize(SecurityContext.NONE, banner.buttonText);
      banner.title = this.sanitizer.sanitize(SecurityContext.NONE, banner.title);
      
    })
  }

}
