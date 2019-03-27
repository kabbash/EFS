import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageOnlineTrainingComponent } from './manage-online-training.component';

describe('ManageOnlineTrainingComponent', () => {
  let component: ManageOnlineTrainingComponent;
  let fixture: ComponentFixture<ManageOnlineTrainingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageOnlineTrainingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageOnlineTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
