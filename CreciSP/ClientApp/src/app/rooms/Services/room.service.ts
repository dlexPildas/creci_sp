import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoomFilterModel } from '../Models/room-filter.model';
import { RoomType } from '../Models/room-type.model';
import { RoomModel } from '../Models/room.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  private base_url = 'https://localhost:44389/room';

  constructor(
    private http: HttpClient
  ) { }

  getRooms(filter: RoomFilterModel): Observable<RoomModel[]> {
    return this.http.get<RoomModel[]>(`${this.base_url}`, {
      params: {
        number: filter.number ?? '',
        floor: filter.floor ?? '',
        capacity: filter.capacity ?? '',
        type: filter.type === RoomType.Todos ? '' : filter.type ?? '',
        status: filter.status ?? '',
      }
    });
  }

  saveRoom(room: RoomModel): Observable<boolean> {
    return this.http.post<boolean>(`${this.base_url}`, room);
  }

  activeRoom(id: string): Observable<boolean> {
    return this.http.put<boolean>(`${this.base_url}/${id}/active`, {});
  }

  inactiveRoom(id: string ): Observable<boolean> {
    return this.http.put<boolean>(`${this.base_url}/${id}/inactive`, {});
  }

  removeRoom(id: string ): Observable<boolean> {
    return this.http.delete<boolean>(`${this.base_url}/${id}`, {});
  }
}
