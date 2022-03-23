import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ModalConfimationComponent } from 'src/app/shared/components/modal-confimation/modal-confimation.component';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UserTypeEnum } from 'src/app/users/models/user-type-enum';
import { BoookingFilterModel } from '../../Models/booking-filter.model';
import { BookingModel } from '../../Models/booking.model';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.css']
})
export class BookingListComponent implements OnInit {
  displayedColumns: string[] = ['numberRoom', 'date', 'startTime', 'endTime', 'action'];
  dataSource: BookingModel[];
  filters: BoookingFilterModel;

  constructor(
    private bookingService: BookingService,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog,
    private authService: AuthService
  ) {
    this.filters = new BoookingFilterModel();
  }

  ngOnInit(): void {
    const user = this.authService.getUserLogged();

    if (user.type === UserTypeEnum.Common) {
      this.filters.userId = user.id;
    }

    this.getBookings();
  }

  getBookings(): void {
    this.bookingService.getBookings(this.filters)
      .subscribe(bookings => this.dataSource = bookings)
  }

  canDeleteBooking(idBooking: string): void {
    this.dialog.open(ModalConfimationComponent, {
      width: '250px',
      data: { message: 'Deseja realmente excluir?' },
    })
      .afterClosed()
      .subscribe(
        result => {
          if (result) {
            this.removeRoom(idBooking)
          }
        });
  }

  removeRoom(idBooking: string): void {
    this.bookingService.removeBooking(idBooking)
      .subscribe(
        () => {
          this._snackBar.open('Reserva excluída com sucesso', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
          this.getBookings();
        },
        error => {
          this._snackBar.open('Erro ao excluir reserva', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
        }
      );
  }

}
