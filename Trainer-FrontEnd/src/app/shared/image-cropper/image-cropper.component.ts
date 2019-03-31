import { Component, OnInit, EventEmitter, Output, SimpleChanges, ViewChild, OnChanges, Input } from '@angular/core';
import { ImageCroppedEvent } from 'ngx-image-cropper';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-image-cropper',
  templateUrl: './image-cropper.component.html',
  styleUrls: ['./image-cropper.component.css']
})
export class ImageCropperComponent implements OnInit, OnChanges {
 
  croppedImage;
  file;
  imageChangedEvent;
  @Output() imageCroppedEvent = new EventEmitter<any>();
  @Input() imageEvent: any;
  @Input() imageWidth = 400;
  @ViewChild('cropper') cropperModal;
  constructor(private modalService: NgbModal) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['imageEvent'] && changes['imageEvent'].currentValue) {
      this.imageChangedEvent = event;
    }
  }
  
  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
    this.file = event.file;
    this.imageCroppedEvent.emit(this.file);
  }

  open() {
    this.modalService.open(this.cropperModal);
  }
  

}
