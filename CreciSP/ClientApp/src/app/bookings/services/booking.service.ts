import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BoookingFilterModel } from '../Models/booking-filter.model';
import { BookingModel } from '../Models/booking.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private base_url = 'https://localhost:44389/booking';

  constructor(
    private http: HttpClient
  ) { }

  getBookings(filter: BoookingFilterModel): Observable<BookingModel[]> {
    return this.http.get<BookingModel[]>(`${this.base_url}`, {
      params: {
        date: filter?.date?.toString() ?? '',
        startTime: filter.startTime ?? '',
        endTime: filter.endTime ?? '',
        roomId: filter.roomId ?? '',
        userId: filter.userId ?? ''
      }
    });
  }

  saveBooking(booking: BookingModel): Observable<boolean> {
    return this.http.post<boolean>(`${this.base_url}`, booking);
  }

  removeBooking(id: string): Observable<boolean> {
    return this.http.delete<boolean>(`${this.base_url}/${id}`, {});
  }
}
