import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Solicitud } from '../models/Solicitud';
import { SolicitudesService } from '../services/solicitudes.service';
import { WarningAlertComponent } from '../shared/warning-alert/warning-alert.component';

@Component({
  selector: 'app-print-template',
  templateUrl: './print-template.component.html',
  styleUrls: ['./print-template.component.css'],
})
export class PrintTemplateComponent implements OnInit {

  public solicitudes: Solicitud[] = [];
  public filteredSolicitudes: Solicitud[] = [];
  public dayOfCapture: any;
  public enablePrint: boolean = false;
  public searchTerm: string = "";
  public loading = false;

  constructor(
    private solicitudService: SolicitudesService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {}

  solicitudFilter() {
    console.log(this.searchTerm);
    this.filteredSolicitudes = this.solicitudes
      .filter(s => 
        s.folio.includes(this.searchTerm) || 
        s.rfc.toUpperCase().includes(this.searchTerm.toUpperCase()) ||
        s.nombreCompleto.toUpperCase().includes(this.searchTerm.toUpperCase()) || 
        s.tipoPersona.toUpperCase().includes(this.searchTerm.toUpperCase()) ||
        s.tipoProyecto.toUpperCase().includes(this.searchTerm.toUpperCase()) ||
        s.modalidad.toUpperCase().includes(this.searchTerm.toUpperCase()) ||
        s.tTramite.toUpperCase().includes(this.searchTerm.toUpperCase())
      );
  }

  generateTemplate(): void {
    const shortDate = Intl.DateTimeFormat("en-GB", { dateStyle: "short" });
    const selectedDay = shortDate.format(this.dayOfCapture).replace(/\//g, '-'); 
    this.getSolicitudes(selectedDay!);
  }

  getSolicitudes(day: string) {
    this.loading = true;
    this.solicitudService.getSolicitudes(day).subscribe(response => {
      this.solicitudes = response.data as Solicitud[];
      this.filteredSolicitudes = this.solicitudes;
      this.loading = false;
    });
  }

  printSolicitudes() {
    if (document.getElementById("printTarget")) {
      var printwin = window.open("");
      printwin!.document.write(document.getElementById("printTarget")!.innerHTML);
    } else { 
        const dialogRef = this.dialog.open(WarningAlertComponent, {
          width: '250px',
          data: { message: "Porfavor seleccione la pestana 'para impresion' antes de intentar imprimir" }
        });
      return;
    }
  }

}
