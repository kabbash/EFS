import { Injectable } from "@angular/core";
import { RepositoryService } from "../../shared/services/repository.service";
import { articleListItemDto } from "../../shared/models/article-list-item-dto";
import { PagedResult } from "../../shared/models/paged-result";
import { ddlItemDto } from "../../shared/models/ddl-dto";
import { ArticleDetialsDto } from "../../shared/models/article-details-dto";

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
    return this.service.getData<PagedResult<articleListItemDto>>("articles/getFilteredData" + filterUrl);
  }

  getCategories(){
    return this.service.getData<ddlItemDto[]>("common/getEntityDDL?entityDDLId=2")
  }

  
  setArticleProfilePic(article: ArticleDetialsDto, isAdd:boolean) {
    if (isAdd) {
      if (article.images && article.images.findIndex(image => image.isProfilePicture) === -1) {
        article.images[0].isProfilePicture = true;
      }
    } else {
      if (!article.updatedImages.find(image => image.isProfilePicture && !image.isDeleted) 
      && !article.images.find(image => image.isProfilePicture)) {
        const profilePic = article.updatedImages.find(image => !image.isDeleted);
        if (profilePic) {
          profilePic.isProfilePicture = true;        
        } else {
          article.images[0].isProfilePicture = true;
          article.updatedImages.push(article.images[0]);
        }
      }
    }
    
  }
}
