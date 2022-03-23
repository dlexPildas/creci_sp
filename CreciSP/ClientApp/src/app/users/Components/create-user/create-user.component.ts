import { UserTypeEnum } from './../../models/user-type-enum';
import { UserService } from './../../Services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  userForm: FormGroup;
  userTypeEnum = UserTypeEnum;

  constructor(
    private formBuilder: FormBuilder,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<CreateUserComponent>,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void {
    this.userForm = this.formBuilder.group({
      name: ['', Validators.required],
      cpf: ['', Validators.required],
      email: ['', Validators.email],
      confirmEmail: ['', Validators.email],
      type: ['', Validators.required],
      status: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  save(): void {
    const values = this.userForm.value;

    if (values.password !== values.confirmPassword) return this.alertMessage('As senhas devem ser iguais');

    if (values.email !== values.confirmEmail) return this.alertMessage('Os emails devem ser iguais');

    const newUser = {

    }
    this.userService.saveUser(values)
      .subscribe(
        () => {
          this.alertMessage('Usuário criado com sucesso!')
          this.dialogRef.close();
        },
        () => this.alertMessage('Erro ao criar um usuário')
      )
  }

  alertMessage(message: string): void {
    this._snackBar.open(message, 'Fechar', {
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      duration: 5000,
    });
  }

}
