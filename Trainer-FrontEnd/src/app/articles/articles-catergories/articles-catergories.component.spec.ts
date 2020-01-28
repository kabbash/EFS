import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlesCatergoriesComponent } from './articles-catergories.component';

describe('ArticlesCatergoriesComponent', () => {
  let component: ArticlesCatergoriesComponent;
  let fixture: ComponentFixture<ArticlesCatergoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticlesCatergoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticlesCatergoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
