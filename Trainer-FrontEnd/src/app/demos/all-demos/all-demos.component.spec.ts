import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllDemosComponent } from './all-demos.component';

describe('AllDemosComponent', () => {
  let component: AllDemosComponent;
  let fixture: ComponentFixture<AllDemosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllDemosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllDemosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
