import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/services/auth.service';
import { config } from 'src/app/config/pages-config';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  hideSearch: boolean;
  smallSize: boolean;
  configUrls = config;
  constructor(private router: Router, public authService: AuthService) {
    router.events.subscribe((val: any) => {
      // see also
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
    $(document).ready(function () {
      if (document.body.clientWidth > 991) {
        this.smallSize = false;
        $('#navbarsExampleDefault li.dropdown').hover(
          function () {
            $(this).addClass('hovered-item');
            $(this)
              .find('.dropdown-menu')
              .stop(true, true)
              .delay(200)
              .slideDown(200);
          },
          function () {
            $(this).removeClass('hovered-item');
            $(this)
              .find('.dropdown-menu')
              .stop(true, true)
              .delay(200)
              .slideUp(100);
          }
        );
      } else {
        $('.nav-item').click(function () {
          if ($('.navbar-collapse').hasClass('open') && !$(this).hasClass('dropdown')) {
            $('.navbar-collapse').removeClass('open');
          }
        });
        $('#navbarsExampleDefault li.dropdown').click(function () {
          if (!$(this).hasClass('hovered-item')) {
            $(this).addClass('hovered-item');
            $(this)
              .find('.dropdown-menu')
              .stop(true, true)
              .delay(200)
              .slideDown(200);
          } else {
            $(this).removeClass('hovered-item');
            $(this)
              .find('.dropdown-menu')
              .stop(true, true)
              .delay(200)
              .slideUp(200);
          }
        });
      }
    });
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

  logout(){
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

}
