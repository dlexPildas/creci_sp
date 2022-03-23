import { EquipmentModel } from './../../Models/equipment.model';
import { EquipmentService } from './../../Services/equipment.service';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AlertService } from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-link-room-equipment',
  templateUrl: './link-room-equipment.component.html',
  styleUrls: ['./link-room-equipment.component.css']
})
export class LinkRoomEquipmentComponent implements OnInit {
  equipmentId: string;
  equipments: EquipmentModel[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<LinkRoomEquipmentComponent>,
    private equipmentService: EquipmentService,
    private alertService: AlertService,
  ) { }

  ngOnInit(): void {
    this.getEquipments();
  }

  getEquipments(): void {
    this.equipmentService.getEquipments()
      .subscribe(result => this.equipments = result)
  }

  save(): void {
    this.equipmentService.linkToRoom(this.data.idRoom, this.equipmentId)
      .subscribe(
        () => {
          this.alertService.alertMessage('Vículo realizado com sucesso!')
          this.dialogRef.close(true);
        },
        () => this.alertService.alertMessage('Erro ao vincular equipamento')
      )
  }

}
