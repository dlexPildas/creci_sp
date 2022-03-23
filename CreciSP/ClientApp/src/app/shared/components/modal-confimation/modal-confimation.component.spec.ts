import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalConfimationComponent } from './modal-confimation.component';

describe('ModalConfimationComponent', () => {
  let component: ModalConfimationComponent;
  let fixture: ComponentFixture<ModalConfimationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalConfimationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalConfimationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
