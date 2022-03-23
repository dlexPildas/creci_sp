import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UserTypeEnum } from 'src/app/users/models/user-type-enum';
import { CreateRoomComponent } from '../../components/create-room/create-room.component';
import { RoomListComponent } from '../../components/room-list/room-list.component';

@Component({
  selector: 'app-room-panel',
  templateUrl: './room-panel.component.html',
  styleUrls: ['./room-panel.component.css']
})
export class RoomPanelComponent implements OnInit {
  @ViewChild('roomList') roomListComponent: RoomListComponent;

  isAdm = false;

  constructor(
    public dialog: MatDialog,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.isAdm = this.authService.userTypeInfo() === UserTypeEnum.Administrator;
  }

  openModalCreateRoom(): void {
    this.dialog.open(CreateRoomComponent)
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.roomListComponent.getRooms();
        }
      });
  }

}
