import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsCatergoriesComponent } from './products-catergories.component';

describe('productsCatergoriesComponent', () => {
  let component: ProductsCatergoriesComponent;
  let fixture: ComponentFixture<ProductsCatergoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductsCatergoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsCatergoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
