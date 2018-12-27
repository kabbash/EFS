import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PendingApprovalArticlesComponent } from './pending-approval-articles.component';

describe('PendingApprovalArticlesComponent', () => {
  let component: PendingApprovalArticlesComponent;
  let fixture: ComponentFixture<PendingApprovalArticlesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PendingApprovalArticlesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PendingApprovalArticlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
