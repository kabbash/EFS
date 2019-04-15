import { Injectable, Inject } from '@angular/core';
import { Request } from 'express';
import { REQUEST } from '@nguniversal/express-engine/tokens';
@Injectable()
export class ServerDimensionsHelper {

    constructor(@Inject(REQUEST) private request: Request) {
    }

    getDimensions(element: Element): ClientRect {
        const width = parseInt(this.request.cookies['CH-DW'], 10) || 1000;
        const height = parseInt(this.request.cookies['CH-DH'], 10) || 800;

        const adjustedWidth = width;
        const adjustedHeight = height;


        return {
            height: adjustedHeight,
            bottom: 0,
            top: 0,
            width: adjustedWidth,
            left: 0,
            right: 0
        };
    }
}
