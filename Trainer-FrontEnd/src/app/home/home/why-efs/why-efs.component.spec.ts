import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WhyEFSComponent } from './why-efs.component';

describe('WhyEFSComponent', () => {
  let component: WhyEFSComponent;
  let fixture: ComponentFixture<WhyEFSComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WhyEFSComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WhyEFSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
