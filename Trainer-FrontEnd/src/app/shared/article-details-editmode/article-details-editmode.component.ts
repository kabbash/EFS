import { Component, OnInit, Input } from '@angular/core';
import { articleDetialsDto } from '../models/article-details-dto';
import { environment } from '../../../environments/environment';
import { ddlDto, ddlItemDto } from '../models/ddl-dto';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RepositoryService } from '../services/repository.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-article-details-editmode',
  templateUrl: './article-details-editmode.component.html',
  styleUrls: ['./article-details-editmode.component.css']
})
export class ArticleDetailsEditmodeComponent implements OnInit {

  @Input() modifiedArticle: articleDetialsDto;
  @Input() articlesCategories: ddlItemDto[];
  baseurl = environment.filesBaseUrl;
  categoriesDDL: ddlDto = new ddlDto();
  selectedImg = {};
  newPic = false;
  newImgDesc = '';
  newImgTitle = '';
  closeResult: string;
  public articleForm: FormGroup;
  public submitted = false;

  constructor(private modalService: NgbModal, private service: RepositoryService, private fb: FormBuilder, private translate: TranslateService) { }

  ngOnInit() {
    this.service.getData<ddlItemDto[]>("common/getEntityDDL?entityDDLId=2").subscribe(result => {
      this.categoriesDDL.items = result.data;
      this.modifiedArticle.categoryId = this.modifiedArticle.categoryId || 0;
    });
    // // this.translate.get('editArticle.formValidations.articleNameValidation').subscribe(data => {
    // //   console.log(data);
    //}) 
    this.articleForm = this.fb.group({
      'name': ['', Validators.required],
      'categoryId': ['', Validators.min(1)]
      // 'profilePictureFile': [null, !this.articleCategory.profilePicture ? Validators.required : null],
    });
  }

  get f() { return this.articleForm.controls; }

}
