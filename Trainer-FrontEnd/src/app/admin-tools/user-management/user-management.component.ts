import { Component, OnInit } from '@angular/core';
import { PagerDto } from 'src/app/shared/models/pager.dto';
import { AppConfig } from 'src/config/app.config';
import { UsersService } from '../services/users.service';
import { User } from 'src/app/auth/models/user';
import { AppService } from 'src/app/app.service';
import { UsersFilter } from 'src/app/shared/models/users/users-filter';
import { ddlItemDto } from 'src/app/shared/models/ddl-dto';
import { ActivatedRoute } from '@angular/router';
import { Role } from 'src/app/shared/models/users/role.dto';
import { Roles } from 'src/app/auth/models/roles.enum';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  pagerDto: PagerDto;
  usersList: User[];
  filter: UsersFilter;
  roles: string[];
  role: Roles;
  constructor(private route: ActivatedRoute, private service: UsersService, private appService: AppService) { }

  ngOnInit() {
    this.roles = Object.keys(this.role);
    this.pagerDto.pageSize = this.filter.pageSize = AppConfig.settings.pagination.usersForAdmin.pageSize;
    this.route.data.subscribe(result => {
      this.pagerDto = result.users.data;
      this.usersList = result.users.data.results;
      // this.roles = result.roles.data;
    });
  }

  getData() {
    this.appService.loading = true;
    let filter = `?pageNo=${this.filter.pageNo}&pageSize=${this.filter.pageSize}&searchText=${this.filter.searchText.trim()}&isBlocked=${this.filter.isBlocked}&role=${this.filter.role}`;
    this.service.getFilteredUsers(filter).subscribe(result => {
      this.usersList = result.data.results;
      this.pagerDto = result.data;
      this.appService.loading = false;
    });
  }

  setPage(pageInfo) {
    this.pagerDto.currentPage = pageInfo.offset;
    this.filter.pageNo = pageInfo.offset;
    this.getData();
  }

  search() {
    this.pagerDto.currentPage = 0;
    this.getData();
  }

}
