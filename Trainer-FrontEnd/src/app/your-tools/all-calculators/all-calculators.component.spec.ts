import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YourToolsAllCalculatorsComponent } from './all-calculators.component';

describe('YourToolsAllCalculatorsComponent', () => {
  let component: YourToolsAllCalculatorsComponent;
  let fixture: ComponentFixture<YourToolsAllCalculatorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [YourToolsAllCalculatorsComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourToolsAllCalculatorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
