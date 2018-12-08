import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
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
