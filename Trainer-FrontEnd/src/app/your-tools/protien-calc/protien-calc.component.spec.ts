import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProtienCalcComponent } from './protien-calc.component';

describe('ProtienCalcComponent', () => {
  let component: ProtienCalcComponent;
  let fixture: ComponentFixture<ProtienCalcComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProtienCalcComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProtienCalcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
