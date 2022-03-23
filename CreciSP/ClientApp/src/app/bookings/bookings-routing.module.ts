import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from '../shared/guards/can-activate.guard';
import { BookingPanelComponent } from './pages/booking-panel/booking-panel.component';

const routes: Routes = [{ path: '', component: BookingPanelComponent, canActivate: [AuthGuardService] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingsRoutingModule { }
