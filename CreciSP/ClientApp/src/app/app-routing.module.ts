import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule) },
  { path: 'rooms', loadChildren: () => import('./rooms/rooms.module').then(m => m.RoomsModule) },
  { path: 'bookings', loadChildren: () => import('./bookings/bookings.module').then(m => m.BookingsModule) },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
