import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from '../../../app.service';
import { articleListItemDto } from '../../models/articles/article-list-item-dto';
import { environment } from '../../../../environments/environment';
import { UtilitiesService } from '../../services/utilities.service';

@Component({
  selector: 'app-articles-list-item',
  templateUrl: './articles-list-item.component.html',
  styleUrls: ['./articles-list-item.component.css']
})
export class ArticlesListItemComponent implements OnInit {
  @Input() hideShowMorelink: boolean;
  @Input() showDateAndPlace: boolean;
  @Input() articleDto: articleListItemDto;
  @Input() hideDescription: boolean;

  cardName: string;
  cardImage: string;
  cardShortDescription: string;
  cardPlace: string;
  cardDate: string;

  constructor(private router: Router, private appService: AppService,private utilService: UtilitiesService) { }

  ngOnInit() {
    this.cardName = this.articleDto.name;
    this.cardShortDescription = this.hideDescription ? '' : this.articleDto.description.substr(0, 200);
    this.cardImage = environment.filesBaseUrl + this.articleDto.profilePicture;
    this.cardPlace = this.articleDto.place;
    this.cardDate = this.articleDto.date ? this.utilService.getArabicDate(this.articleDto.date) : '';
  }
}
