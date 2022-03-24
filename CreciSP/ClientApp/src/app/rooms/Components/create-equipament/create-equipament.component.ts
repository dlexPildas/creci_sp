import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AlertService } from 'src/app/shared/services/alert.service';
import { EquipmentType } from '../../Models/equipment-type.model';
import { EquipmentService } from '../../Services/equipment.service';

@Component({
  selector: 'app-create-equipament',
  templateUrl: './create-equipament.component.html',
  styleUrls: ['./create-equipament.component.css']
})
export class CreateEquipamentComponent implements OnInit {

  equipamentForm: FormGroup;
  equipamentType = EquipmentType;

  constructor(
    private formBuilder: FormBuilder,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<CreateEquipamentComponent>,
    private equipmentService: EquipmentService
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(): void {
    this.equipamentForm = this.formBuilder.group({
      number: ['', Validators.required],
      type: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  save(): void {
    const values = this.equipamentForm.value;

    this.equipmentService.saveEquipment(values)
      .subscribe(
        () => {
          this.alertService.alertMessage('Equipamento criado com sucesso!')
          this.dialogRef.close(true);
        },
        error => this.alertService.alertMessage('Erro ao criar equipamento', error)
      )
  }

}
