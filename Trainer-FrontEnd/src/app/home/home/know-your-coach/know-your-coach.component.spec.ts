import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowYourCoachComponent } from './know-your-coach.component';

describe('KnowYourCoachComponent', () => {
  let component: KnowYourCoachComponent;
  let fixture: ComponentFixture<KnowYourCoachComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KnowYourCoachComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KnowYourCoachComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
