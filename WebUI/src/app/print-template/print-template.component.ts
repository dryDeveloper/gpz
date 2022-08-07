import { Component, OnInit } from '@angular/core';
import { Solicitud } from '../models/Solicitud';
import { SolicitudesService } from '../services/solicitudes.service';

@Component({
  selector: 'app-print-template',
  templateUrl: './print-template.component.html',
  styleUrls: ['./print-template.component.css']
})
export class PrintTemplateComponent implements OnInit {

  public solicitudes: Solicitud[] = [];

  constructor(private solicitudService: SolicitudesService) { }

  ngOnInit(): void {
    this.getSolicitudes("19-02-2022");
  }

  getSolicitudes(day: string) {
    this.solicitudService.getSolicitudes(day).subscribe(response => {
      this.solicitudes = response.data;
      console.log(this.solicitudes);
    });
  }

  printSolicitudes() {
    var printwin = window.open("");
    printwin!.document.write(document.getElementById("printTarget")!.innerHTML);
    // printwin?.print();
  }

}
