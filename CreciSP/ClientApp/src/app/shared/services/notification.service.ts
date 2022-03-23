import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NoticationModel } from '../models/noticication.model';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private base_url = 'https://localhost:44389/lognotify';

  constructor(
    private http: HttpClient
  ) { }

  getNotificationByUserId(userId: string): Observable<NoticationModel[]> {
    return this.http.get<NoticationModel[]>(`${this.base_url}`, {
      params: {
        userId: userId
      }
    });
  }
}
