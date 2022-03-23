import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(
    private _snackBar: MatSnackBar,
  ) { }

  alertMessage(message: string): void {
    this._snackBar.open(message, 'Fechar', {
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      duration: 5000,
    });
  }
}
