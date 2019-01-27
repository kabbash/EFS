import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-tools',
  templateUrl: './admin-tools.component.html',
  styleUrls: ['./admin-tools.component.css']
})
export class AdminToolsComponent implements OnInit {
  closeMenu = false;
  constructor() { }

  ngOnInit() {
  }

  toggleMenu(close) {
    if (close) {
      this.closeMenu = true;
    } else {
      this.closeMenu = false;
    }
  }
}
