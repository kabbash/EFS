import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl } from '@angular/forms';
import { forwardRef } from '@angular/core';
import { ImageCroppedEvent } from 'ngx-image-cropper';


export function createFileUploaderValidator(required: boolean) {
  return (c: FormControl) => {
    if (required) {
      return (c.value) ? null : { required: true };
    } else {
      return null;
    }
  };
}
@Component({
  selector: 'app-file-uploader',
  templateUrl: './file-uploader.component.html',
  styleUrls: ['./file-uploader.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => FileUploaderComponent),
      multi: true
    }
    , {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => FileUploaderComponent),
      multi: true
    }
  ]
})
export class FileUploaderComponent implements ControlValueAccessor {

  onTouched: () => void;
  onChanged: (_: any) => void;
  file: any;
  isDisabled = false;
  croppedImage;
  imageChangedEvent;
  @Input() multiFiles = false;
  @Input() isRequired = false;
  @Input() classList: string;
  @Input() buttonValue: string;
  @Output() imageCroppedEvent = new EventEmitter<any>()
  @Output() fileChanged = new EventEmitter<any>();
  allowedExtension = ['jpg', 'png', 'jpeg'];
  hasSizeError = false;
  hasExtError = false;

  writeValue(obj: any): void {
    this.file = obj;
  }
  registerOnChange(fn: any): void {
    this.onChanged = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  validate(c: FormControl) {
    return createFileUploaderValidator(this.isRequired);
  }

  onSelectFile(event) {

    debugger;
    this.hasExtError = false;
    this.hasSizeError = false;

    if (!event.target || !event.target.files || !event.target.files.length) {
      this.file = null;
      return;
    }

    if (event.target.files[0] && ((event.target.files[0].size / 1024) / 1024) > 5) {
      this.hasSizeError= true;
      this.file = null;
      return;
    }
    if (event.target.files[0] && event.target.files[0].name && (this.allowedExtension.indexOf(event.target.files[0].name.split('.').pop().toLowerCase()) == -1)) {
      this.hasExtError = true;
      this.file = null;
      return;
    }
    this.file = event.target.files[0];
    this.fileChanged.emit(event);
  }

  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
    this.file = event.file;
    this.imageCroppedEvent.emit(this.file);
  }

  imageLoaded() {
    alert('image loaded')
  }
  cropperReady() {
    // cropper ready
    alert('cropped ready')
  }
  loadImageFailed() {
    // show message
    alert('load failed')
  }

}
