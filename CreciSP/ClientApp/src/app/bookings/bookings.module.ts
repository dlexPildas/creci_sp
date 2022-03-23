import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BookingsRoutingModule } from './bookings-routing.module';
import { BookingPanelComponent } from './pages/booking-panel/booking-panel.component';
import { BookingListComponent } from './components/booking-list/booking-list.component';
import { CreateBookingComponent } from './components/create-booking/create-booking.component';
import { SharedModule } from '../shared/shared.module';
import { NgxMaskModule } from 'ngx-mask';


@NgModule({
  declarations: [
    BookingPanelComponent,
    BookingListComponent,
    CreateBookingComponent
  ],
  imports: [
    CommonModule,
    BookingsRoutingModule,
    SharedModule,
    NgxMaskModule.forRoot(),
  ]
})
export class BookingsModule { }
