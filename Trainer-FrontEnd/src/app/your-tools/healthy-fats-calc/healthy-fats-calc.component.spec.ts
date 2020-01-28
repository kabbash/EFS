import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthyFatsCalcComponent } from './healthy-fats-calc.component';

describe('HealthyFatsCalcComponent', () => {
  let component: HealthyFatsCalcComponent;
  let fixture: ComponentFixture<HealthyFatsCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HealthyFatsCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthyFatsCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
