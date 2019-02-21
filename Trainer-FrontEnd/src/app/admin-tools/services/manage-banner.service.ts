import { Injectable } from "@angular/core";
import { RepositoryService } from "src/app/shared/services/repository.service";
import { BannerDto } from "src/app/shared/models/banner.dto";

@Injectable()

export class ManageBannerService{
    bannerToEdit: BannerDto;
    constructor(private repository: RepositoryService) {
    }
    delete(bannerId) {
        return this.repository.delete("banners/" + bannerId);
      }
    
      update(bannerId:number, banner) {
        return this.repository.update("banners/" + bannerId, banner);
      }
    
      add(banner) {
        return this.repository.postForm("banners", banner);
      }
      getById(bannerId){
          return this.repository.getData("banners/" + bannerId);
      }
      gitPagedBanners(pager) {
          return this.repository.getData('banners'+ pager)
      }
}