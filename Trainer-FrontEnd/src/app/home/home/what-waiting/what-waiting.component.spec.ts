import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WhatWaitingComponent } from './what-waiting.component';

describe('WhatWaitingComponent', () => {
  let component: WhatWaitingComponent;
  let fixture: ComponentFixture<WhatWaitingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WhatWaitingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WhatWaitingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
