import { Injectable } from '@angular/core';
import { PagedResult } from '../../shared/models/paged-result';
import { RepositoryService } from '../../shared/services/repository.service';
import { User } from '../../auth/models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private service: RepositoryService) { }

  getFilteredUsers(filterUrl: string) {
    return this.service.getData<PagedResult<User>>("authentication/GetAll" + filterUrl);
  }

  updateUserAccess(username, blocked): any {
    return this.service.create("authentication/UpdateUserAccess", { Username: username, Blocked: blocked });
  }

  addRoleToUser(username, role) {
    return this.service.create("authentication/AddRoleToUser", { Username: username, RoleName: role });
  }

  removeRoleFromUSer(username, role) {
    return this.service.create("authentication/RemoveRoleFromUser", { Username: username, RoleName: role });
  }
}
