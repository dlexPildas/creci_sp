import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(
    private http: HttpClient
  ) {
  }


  ngOnInit(): void {
    this.http.get('').subscribe();
  }


}

