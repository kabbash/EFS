import { Component, OnInit, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl } from '@angular/forms';
import { DropDownDto } from '../models/drop-down.dto';

export function createDropdownValidator(required: boolean) {
  return (c: FormControl) => {
    if (required) {
      return (c.value) ? null : { required: true };
    } else {
      return null;
    }
  };
}

@Component({
  selector: 'app-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrls: ['./drop-down.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DropDownComponent),
      multi: true
    }
    , {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => DropDownComponent),
      multi: true
    }
  ]
})
export class DropDownComponent implements OnInit, ControlValueAccessor {

  innerValue: number;
  isDisabled = false;
  @Input() isRequired = false;
  @Input() data: DropDownDto;
  @Input() id: string;
  @Input() label: string;
  @Input() name: string;
  onTouched: () => void;
  onChanged: (_: any) => void;

  writeValue(obj: any): void {
    this.innerValue = obj;
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
    return createDropdownValidator(this.isRequired);
  }

  onSelect(value) {
    this.innerValue = value;
  }

  set selected(v: any) {
    if (v !== this.innerValue) {
      this.innerValue = v;
    }
  }

  constructor() { }

  ngOnInit() {
  }

}
