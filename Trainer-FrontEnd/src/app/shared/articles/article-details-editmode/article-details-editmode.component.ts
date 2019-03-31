import { Component, OnInit, Input } from '@angular/core';
import { ArticleDetialsDto } from '../../models/articles/article-details-dto';
import { environment } from '../../../../environments/environment';
import { ddlDto, ddlItemDto } from '../../models/ddl-dto';
import { RepositoryService } from '../../services/repository.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PredefinedCategories } from '../../models/articles/articles-predefined-categories.enum';
import { debug } from 'util';

@Component({
  selector: 'app-article-details-editmode',
  templateUrl: './article-details-editmode.component.html',
  styleUrls: ['./article-details-editmode.component.css']
})
export class ArticleDetailsEditmodeComponent implements OnInit {

  @Input() modifiedArticle: ArticleDetialsDto;
  @Input() articlesCategories: ddlItemDto[];
  @Input() showDateAndPlace: boolean = false;

  baseurl = environment.filesBaseUrl;
  categoriesDDL: ddlDto = new ddlDto();
  closeResult: string;
  public articleForm: FormGroup;
  public submitted = false;

  constructor(private service: RepositoryService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.service.getData<ddlItemDto[]>('common/getEntityDDL?entityDDLId=2').subscribe(result => {
      this.categoriesDDL.items = result.data;
      this.modifiedArticle.categoryId = this.modifiedArticle.categoryId || 0;
    });

    this.articleForm = this.fb.group({
      'name': ['', Validators.required],
      'categoryId': ['', Validators.min(1)],
      'date': [],
      'place': []
    });

    this.formControlValueChanged();
  }

  get f() { return this.articleForm.controls; }

  isChampionshipModule() {
    return this.modifiedArticle.categoryId === PredefinedCategories.Championships;
  }

  formControlValueChanged() {
    const placeControl = this.articleForm.get('place');
    const dateControl = this.articleForm.get('date');
    this.articleForm.get('categoryId').valueChanges.subscribe(
      (catgeoryId: number) => {
        if (catgeoryId === PredefinedCategories.Championships) {
          placeControl.setValidators([Validators.required]);
          dateControl.setValidators([Validators.required]);
        }
        else {
          placeControl.clearValidators();
          dateControl.clearValidators();
        }
        placeControl.updateValueAndValidity();
        dateControl.updateValueAndValidity();
      });
  }
}
