import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddItemForReviewComponent } from './add-item-for-review.component';

describe('AddItemForReviewComponent', () => {
  let component: AddItemForReviewComponent;
  let fixture: ComponentFixture<AddItemForReviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddItemForReviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddItemForReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
