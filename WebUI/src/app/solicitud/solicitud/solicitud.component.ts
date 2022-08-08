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

  getAge(rfc: string): number {
    const regex = /[0-9]/g;
    const rfcNumbers = rfc.match(regex);
    let rfcYear = parseInt(rfcNumbers![0] + rfcNumbers![1]);
    let currentYear = parseInt(new Date().getFullYear().toString().slice(-2));
    
    if (rfcYear > currentYear) rfcYear = rfcYear + 1900; 
    else rfcYear = rfcYear + 2000;

    currentYear = new Date().getFullYear();

    return currentYear - rfcYear;
  }

}
