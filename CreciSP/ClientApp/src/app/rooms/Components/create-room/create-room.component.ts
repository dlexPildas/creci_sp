import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AlertService } from 'src/app/shared/services/alert.service';
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
    private alertService: AlertService,
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
          this.alertService.alertMessage('Sala criada com sucesso!')
          this.dialogRef.close(true);
        },
        error => this.alertService.alertMessage('Erro ao criar sala', error)
      )
  }
}
