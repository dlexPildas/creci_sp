import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoomsRoutingModule } from './rooms-routing.module';
import { SharedModule } from '../shared/shared.module';
import { RoomPanelComponent } from './pages/room-panel/room-panel.component';
import { RoomListComponent } from './components/room-list/room-list.component';
import { CreateRoomComponent } from './components/create-room/create-room.component';
import { NgxMaskModule } from 'ngx-mask';
import { CreateEquipamentComponent } from './components/create-equipament/create-equipament.component';


@NgModule({
  declarations: [
    RoomPanelComponent,
    RoomListComponent,
    CreateRoomComponent,
    CreateEquipamentComponent,
  ],
  imports: [
    CommonModule,
    RoomsRoutingModule,
    SharedModule,
    NgxMaskModule.forRoot(),
  ]
})
export class RoomsModule { }
