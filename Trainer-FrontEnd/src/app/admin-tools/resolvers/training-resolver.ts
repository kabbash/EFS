import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { ResultMessage } from "../../shared/models/result-message";
import { BannerDto } from "../../shared/models/banner.dto";
import { Observable } from "rxjs";
import { RepositoryService } from "../../shared/services/repository.service";

@Injectable()
export class TrainingResolver implements Resolve<ResultMessage<BannerDto[]>>{
   
    constructor(private repositoryService: RepositoryService) {
        
    }
    resolve(): ResultMessage<BannerDto[]> | Observable<ResultMessage<BannerDto[]>> | Promise<ResultMessage<BannerDto[]>> {
        return this.repositoryService.getData('banners')
    }
}