import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserTypeEnum } from 'src/app/users/models/user-type-enum';
import { RoomType } from '../../Models/room-type.model';
import { RoomService } from '../../Services/room.service';

@Component({
  selector: 'app-create-room',
  templateUrl: './create-room.component.html',
  styleUrls: ['./create-room.component.css']
})
export class CreateRoomComponent implements OnInit {
  roomForm: FormGroup;
  roomType = RoomType;

  constructor(
    private formBuilder: FormBuilder,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<CreateRoomComponent>,
    private roomService: RoomService
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void {
    this.roomForm = this.formBuilder.group({
      number: ['', Validators.required],
      floor: ['', Validators.required],
      capacity: ['', Validators.required],
      type: ['', Validators.required],
    });
  }

  save(): void {
    const values = this.roomForm.value;

    this.roomService.saveRoom(values)
      .subscribe(
        () => {
          this.alertMessage('Sala criada com sucesso!')
          this.dialogRef.close(true);
        },
        () => this.alertMessage('Erro ao criar uma sala')
      )
  }

  alertMessage(message: string): void {
    this._snackBar.open(message, 'Fechar', {
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      duration: 5000,
    });
  }

}
