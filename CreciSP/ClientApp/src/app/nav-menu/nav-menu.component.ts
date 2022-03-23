import { AuthService } from './../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../shared/components/login/login.component';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLogged = false;


  constructor(
    public dialog: MatDialog,
    private authService: AuthService
  ) { }


  ngOnInit(): void {
    this.authService.loggedWasChanged
      .subscribe(value => this.isLogged = value)
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout(): void {
    this.authService.logout();
  }

  login(): void {
    this.dialog.open(LoginComponent)
      .afterClosed()
      .subscribe();
  }
}
