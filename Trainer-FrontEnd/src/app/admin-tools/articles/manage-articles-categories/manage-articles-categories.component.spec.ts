import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageArticlesCategoriesComponent } from './manage-articles-categories.component';

describe('ManageArticlesCategoriesComponent', () => {
  let component: ManageArticlesCategoriesComponent;
  let fixture: ComponentFixture<ManageArticlesCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageArticlesCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageArticlesCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
