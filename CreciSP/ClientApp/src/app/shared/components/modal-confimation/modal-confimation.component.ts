import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-modal-confimation',
  templateUrl: './modal-confimation.component.html',
  styleUrls: ['./modal-confimation.component.css']
})
export class ModalConfimationComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ModalConfimationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
  }

}
