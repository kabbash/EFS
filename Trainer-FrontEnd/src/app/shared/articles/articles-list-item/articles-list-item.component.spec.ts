import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlesListItemComponent } from './articles-list-item.component';

describe('ArticlesListItemComponent', () => {
  let component: ArticlesListItemComponent;
  let fixture: ComponentFixture<ArticlesListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticlesListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticlesListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
