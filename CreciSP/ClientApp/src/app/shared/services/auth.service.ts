import { UserModel } from './../../users/models/user.model';
import { Router } from '@angular/router';
import { UserTypeEnum } from 'src/app/users/models/user-type-enum';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userLogged: boolean;
  userType: UserTypeEnum;

  loggedWasChanged: BehaviorSubject<boolean>;

  constructor(
    private route: Router
  ) {
    this.loggedWasChanged  = new BehaviorSubject<boolean>(this.userLogged);
   }

  userIsLogged(): boolean {
    if (!!this.userLogged) return this.userLogged;

    const user = JSON.parse(localStorage.getItem('user'));
    this.userLogged = !!user?.id;
    this.loggedWasChanged.next(this.userLogged);
    return this.userLogged;
  }

  login(user: any): void {
    localStorage.setItem('user', JSON.stringify(user));
  }

  userTypeInfo(): UserTypeEnum {
    if (!!this.userType) return this.userType;

    const user = JSON.parse(localStorage.getItem('user'));
    this.userType = user.type;
    return this.userType;
  }

  getUserLogged() {
    return JSON.parse(localStorage.getItem('user')) as UserModel;
  }

  logout(): void {
    localStorage.clear();
    this.userLogged = false;
    this.userType = null;
    this.userIsLogged();
    this.route.navigateByUrl('');
  }

}
