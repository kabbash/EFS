import { Component, OnInit, Input } from '@angular/core';
import { environment } from '../../../environments/environment';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { SliderItemDto } from '../models/slider-item.dto';


@Component({
  selector: 'app-slider-edit-mode',
  templateUrl: './slider-edit-mode.component.html',
  styleUrls: ['./slider-edit-mode.component.css']
})
export class SliderEditModeComponent implements OnInit {

  @Input() sliderData: SliderItemDto[] = [];
  baseurl = environment.filesBaseUrl;
  closeResult: string;
  selectedImg: SliderItemDto;
  newPic = false;
  newImgDesc = '';
  newImgTitle = '';
  selectedIndexForDelete: number;
  deleteModal: any;
  showUploader = false;
  newImage =  new SliderItemDto();
  @Input() resultImageList: SliderItemDto[];
  constructor(
    private modalService: NgbModal) { }

  ngOnInit() {
  }

  open(content, index?) {
    if (index || index === 0) {
      this.newPic = false;
      this.selectedImg = this.sliderData[index];
      this.showUploader = false;
    } else {
      this.newPic = true;
      this.showUploader = true;

    }
    this.modalService.open(content);

  }

  deleteSlide() {
    const deletedImage = this.sliderData[this.selectedIndexForDelete];
    if (deletedImage.isNew) {
      const imageIndex = this.resultImageList.findIndex(image => image.file === deletedImage.file);
      this.resultImageList.splice(imageIndex, 1);
      
    } else {
      deletedImage.isDeleted = true;      
      this.resultImageList.push(deletedImage);   
    }
    this.sliderData.splice(this.selectedIndexForDelete, 1); 
    this.modalService.dismissAll();
  }

  deleteSlideModal(deleteModalContent, index) {
    this.selectedIndexForDelete = index;
    this.modalService.open(deleteModalContent);
  }

  onFileSelect(file) {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.newImage.path = e.target.result;
    };
    this.newImage.file = file;
    reader.readAsDataURL(file);
  }
  addNewImage(modal) {
    modal.close();
    this.newImage.isNew = true;
    this.sliderData.push(Object.assign({}, this.newImage));
    this.newImage.path = '';
    if (this.newImage.isProfilePicture) {
      this.setNewProfilePic();
    }
    this.resultImageList.push(Object.assign({}, this.newImage));
    this.newImage = new  SliderItemDto();

  }
  eidtImage(modal) {
    modal.close();
    this.selectedImg.isDataUpdated = true;
    if (this.selectedImg.isProfilePicture) {
      this.setNewProfilePic();
    }
    this.resultImageList.push(Object.assign({}, this.selectedImg));
  }
 
  setNewProfilePic() {
    this.resultImageList.forEach(image => {
      image.isProfilePicture = false;
    });
  }
}
