import { Component, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { Solicitud } from 'src/app/models/Solicitud';
import { MatTable } from '@angular/material/table';

@Component({
  selector: 'app-solicitud-list',
  templateUrl: './solicitud-list.component.html',
  styleUrls: ['./solicitud-list.component.css']
})
export class SolicitudListComponent implements OnInit, OnChanges {

  @Input() public solicitudes: Solicitud[] = [];

  @ViewChild(MatTable) solicitudesTable!: MatTable<any>;

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

  ngOnChanges() {
    this.solicitudesTable.renderRows();
  }

  ngOnInit(): void {
  }

}
