import { AuthService } from './shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from './shared/components/login/login.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';


  constructor(
    public dialog: MatDialog,
    private authService: AuthService
  ) {
  }

  ngOnInit(): void {
    if (!this.authService.userIsLogged()) {
      this.openModalLogin();
    }
  }

  openModalLogin(): void {
    this.dialog.open(LoginComponent)
      .afterClosed()
      .subscribe();
  }
}
