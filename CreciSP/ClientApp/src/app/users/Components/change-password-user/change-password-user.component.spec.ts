import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangePasswordUserComponent } from './change-password-user.component';

describe('ChangePasswordUserComponent', () => {
  let component: ChangePasswordUserComponent;
  let fixture: ComponentFixture<ChangePasswordUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangePasswordUserComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangePasswordUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
