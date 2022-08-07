import { Component, Input, OnInit } from '@angular/core';
import { Solicitud } from 'src/app/models/Solicitud';

@Component({
  selector: 'app-solicitud',
  templateUrl: './solicitud.component.html',
  styleUrls: ['./solicitud.component.css']
})
export class SolicitudComponent implements OnInit {

  @Input() solicitud!: Solicitud;

  constructor() { }

  ngOnInit(): void { }

  splitName(fullName: string): string[] {
    return fullName.split(" ");
  }

  getAge(rfc: string): string {
    const regex = /[0-9]/g;
    const rfcNumbers = rfc.match(regex);
    const year = rfcNumbers![0] + rfcNumbers![1];
    if (parseInt(year) < 22)
      console.log(year);

    return year;
  }

}
