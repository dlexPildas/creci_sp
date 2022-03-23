import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingPanelComponent } from './pages/booking-panel/booking-panel.component';

const routes: Routes = [{ path: '', component: BookingPanelComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BookingsRoutingModule { }
