import { Component, OnInit, Input } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../shared/services/repository.service';
import { ArticleDetialsDto } from '../../shared/models/article-details-dto';
import { AppService } from '../../app.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-article-details-card',
  templateUrl: './article-details-card.component.html',
  styleUrls: ['./article-details-card.component.css']
})
export class ArticleDetailsCardComponent implements OnInit {

  images = [1, 2, 3].map(() => `https://picsum.photos/900/500?random&t=${Math.random()}`);

  @Input() article: ArticleDetialsDto;
  baseurl = environment.filesBaseUrl;
  closeResult: string;
  selectedImg = {};
  newPic = false;
  newImgDesc = '';
  newImgTitle = '';
  selectedIndexForDelete: number;
  deleteModal: any;


  constructor(private router: Router,
    private route: ActivatedRoute,
    private repositoryService: RepositoryService,
    private appService: AppService,
    private modalService: NgbModal) {
  }

  ngOnInit() {
    // this.route.data.subscribe(result => {
    //   this.article = result.details.data;
    //   this.appService.loading = false;
    // });
  }

  open(content, selectedArticle?, index?) {
    this.modalService.open(content);
    if (index || index === 0) {
      this.newPic = false;
      this.selectedImg = selectedArticle.images[index];
    } else {
      this.newPic = true;
    }
  }


  deleteSlide() {
    this.article.images.splice(this.selectedIndexForDelete, 1);
    this.modalService.dismissAll();
  }


  deleteSlideModal(deleteModalContent, selectedArticle, index) {
    this.selectedIndexForDelete = index;
    this.modalService.open(deleteModalContent);
  }

}
