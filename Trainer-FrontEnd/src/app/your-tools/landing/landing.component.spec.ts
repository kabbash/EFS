import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YourToolsCalculatorsComponent } from './landing.component';

describe('YourToolsCalculatorsComponent', () => {
  let component: YourToolsCalculatorsComponent;
  let fixture: ComponentFixture<YourToolsCalculatorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YourToolsCalculatorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourToolsCalculatorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
