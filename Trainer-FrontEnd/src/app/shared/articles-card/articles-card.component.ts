import { Component, OnInit, Input } from '@angular/core';
import { url } from 'inspector';

@Component({
  selector: 'app-articles-card',
  templateUrl: './articles-card.component.html',
  styleUrls: ['./articles-card.component.css']
})
export class ArticlesCardComponent implements OnInit {

  @Input() cardName: string;
  @Input() cardImage: string;

  constructor() { }

  ngOnInit() {
  }

}
