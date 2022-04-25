import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from '../shared/guards/can-activate.guard';

import { UserPanelComponent } from './Pages/user-panel/user-panel.component';

const routes: Routes = [
  {
    path: '',
    component: UserPanelComponent,
    canActivate: [AuthGuardService]
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
