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
export class FileUploaderComponent implements OnInit, ControlValueAccessor {

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
    this.file = event.target.files[0];
    this.onChanged(event.target.files[0]);
    this.imageChangedEvent = event;
  }

  imageCropped(event: ImageCroppedEvent) {
    this.croppedImage = event.base64;
    this.file = event.file;
    this.imageCroppedEvent.emit(this.file);
}

  constructor() { }

  ngOnInit() {
    
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
