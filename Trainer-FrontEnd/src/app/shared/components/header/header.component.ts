import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { config } from '../../../config/pages-config';
import { AuthService } from '../../../auth/services/auth.service';
import { UtilitiesService } from '../../services/utilities.service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  hideSearch: boolean;
  smallSize: boolean;
  configUrls = config;
  currentRoute: string;
  constructor(private router: Router, public authService: AuthService, private utilitiesService: UtilitiesService) {
    router.events.subscribe((val: any) => {

      if (val instanceof NavigationEnd) {
        // console.log(val.url)
        this.currentRoute = val.url;
      }

      if (val && val.route && val.route.path && val.route.path === 'home') {
        this.hideSearch = true;
      } else if (val && val.route && val.route.path && val.route.path !== 'home') {
        this.hideSearch = false;
      }
    });
  }

  ngOnInit() {
    if (document.body.clientWidth > 991) {
      this.smallSize = false;
    } else {
      this.smallSize = true;

    }
  }

  SearchBox() {
    var x = document.getElementById("search-box") as HTMLElement;
    if (x.style.display === "none" || x.style.display === "") {
      x.style.display = "block";
    } else {
      x.style.display = 'none';
    }
  }
  Close() {
    const x = document.getElementById('search-box') as HTMLElement;
    if (x.style.display === 'none') {
      x.style.display = 'block';
    } else {
      x.style.display = 'none';
    }
  }
  toggleClass() {
    var x = document.getElementsByClassName("offcanvas-collapse")[0];
    x.classList.toggle('open');
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  // showDropdown(element) {
  //   $('li.nav-item').mouseover(function () {
  //     $(this).find('.dropdown-list').slideDown();
  //   });
  // }

  // hideDropdown(element) {
  //   $('li.nav-item').mouseover(function () {
  //     $(this).find('.dropdown-list').slideUp();
  //   });
  // }

  ngAfterViewInit() {
    this.utilitiesService.handleHeaderMenu();
  }

}
