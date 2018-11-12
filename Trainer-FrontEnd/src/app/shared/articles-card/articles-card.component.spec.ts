import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlesCardComponent } from './articles-card.component';

describe('ArticlesCardComponent', () => {
  let component: ArticlesCardComponent;
  let fixture: ComponentFixture<ArticlesCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticlesCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticlesCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
