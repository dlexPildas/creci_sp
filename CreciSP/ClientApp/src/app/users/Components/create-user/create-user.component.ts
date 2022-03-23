import { UserTypeEnum } from './../../models/user-type-enum';
import { UserService } from './../../Services/user.service';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  userForm: FormGroup;
  userTypeEnum = UserTypeEnum;
  idUser: string;

  constructor(
    private formBuilder: FormBuilder,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<CreateUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private userService: UserService
  ) { }

  ngOnInit(): void {
    this.idUser = this.data?.idUser;

    if (this.idUser) {
      this.getUserById();
    }

    this.createForm();
  }

  getUserById(): void {
    this.userService.getUserById(this.idUser)
      .subscribe(user => {
        this.userForm.setValue({
          name: user.name,
          cpf: user.cpf,
          email: user.email,
          confirmEmail: user.email,
          type: user.type,
          status: user.status,
          password: user.password,
          confirmPassword: user.password,
        })
      });
  }

  createForm(): void {
    this.userForm = this.formBuilder.group({
      name: ['', Validators.required],
      cpf: [{ value: '', disabled: !!this.idUser }, Validators.required],
      email: ['', Validators.email],
      confirmEmail: ['', Validators.email],
      type: ['', Validators.required],
      status: ['', Validators.required],
      password: [{ value: '', disabled: !!this.idUser }, Validators.required],
      confirmPassword: [{ value: '', disabled: !!this.idUser }, Validators.required],
    });
  }

  save(): void {
    const values = this.userForm.value;

    if (values.password !== values.confirmPassword) return this.alertMessage('As senhas devem ser iguais');

    if (values.email !== values.confirmEmail) return this.alertMessage('Os emails devem ser iguais');

    if (this.idUser) values.id = this.idUser;

    this.userService.saveUser(values)
      .subscribe(
        () => {
          this.alertMessage('Operação realizada com sucesso!')
          this.dialogRef.close(true);
        },
        () => this.alertMessage('Erro ao realizar operação')
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
