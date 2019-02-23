import { Component, OnInit, Input } from '@angular/core';
import { ArticleDetialsDto } from '../models/articles/article-details-dto';
import { environment } from '../../../environments/environment';
import { ddlDto, ddlItemDto } from '../models/ddl-dto';
import { RepositoryService } from '../services/repository.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

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
      'categoryId': ['', Validators.min(1)]
    });
  }

  get f() { return this.articleForm.controls; }

}
