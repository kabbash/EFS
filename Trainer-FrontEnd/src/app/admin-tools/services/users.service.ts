import { Injectable } from '@angular/core';
import { PagedResult } from '../../shared/models/paged-result';
import { RepositoryService } from '../../shared/services/repository.service';
import { User } from 'src/app/auth/models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private service: RepositoryService) { }

  delete(userId: Number) {
    return this.service.delete("authentication/" + userId);
  }

  getFilteredUsers(filterUrl: string) {
    return this.service.getData<PagedResult<User>>("authentication/GetAll" + filterUrl);
  }

  update(userId: number, product: FormData): any {
    return this.service.update("authentication/" + userId, product);
  }

  add(product: FormData): any {
    return this.service.postForm("authentication" , product);
  }
}
