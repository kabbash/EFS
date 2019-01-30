import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductListItemEditComponent } from './product-list-item-edit.component';

describe('ProductListItemEditComponent', () => {
  let component: ProductListItemEditComponent;
  let fixture: ComponentFixture<ProductListItemEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductListItemEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductListItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
