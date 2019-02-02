import { Injectable } from "@angular/core";
import { RepositoryService } from "../../shared/services/repository.service";
import { articleListItemDto } from "../../shared/models/articles/article-list-item-dto";
import { PagedResult } from "../../shared/models/paged-result";
import { ddlItemDto } from "../../shared/models/ddl-dto";
import { ArticleDetialsDto } from "../../shared/models/articles/article-details-dto";

@Injectable()
export class AdminArticlesService {
  constructor(private service: RepositoryService) { }

  approve(articleId) {
    return this.service.post("articles/approve", { id: articleId });
  }

  reject(articleId,rejectReason) {
    return this.service.post("articles/reject", { id: articleId , rejectReason: rejectReason});
  }

  delete(articleId) {
    return this.service.delete("articles/" + articleId);
  }

  update(articleId:number, article) {
    return this.service.update("articles/" + articleId, article);
  }

  add(article) {
    return this.service.postForm("articles", article);
  }

  getFilteredArticles(filterUrl) {
    return this.service.getData<PagedResult<articleListItemDto>>("articles/getforadmin" + filterUrl);
  }

  getCategories(){
    return this.service.getData<ddlItemDto[]>("common/getEntityDDL?entityDDLId=2")
  }
}
