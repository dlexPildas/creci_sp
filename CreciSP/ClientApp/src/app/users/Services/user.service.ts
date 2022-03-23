import { UserFilterModel } from './../models/user-filter.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

import { UserModel } from './../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private base_url = 'https://localhost:44389/user';

  constructor(
    private http: HttpClient
  ) { }

  getUsers(filter: UserFilterModel): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(`${this.base_url}`, {
      params: {
        name: filter.name ?? '',
        cpf: filter.cpf ?? '',
        email: filter.email ?? '',
        type: filter.type ?? '',
        status: filter.status ?? '',
      }
    });
  }

  saveUser(user: UserModel ): Observable<boolean> {
    return this.http.post<boolean>(`${this.base_url}`, user);
  }

  activeUser(id: string): Observable<boolean> {
    return this.http.put<boolean>(`${this.base_url}/${id}/active`, {});
  }

  inactiveUser(id: string ): Observable<boolean> {
    return this.http.put<boolean>(`${this.base_url}/${id}/inactive`, {});
  }
}
