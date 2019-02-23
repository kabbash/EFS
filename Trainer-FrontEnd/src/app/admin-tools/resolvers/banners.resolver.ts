import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { ResultMessage } from "../../shared/models/result-message";
import { BannerDto } from "../../shared/models/banner.dto";
import { Observable } from "rxjs";
import { RepositoryService } from "../../shared/services/repository.service";
import { AppConfig } from "../../../config/app.config";

@Injectable()
export class BannersResolver implements Resolve<ResultMessage<BannerDto[]>>{
   
    constructor(private repositoryService: RepositoryService) {
        
    }
    resolve(): ResultMessage<BannerDto[]> | Observable<ResultMessage<BannerDto[]>> | Promise<ResultMessage<BannerDto[]>> {
        const pageSize = AppConfig.settings.pagination.articlesForAny.pageSize;
        return this.repositoryService.getData('banners?pageNo=1&pageSize=' + pageSize)
    }

}