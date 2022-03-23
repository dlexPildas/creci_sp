import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LinkRoomEquipmentComponent } from './link-room-equipment.component';

describe('LinkRoomEquipmentComponent', () => {
  let component: LinkRoomEquipmentComponent;
  let fixture: ComponentFixture<LinkRoomEquipmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LinkRoomEquipmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LinkRoomEquipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
