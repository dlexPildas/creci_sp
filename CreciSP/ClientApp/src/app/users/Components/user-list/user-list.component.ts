import { UserModel } from './../../models/user.model';
import { Component, OnInit } from '@angular/core';
import { UserTypeEnum } from '../../models/user-type-enum';
import { UserService } from '../../Services/user.service';
import { UserFilterModel } from '../../models/user-filter.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'cpf', 'email', 'status', 'action'];
  dataSource: UserModel[];

  filters: UserFilterModel;

  constructor(
    private userService: UserService,
    private _snackBar: MatSnackBar,
  ) {
    this.filters = new UserFilterModel();
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.userService.getUsers(this.filters)
      .subscribe(users => this.dataSource = users)
  }

  activeUser(idUser: string): void {
    this.userService.activeUser(idUser)
      .subscribe(
        () => {
          this._snackBar.open('Usuário ativado com sucesso', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
          this.getUsers();
        },
        error => {
          this._snackBar.open('Erro ao ativar um usuário', 'Splash', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
        }
      );
  }

  inactiveUser(idUser: string): void {
    this.userService.inactiveUser(idUser)
      .subscribe(
        () => {
          this._snackBar.open('Usuário inativado com sucesso', 'Fechar', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
          this.getUsers();
        },
        error => {
          this._snackBar.open('Erro ao inativar um usuário', 'Splash', {
            horizontalPosition: 'end',
            verticalPosition: 'bottom',
            duration: 5000,
          });
        }
      );
  }

}
