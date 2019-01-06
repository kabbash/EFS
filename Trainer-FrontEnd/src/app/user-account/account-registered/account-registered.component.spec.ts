import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountRegisteredComponent } from './account-registered.component';

describe('AccountRegisteredComponent', () => {
  let component: AccountRegisteredComponent;
  let fixture: ComponentFixture<AccountRegisteredComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountRegisteredComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountRegisteredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
