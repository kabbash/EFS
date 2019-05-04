import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarbCalcComponent } from './carb-calc.component';

describe('CarbCalcComponent', () => {
  let component: CarbCalcComponent;
  let fixture: ComponentFixture<CarbCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarbCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarbCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
