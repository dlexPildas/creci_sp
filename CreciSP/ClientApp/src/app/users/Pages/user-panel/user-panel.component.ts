import { UserListComponent } from './../../Components/user-list/user-list.component';
import { CreateUserComponent } from './../../Components/create-user/create-user.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { UserFilterModel } from '../../models/user-filter.model';

@Component({
  selector: 'app-user-panel',
  templateUrl: './user-panel.component.html',
  styleUrls: ['./user-panel.component.css']
})
export class UserPanelComponent implements OnInit {
  @ViewChild('userList') userListComponent: UserListComponent;

  constructor(
    public dialog: MatDialog
  ) {
  }

  ngOnInit(): void {
  }

  opeModalCreateUser(): void {
    this.dialog.open(CreateUserComponent)
      .afterClosed()
      .subscribe(result => {
        if (result) {
          this.userListComponent.getUsers();
        }
      });
  }

}
