import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BookingListComponent } from '../../components/booking-list/booking-list.component';
import { CreateBookingComponent } from '../../components/create-booking/create-booking.component';
import { BookingModel } from '../../Models/booking.model';

@Component({
  selector: 'app-booking-panel',
  templateUrl: './booking-panel.component.html',
  styleUrls: ['./booking-panel.component.css']
})
export class BookingPanelComponent implements OnInit {
  @ViewChild('bookingList') bookingListComponent: BookingListComponent;

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  openModalCreateBooking(): void {
    this.dialog.open(CreateBookingComponent)
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.bookingListComponent.getBookings();
        }
      });
  }
}
