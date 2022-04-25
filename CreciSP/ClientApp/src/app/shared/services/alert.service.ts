import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(
    private _snackBar: MatSnackBar,
  ) { }

  alertMessage(message: string, error: any = null): void {
    if (error?.error?.errors?.Domain) {
      error?.error?.errors?.Domain.map(x => {
        this._snackBar.open(x, 'Fechar', {
          horizontalPosition: 'end',
          verticalPosition: 'bottom',
          duration: 5000,
        });
      });
    } else {
      this._snackBar.open(message, 'Fechar', {
        horizontalPosition: 'end',
        verticalPosition: 'bottom',
        duration: 5000,
      });
    }


  }
}
