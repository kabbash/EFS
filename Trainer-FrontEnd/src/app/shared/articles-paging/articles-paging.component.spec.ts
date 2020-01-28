import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlesPagingComponent } from './articles-paging.component';

describe('ArticlesPagingComponent', () => {
  let component: ArticlesPagingComponent;
  let fixture: ComponentFixture<ArticlesPagingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticlesPagingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticlesPagingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
