import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SliderEditModeComponent } from './slider-edit-mode.component';

describe('SliderEditModeComponent', () => {
  let component: SliderEditModeComponent;
  let fixture: ComponentFixture<SliderEditModeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SliderEditModeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SliderEditModeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
