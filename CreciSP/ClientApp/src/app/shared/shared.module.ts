import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatBadgeModule} from '@angular/material/badge';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalConfimationComponent } from './components/modal-confimation/modal-confimation.component';
import { MatNativeDateModule } from '@angular/material/core';
import { LoginComponent } from './components/login/login.component';
import { NotificationComponent } from './components/notification/notification.component';

@NgModule({
  declarations: [
    ModalConfimationComponent,
    LoginComponent,
    NotificationComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatDialogModule,
    MatSelectModule,
    MatSnackBarModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatBadgeModule,
    FormsModule,

    ReactiveFormsModule,
  ],
  exports: [
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatDialogModule,
    MatSelectModule,
    MatSnackBarModule,
    MatDatepickerModule,
    MatBadgeModule,

    NotificationComponent,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    MatNativeDateModule
  ]
})
export class SharedModule { }
