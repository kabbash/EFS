import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageProductsCategoriesComponent } from './manage-products-categories.component';

describe('ManageProductsCategoriesComponent', () => {
  let component: ManageProductsCategoriesComponent;
  let fixture: ComponentFixture<ManageProductsCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageProductsCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageProductsCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
