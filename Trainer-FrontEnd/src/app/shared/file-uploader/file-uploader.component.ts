import { Component, OnInit, Input } from '@angular/core';
import {ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl} from '@angular/forms';
import { forwardRef } from '@angular/core';

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
    },
    , {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => FileUploaderComponent),
      multi: true
    }
  ]
})
export class FileUploaderComponent implements OnInit, ControlValueAccessor  {

  onTouched: () => void;
  onChanged: (_: any) => void;
  file: any;
  isDisabled = false;
  @Input() multiFiles = false;
  @Input() isRequired = false;
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

  onSelectFile(file) {
    this.file = file;
    this.onChanged(file);
  }

  constructor() { }

  ngOnInit() {
  }

}
