import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YourToolsLandingComponent } from './landing.component';

describe('YourToolsLandingComponent', () => {
  let component: YourToolsLandingComponent;
  let fixture: ComponentFixture<YourToolsLandingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YourToolsLandingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourToolsLandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
