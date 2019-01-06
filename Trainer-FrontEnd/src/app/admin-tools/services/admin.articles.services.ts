import { Injectable } from "@angular/core";
import { RepositoryService } from "src/app/shared/services/repository.service";
import { articleListItemDto } from "src/app/shared/models/article-list-item-dto";
import { ResultMessage } from "src/app/shared/models/result-message";
import { PagedResult } from "src/app/shared/models/paged-result";

@Injectable()
export class AdminArticlesService {
  constructor(private service: RepositoryService) { }

  approve(articleId) {
    return this.service.post("articles/approve", { id: articleId });
  }

  reject(articleId) {
    return this.service.post("articles/reject", { id: articleId });
  }

  delete(articleId) {
    return this.service.delete("articles/" + articleId);
  }

  update(articleId:number, article) {
    debugger;
    return this.service.update("articles/" + articleId, article);
  }
  getFilteredArticles(filterUrl) {
    return this.service.getData<PagedResult<articleListItemDto>>("articles/getFilteredData" + filterUrl);
  }
}
