import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlertService } from 'src/app/shared/services/alert.service';
import { UserChangePassword } from '../../models/user-change-password.model';
import { UserService } from '../../Services/user.service';

@Component({
  selector: 'app-change-password-user',
  templateUrl: './change-password-user.component.html',
  styleUrls: ['./change-password-user.component.css']
})
export class ChangePasswordUserComponent implements OnInit {
  idUser: string;

  currentPassword: string;
  newPassword: string;
  confirmNewPassword: string;

  constructor(
    public dialogRef: MatDialogRef<ChangePasswordUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private alertService: AlertService,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.idUser = this.data?.idUser;
  }

  save(): void {
    if (this.newPassword !== this.confirmNewPassword) return this.alertService.alertMessage('As senhas devem ser iguais');

    const user = {
      id: this.idUser,
      password: this.currentPassword,
      newPassword: this.newPassword
    } as UserChangePassword;

    this.userService.changePassword(user)
      .subscribe(
        () => {
          this.alertService.alertMessage('Senha alterada com sucesso!')
          this.dialogRef.close(true);
        },
        error => this.alertService.alertMessage('Erro ao alterar a senha', error)
      )

  }

}
