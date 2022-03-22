import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserPanelComponent } from './Pages/user-panel/user-panel.component';

const routes: Routes = [{ path: '', component: UserPanelComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
