import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroPanerComponent } from './hero-paner.component';

describe('HeroPanerComponent', () => {
  let component: HeroPanerComponent;
  let fixture: ComponentFixture<HeroPanerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroPanerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroPanerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
