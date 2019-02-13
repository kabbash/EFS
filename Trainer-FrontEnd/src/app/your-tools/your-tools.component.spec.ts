import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YourToolsComponent } from './your-tools.component';

describe('YourToolsComponent', () => {
  let component: YourToolsComponent;
  let fixture: ComponentFixture<YourToolsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [YourToolsComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YourToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
