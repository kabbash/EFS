import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfectWeightCalcComponent } from './perfect-weight-calc.component';

describe('PerfectWeightCalcComponent', () => {
  let component: PerfectWeightCalcComponent;
  let fixture: ComponentFixture<PerfectWeightCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PerfectWeightCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PerfectWeightCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
