import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpinionsOfTraineesComponent } from './opinions-of-trainees.component';

describe('OpinionsOfTraineesComponent', () => {
  let component: OpinionsOfTraineesComponent;
  let fixture: ComponentFixture<OpinionsOfTraineesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpinionsOfTraineesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpinionsOfTraineesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
