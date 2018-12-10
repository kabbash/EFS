import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddArticleCategoryComponent } from './add-article-category.component';

describe('AddArticleCategoryComponent', () => {
  let component: AddArticleCategoryComponent;
  let fixture: ComponentFixture<AddArticleCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddArticleCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddArticleCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
