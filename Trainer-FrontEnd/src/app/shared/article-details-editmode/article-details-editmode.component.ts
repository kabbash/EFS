import { Component, OnInit, Input } from '@angular/core';
import { articleDetialsDto } from '../models/article-details-dto';
import { environment } from '../../../environments/environment';
import { ddlDto, ddlItemDto } from '../models/ddl-dto';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RepositoryService } from '../services/repository.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-article-details-editmode',
  templateUrl: './article-details-editmode.component.html',
  styleUrls: ['./article-details-editmode.component.css']
})
export class ArticleDetailsEditmodeComponent implements OnInit {

  @Input() article: articleDetialsDto;
  @Input() articlesCategories: ddlItemDto[];
  articleBody: string;
  baseurl = environment.filesBaseUrl;
  categoriesDDL: ddlDto = new ddlDto();
  selectedImg = {};
  newPic = false;
  newImgDesc = '';
  newImgTitle = '';
  closeResult: string;
  public articleForm: FormGroup;
  public submitted = false;

  constructor(private modalService: NgbModal, private service: RepositoryService, private fb: FormBuilder) { }

  ngOnInit() {
    this.service.getData<ddlItemDto[]>("common/getEntityDDL?entityDDLId=2").subscribe(result => {
      this.categoriesDDL.items = result.data;
      this.article.categoryId = this.article.categoryId || 0;
    });

    this.articleForm = this.fb.group({
      'name': ['يييssss', Validators.required],
      // 'description': ['', Validators.required],
      'categoryId': ['', Validators.required]
      // 'profilePictureFile': [null, !this.articleCategory.profilePicture ? Validators.required : null],
    });
  }

  get f() { return this.articleForm.controls; }

  open(content, selectedArticle, index) {
    this.newPic = false;
    this.modalService.open(content);
    this.selectedImg = selectedArticle.images[index];
  }

  addNewPic() {
    this.newPic = true;
  }

}
