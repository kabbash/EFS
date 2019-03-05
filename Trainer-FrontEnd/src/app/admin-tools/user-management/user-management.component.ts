import { Component, OnInit } from '@angular/core';
import { PagerDto } from 'src/app/shared/models/pager.dto';
import { AppConfig } from 'src/config/app.config';
import { UsersService } from '../services/users.service';
import { User } from 'src/app/auth/models/user';
import { AppService } from 'src/app/app.service';
import { UsersFilter } from 'src/app/shared/models/users/users-filter';
import { ActivatedRoute } from '@angular/router';
import { Roles } from 'src/app/auth/models/roles.enum';
import { first, finalize } from 'rxjs/operators';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  pagerDto = new PagerDto();
  usersList: User[];
  filter = new UsersFilter();
  roles: string[];
  selected = [];
  roleToAdd = "";
  constructor(private route: ActivatedRoute, private service: UsersService, private appService: AppService) { }

  ngOnInit() {
    this.roles = Object.keys(Roles);
    this.pagerDto.pageSize = this.filter.pageSize = AppConfig.settings.pagination.usersForAdmin.pageSize;
    this.route.data.subscribe(result => {
      this.pagerDto = result.users.data;
      this.usersList = result.users.data.results;
      // this.roles = result.roles.data;
    });
  }

  getData() {
    this.appService.loading = true;
    var searchText = this.filter.searchText != undefined && this.filter.searchText != null && this.filter.searchText != "" ? "&searchText=" + this.filter.searchText.trim() : "";
    var isBlocked = this.filter.isBlocked != undefined && this.filter.isBlocked != null ? "&isBlocked=" + this.filter.isBlocked : "";
    var role = this.filter.role != undefined && this.filter.role != null ? "&role=" + this.filter.role : "";
    let filter = `?pageNo=${this.pagerDto.currentPage}&pageSize=${this.pagerDto.pageSize}${searchText}${isBlocked}${role}`;
    this.service.getFilteredUsers(filter)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      })).subscribe(result => {
        this.usersList = result.data.results;
        this.pagerDto = result.data;        
      });
  }

  setPage(pageInfo) {
    this.pagerDto.currentPage = pageInfo.offset;
    this.filter.pageNo = pageInfo.offset;
    this.getData();
  }

  search() {
    this.pagerDto.currentPage = 1;
    this.getData();
  }

  onSelect({ selected }) {

    this.selected = selected;
  }

  removeRole(sel) {

    var selectedUser = this.selected[0] as User;
    this.appService.loading = true;
    this.service.removeRoleFromUSer(selectedUser.email, sel)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      })).subscribe(result => {
        if (result.status == 200) {
          var index = selectedUser.roles.indexOf(sel, 0);
          if (index >= 0) {
            selectedUser.roles.splice(index, 1);
            this.getData();
          }
        }
      });
  }
  
  addRole() {

    var selectedUser = this.selected[0] as User;
    var index = selectedUser.roles.indexOf(this.roleToAdd, 0);
    if (index >= 0) {
      return;
    }
    if (this.roleToAdd != "") {
      this.appService.loading = true;
      this.service.addRoleToUser(selectedUser.email, this.roleToAdd)
        .pipe(first(), finalize(() => {
          this.appService.loading = false;
        })).subscribe(result => {
          if (result.status == 200) {
           selectedUser.roles.push(this.roleToAdd);
            this.getData();
          }
        });
    }
  }

  updateUserAccess(username,blocked){
    this.appService.loading = true;
    this.service.updateUserAccess(username, blocked)
      .pipe(first(), finalize(() => {
        this.appService.loading = false;
      })).subscribe(result => {
        if (result.status == 200) {
          this.getData();
        }
      });
  }
}

