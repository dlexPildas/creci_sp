import { CreateEquipamentComponent } from './../create-equipament/create-equipament.component';
import { ModalConfimationComponent } from './../../../shared/components/modal-confimation/modal-confimation.component';
import { RoomType } from './../../Models/room-type.model';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RoomFilterModel } from '../../Models/room-filter.model';
import { RoomModel } from '../../Models/room.model';
import { RoomService } from '../../Services/room.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UserTypeEnum } from 'src/app/users/models/user-type-enum';

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
    private _snackBar: MatSnackBar,
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
          this._snackBar.open('Sala ativada com sucesso', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
          this.getRooms();
        },
        error => {
          this._snackBar.open('Erro ao ativar sala', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
        }
      );
  }

  inactiveRoom(idRoom: string): void {
    this.roomService.inactiveRoom(idRoom)
      .subscribe(
        () => {
          this._snackBar.open('Sala inativada com sucesso', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
          this.getRooms();
        },
        error => {
          this._snackBar.open('Erro ao inativar sala', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
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
          this._snackBar.open('Sala excluída com sucesso', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
          this.getRooms();
        },
        error => {
          this._snackBar.open('Erro ao excluir sala', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
        }
      );
  }

  createEquipament(): void {
    this.dialog.open(CreateEquipamentComponent)
      .afterClosed()
      .subscribe();
  }
}
