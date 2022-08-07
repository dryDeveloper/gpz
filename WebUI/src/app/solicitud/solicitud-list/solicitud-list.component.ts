import { Component, Input, OnInit } from '@angular/core';
import { Solicitud } from 'src/app/models/Solicitud';

@Component({
  selector: 'app-solicitud-list',
  templateUrl: './solicitud-list.component.html',
  styleUrls: ['./solicitud-list.component.css']
})
export class SolicitudListComponent implements OnInit {

  @Input() public solicitudes: Solicitud[] = [];

  public columns = [
    "folio",
    "tipoPersona",
    "tipoProyecto",
    "fCaptura",
    "modalidad",
    "nombreCompleto",
    "rfc",
    "tTramite"
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
