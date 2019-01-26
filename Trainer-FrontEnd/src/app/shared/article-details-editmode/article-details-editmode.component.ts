import { Component, OnInit, Input } from '@angular/core';
import { ArticleDetialsDto } from '../models/article-details-dto';
import { environment } from '../../../environments/environment';
import { ddlDto, ddlItemDto } from '../models/ddl-dto';
import { RepositoryService } from '../services/repository.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UtilitiesService } from '../services/utilities.service';
import { SliderItemDto } from '../models/slider-item.dto';

@Component({
  selector: 'app-article-details-editmode',
  templateUrl: './article-details-editmode.component.html',
  styleUrls: ['./article-details-editmode.component.css']
})
export class ArticleDetailsEditmodeComponent implements OnInit {

  @Input() modifiedArticle: ArticleDetialsDto;
  @Input() articlesCategories: ddlItemDto[];
  baseurl = environment.filesBaseUrl;
  categoriesDDL: ddlDto = new ddlDto();
  selectedImg = {};
  newPic = false;
  newImgDesc = '';
  newImgTitle = '';
  closeResult: string;
  sliderData: SliderItemDto[];
  public articleForm: FormGroup;
  public submitted = false;

  constructor(private service: RepositoryService,
     private fb: FormBuilder,
     private util: UtilitiesService) { }

  ngOnInit() {
    this.service.getData<ddlItemDto[]>('common/getEntityDDL?entityDDLId=2').subscribe(result => {
      this.categoriesDDL.items = result.data;
      this.modifiedArticle.categoryId = this.modifiedArticle.categoryId || 0;
    });

    this.articleForm = this.fb.group({
      'name': ['', Validators.required],
      'categoryId': ['', Validators.min(1)]
    });
    this.sliderData = this.util.mapToSliderDtoArray(this.modifiedArticle.images);
  }

  get f() { return this.articleForm.controls; }

}
