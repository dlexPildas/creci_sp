import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EquipmentModel } from '../Models/equipment.model';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  private base_url = 'https://localhost:44389/equipment';

  constructor(
    private http: HttpClient
  ) { }

  saveEquipment(equipment: EquipmentModel): Observable<boolean> {
    return this.http.post<boolean>(`${this.base_url}`, equipment);
  }

  getEquipments(): Observable<EquipmentModel[]> {
    return this.http.get<EquipmentModel[]>(`${this.base_url}`);
  }

  linkToRoom(idRoom: string, equipmentId: string) {
    return this.http.put<boolean>(`${this.base_url}/${equipmentId}/link-room-equipment?roomId=${idRoom}`, {});
  }
}
