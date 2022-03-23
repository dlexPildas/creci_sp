import { RoomFilterModel } from './../../../rooms/Models/room-filter.model';
import { RoomService } from './../../../rooms/Services/room.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RoomModel } from 'src/app/rooms/Models/room.model';
import { BookingService } from '../../services/booking.service';
import { AlertService } from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-create-booking',
  templateUrl: './create-booking.component.html',
  styleUrls: ['./create-booking.component.css']
})
export class CreateBookingComponent implements OnInit {
  bookingForm: FormGroup;
  rooms: RoomModel[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<CreateBookingComponent>,
    private bookingService: BookingService,
    private roomService: RoomService
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.getRooms();
  }

  createForm(): void {
    this.bookingForm = this.formBuilder.group({
      date: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
      userId: ['e9b179ee-528f-47ef-bb7c-08da0c3c92b1'],
      roomId: ['', Validators.required],
    });
  }

  getRooms(): void {
    this.roomService.getRooms({ status: true } as RoomFilterModel)
      .subscribe(rooms => this.rooms = rooms);
  }

  save(): void {
    const values = this.bookingForm.value;

    values.startTime = `${values.startTime.slice(0,2)}:${values.startTime.slice(-2)}`
    values.endTime = `${values.endTime.slice(0,2)}:${values.endTime.slice(-2)}`

    this.bookingService.saveBooking(values)
      .subscribe(
        () => {
          this.alertService.alertMessage('Reserva criada com sucesso!')
          this.dialogRef.close(true);
        },
        () => this.alertService.alertMessage('Erro ao criar reserva')
      )
  }
}
