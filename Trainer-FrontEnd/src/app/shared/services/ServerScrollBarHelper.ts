import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { ScrollbarHelper } from '@swimlane/ngx-datatable/release/services';

@Injectable()
export class ServerScrollBarHelper extends ScrollbarHelper {
    width: number;

    constructor(@Inject(DOCUMENT) document) {
        super(document);
        this.width = 16; // use default value
    }

    getWidth(): number {
        return this.width;
    }
}
