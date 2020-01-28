import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageNeutrintsComponent } from './manage-neutrints.component';

describe('ManageNeutrintsComponent', () => {
  let component: ManageNeutrintsComponent;
  let fixture: ComponentFixture<ManageNeutrintsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageNeutrintsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageNeutrintsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
