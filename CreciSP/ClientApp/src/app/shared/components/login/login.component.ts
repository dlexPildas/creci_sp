import { AlertService } from 'src/app/shared/services/alert.service';
import { Router } from '@angular/router';
import { UserFilterModel } from './../../../users/models/user-filter.model';
import { UserService } from './../../../users/Services/user.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string;
  password: string;

  constructor(
    private router: Router,
    public dialogRef: MatDialogRef<LoginComponent>,
    private userService: UserService,
    private authService: AuthService,
    private alertService: AlertService
  ) { }

  ngOnInit(): void {
  }

  login(): void {
    if (!this.password) return this.alertService.alertMessage('Informe a senha!');
    if (!this.email) return this.alertService.alertMessage('Informe a senha!');

    this.userService.getUsers({ email: this.email, password: this.password } as UserFilterModel)
      .subscribe(user => {
        if (user.length > 0) {
          this.authService.login(user[0]);
          this.router.navigateByUrl('users');
          this.dialogRef.close()
        }
      })
  }



}
