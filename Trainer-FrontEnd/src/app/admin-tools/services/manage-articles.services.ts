import { Injectable } from "@angular/core";
import { RepositoryService } from "src/app/shared/services/repository.service";

@Injectable()
export class ManageArticleService {
  constructor(private service: RepositoryService) {}

  approve(articleId){
     return this.service.post("articles/approve", {id:articleId});
  }

    reject(articleId){
        return this.service.post("articles/reject", {id: articleId});
  }
}
