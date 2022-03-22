import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { UsersRoutingModule } from './users-routing.module';
import { UserPanelComponent } from './pages/user-panel/user-panel.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { NgxMaskModule } from 'ngx-mask';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    UserPanelComponent,
    UserListComponent,
    CreateUserComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    UsersRoutingModule,
    SharedModule,
    NgxMaskModule.forRoot(),
  ]
})
export class UsersModule { }
