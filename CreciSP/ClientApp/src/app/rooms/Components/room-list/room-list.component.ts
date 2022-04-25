import { AlertService } from 'src/app/shared/services/alert.service';
import { ModalConfimationComponent } from './../../../shared/components/modal-confimation/modal-confimation.component';
import { RoomType } from './../../Models/room-type.model';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RoomFilterModel } from '../../Models/room-filter.model';
import { RoomModel } from '../../Models/room.model';
import { RoomService } from '../../Services/room.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { UserTypeEnum } from 'src/app/users/models/user-type-enum';
import { CreateEquipamentComponent } from '../create-equipament/create-equipament.component';
import { AuthService } from 'src/app/shared/services/auth.service';
import { LinkRoomEquipmentComponent } from '../link-room-equipment/link-room-equipment.component';
import { ListEquipmentComponent } from '../list-equipment/list-equipment.component';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {
  displayedColumns: string[] = ['number', 'floor', 'capacity', 'type', 'status', 'action'];
  dataSource: RoomModel[];
  filters: RoomFilterModel;
  roomType = RoomType;
  isAdm = false;

  constructor(
    private alertService: AlertService,
    public dialog: MatDialog,
    private roomService: RoomService,
    private authService: AuthService
  ) {
    this.filters = new RoomFilterModel();
  }

  ngOnInit(): void {
    this.isAdm = this.authService.userTypeInfo() === UserTypeEnum.Administrator

    this.getRooms();
  }

  getRooms(): void {
    this.roomService.getRooms(this.filters)
      .subscribe(rooms => this.dataSource = rooms)
  }

  activeRoom(idRoom: string): void {
    this.roomService.activeRoom(idRoom)
      .subscribe(
        () => {
          this.alertService.alertMessage('Sala ativada com sucesso');
          this.getRooms();
        },
        error => {
          this.alertService.alertMessage('Erro ao ativar sala', error);
        }
      );
  }

  inactiveRoom(idRoom: string): void {
    this.roomService.inactiveRoom(idRoom)
      .subscribe(
        () => {
          this.alertService.alertMessage('Sala inativada com sucesso');
          this.getRooms();
        },
        error => {
          this.alertService.alertMessage('Erro ao inativar sala', error);
        }
      );
  }

  canDeleteRoom(idRoom: string): void {
    this.dialog.open(ModalConfimationComponent, {
      width: '250px',
      data: { message: 'Deseja realmente excluir?' },
    })
      .afterClosed()
      .subscribe(
        result => {
          if (result) {
            this.removeRoom(idRoom)
          }
        });
  }

  removeRoom(idRoom: string): void {
    this.roomService.removeRoom(idRoom)
      .subscribe(
        () => {
          this.alertService.alertMessage('Sala excluída com sucesso');
          this.getRooms();
        },
        error => {
          this.alertService.alertMessage('Erro ao excluir sala', error);
        }
      );
  }

  createEquipament(): void {
    this.dialog.open(CreateEquipamentComponent)
      .afterClosed()
      .subscribe();
  }

  linkEquipamentToRoom(idRoom: string): void {
    this.dialog.open(LinkRoomEquipmentComponent, {
      width: '500px',
      data: {
        idRoom: idRoom
      }
    })
      .afterClosed()
      .subscribe();
  }

  showRoomEquipments(idRoom: string, numberRoom: number): void {
    this.dialog.open(ListEquipmentComponent, {
      width: '500px',
      data: {
        numberRoom: numberRoom,
        idRoom: idRoom
      }
    })
      .afterClosed()
      .subscribe();
  }
}
