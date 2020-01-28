import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodItemsListComponent } from './food-items-list.component';

describe('FoodItemsListComponent', () => {
  let component: FoodItemsListComponent;
  let fixture: ComponentFixture<FoodItemsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodItemsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodItemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
