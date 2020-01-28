import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {
  @Input() commentOwner: string;
  @Input() commentDate: string;
  @Input() comment: string;
  @Input() currentRate: number;
  constructor() { }

  ngOnInit() {
  }

}
