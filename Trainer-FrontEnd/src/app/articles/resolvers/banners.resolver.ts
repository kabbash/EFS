import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { ResultMessage } from "src/app/shared/models/result-message";
import { BannerDto } from "src/app/shared/models/banner.dto";
import { Observable } from "rxjs";
import { RepositoryService } from "src/app/shared/services/repository.service";
import { AppConfig } from "src/config/app.config";

@Injectable()
export class BannersResolver implements Resolve<ResultMessage<BannerDto[]>>{
   
    constructor(private repositoryService: RepositoryService) {
        
    }
    resolve(): ResultMessage<BannerDto[]> | Observable<ResultMessage<BannerDto[]>> | Promise<ResultMessage<BannerDto[]>> {
        const pageSize = AppConfig.settings.pagination.articlesForAny.pageSize;
        return this.repositoryService.getData('banners?pageNo=1&pageSize=' + pageSize)
    }

}