import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SetResetedPasswordComponent } from './set-reseted-password.component';

describe('SetResetedPasswordComponent', () => {
  let component: SetResetedPasswordComponent;
  let fixture: ComponentFixture<SetResetedPasswordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SetResetedPasswordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SetResetedPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
