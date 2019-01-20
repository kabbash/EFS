import { Component, OnInit, Input } from '@angular/core';
import { environment } from '../../../environments/environment';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-slider-edit-mode',
  templateUrl: './slider-edit-mode.component.html',
  styleUrls: ['./slider-edit-mode.component.css']
})
export class SliderEditModeComponent implements OnInit {

  @Input() images= [];
  baseurl = environment.filesBaseUrl;
  closeResult: string;
  selectedImg = {};
  newPic = false;
  newImgDesc = '';
  newImgTitle = '';
  selectedIndexForDelete: number;
  deleteModal: any;
  
  constructor(
    private modalService: NgbModal) { }

  ngOnInit() {
  }

  open(content, index?) {
    this.modalService.open(content);
    if (index || index === 0) {
      this.newPic = false;
      this.selectedImg = this.images[index];
    } else {
      this.newPic = true;
    }
  }

  deleteSlide() {
    this.images.splice(this.selectedIndexForDelete, 1);
    this.modalService.dismissAll();
  }

  deleteSlideModal(deleteModalContent, index) {
    this.selectedIndexForDelete = index;
    this.modalService.open(deleteModalContent);
  }

  onFileSelect(file) {
    debugger;
    // this.articleCategory.profilePictureFile = file;
    const reader = new FileReader();
    reader.onload = (e: any) => {
      // this.articleCategory.profilePicture = e.target.result;
      // this.addedImageUrl = e.target.result;
    };
    reader.readAsDataURL(file);
  }
}
