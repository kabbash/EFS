import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FatCalcComponent } from './fat-calc.component';

describe('FatCalcComponent', () => {
  let component: FatCalcComponent;
  let fixture: ComponentFixture<FatCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FatCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FatCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
