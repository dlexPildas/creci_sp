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

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalConfimationComponent } from './components/modal-confimation/modal-confimation.component';

@NgModule({
  declarations: [
    ModalConfimationComponent
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

    FormsModule,
    ReactiveFormsModule,
  ]
})
export class SharedModule { }
