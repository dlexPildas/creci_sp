import { AlertService } from 'src/app/shared/services/alert.service';
import { UserModel } from './../../models/user.model';
import { Component, OnInit } from '@angular/core';
import { UserTypeEnum } from '../../models/user-type-enum';
import { UserService } from '../../Services/user.service';
import { UserFilterModel } from '../../models/user-filter.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { CreateUserComponent } from '../create-user/create-user.component';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'cpf', 'email', 'status', 'action'];
  dataSource: UserModel[];
  isAdm = false;
  currentUser: UserModel;
  filters: UserFilterModel;
  userTypeEnum = UserTypeEnum;

  constructor(
    private userService: UserService,
    private _snackBar: MatSnackBar,
    public alertService: AlertService,
    public dialog: MatDialog,
    private authService: AuthService
  ) {
    this.filters = new UserFilterModel();
  }

  ngOnInit(): void {
    this.currentUser = this.authService.getUserLogged();
    this.isAdm = this.currentUser.type === UserTypeEnum.Administrator

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
          this.alertService.alertMessage('Usuário ativado com sucesso');
          this.getUsers();
        },
        error => {
          this.alertService.alertMessage('Erro ao ativar um usuário');
        }
      );
  }

  inactiveUser(idUser: string): void {
    this.userService.inactiveUser(idUser)
      .subscribe(
        () => {
          this.alertService.alertMessage('Usuário inativado com sucesso');
          this.getUsers();
        },
        error => {
          this.alertService.alertMessage('Erro ao inativar um usuário');
        }
      );
  }

  editUser(idUser: string): void {
    this.dialog.open(CreateUserComponent, {
      data: { idUser }
    })
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.getUsers();
        }
      });
  }

}
