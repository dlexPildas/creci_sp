import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EquipmentModel } from '../../Models/equipment.model';
import { EquipmentService } from '../../Services/equipment.service';

@Component({
  selector: 'app-list-equipment',
  templateUrl: './list-equipment.component.html',
  styleUrls: ['./list-equipment.component.css']
})
export class ListEquipmentComponent implements OnInit {
  equipments: EquipmentModel[];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ListEquipmentComponent>,
    private equipmentService: EquipmentService,
  ) { }

  ngOnInit(): void {
    this.getEquipments();
  }

  getEquipments(): void {
    this.equipmentService.getEquipments(this.data.idRoom)
      .subscribe(result => this.equipments = result)
  }

}
