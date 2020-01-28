import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.css']
})
export class FormsComponent implements OnInit {
  isCollapsed = false;
  iconCollapse = 'icon-arrow-up';
  editorContent = '<h1>Documentation : https://www.froala.com/wysiwyg-editor/docs/framework-plugins/angularjs-2-4 !!!</h1>';

  constructor() { }

  ngOnInit() {
  }

  collapsed(event: any): void {
    // console.log(event);
  }

  expanded(event: any): void {
    // console.log(event);
  }

  toggleCollapse(): void {
    this.isCollapsed = !this.isCollapsed;
    this.iconCollapse = this.isCollapsed ? 'icon-arrow-down' : 'icon-arrow-up';
  }
}
