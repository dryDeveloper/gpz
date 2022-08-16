import { Component, OnInit } from '@angular/core';
import { ImportedSolicitudesRawData } from '../models/ImportedSolicitudesRawData';
import { SolicitudesService } from '../services/solicitudes.service';
import { SpreadsheetToJsonService } from '../services/spreadsheet-to-json.service';
import { Solicitud } from '../models/Solicitud';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { WarningAlertComponent } from '../shared/warning-alert/warning-alert.component';

@Component({
  selector: 'app-import-data',
  templateUrl: './import-data.component.html',
  styleUrls: ['./import-data.component.css']
})
export class ImportDataComponent implements OnInit {

  rawData?: ImportedSolicitudesRawData;
  file!: File;
  headers!: any[];
  data!: any[];
  loading = false;

  constructor(
    private sptojsonservice: SpreadsheetToJsonService,
    private solicitudService: SolicitudesService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.rawData = undefined;
  }

  addFile(event: any) {
    this.loading = true;
    this.rawData = undefined;

    if (event.target.files[0]) this.file = event.target.files[0];
    else { this.loading = false; return; }

    this.sptojsonservice.transform(this.file).subscribe(rawData => {
      this.rawData = rawData;
      this.loading = false;
      this.showRawData();
      this.importData();
    });
  }

  showRawData() {
    this.headers = this.rawData!['headers'];
    this.data = this.rawData!['data'];
  }

  async importData() {
    this.loading = true;
    const solicitudesToInsert = this.data.map(rawSolicitud => {
      const processedSolicitud: Solicitud = {
        cp: rawSolicitud['CP'],
        calle: rawSolicitud['Calle'],
        ciudad: rawSolicitud['Ciudad'],
        colonia: rawSolicitud['Colonia'],
        estado: rawSolicitud['Estado'],
        fCaptura: rawSolicitud['F.Captura'],
        folio: rawSolicitud['Folio'].toString(),
        modalidad: rawSolicitud['Modalidad'],
        municipio: rawSolicitud['Municipio'],
        noInterior: rawSolicitud['No. Interior'],
        noExterior: rawSolicitud['No. Exterior'],
        nombreCompleto: rawSolicitud['Nombre Completo'],
        numeroAsignado: rawSolicitud['Número asignado'],
        rfc: rawSolicitud['RFC'],
        refNom1: rawSolicitud['Ref. Nom. 1'],
        refNom2: rawSolicitud['Ref. Nom. 2'],
        refNom3: rawSolicitud['Ref. Nom. 3'],
        tTramite: rawSolicitud['T.Trámite'],
        telefono: rawSolicitud['Teléfono'],
        telefonoNom20: rawSolicitud['Teléfono Nom. 20'],
        telefonoRep: rawSolicitud['Teléfono Rep.'],
        repPaterno: rawSolicitud['Rep. Paterno'],
        urgente: rawSolicitud['Urgente'],
        fechaAsignacion: rawSolicitud['fechaAsignacion'],
        fechaVigencia: rawSolicitud['fechaVigencia'],
        fechaContestado: rawSolicitud['fechaContestado'],
        refTel: rawSolicitud['refTel'],
        refTel2: rawSolicitud['refTel2'],
        refTel3: rawSolicitud['refTel3'],
        tipoPersona: rawSolicitud['Tipo Persona'],
        tipoProyecto: rawSolicitud['Tipo Proyecto'],
        obsFV: rawSolicitud['obsFV'],
        obsTelcel: rawSolicitud['obsTelcel'],
        entrecalle: rawSolicitud['Entre calle'],
      };
      this.loading = false;
      return processedSolicitud;
    });


    this.solicitudService.bulkInsertSolicitudes(solicitudesToInsert).subscribe(response => {

      this.loading = true;

      if (response.success == 0) this.loading = false;

      if (response.success == 3) {
        const dialogRef = this.dialog.open(WarningAlertComponent, {
          width: '250px',
          data: { message: response.message }
        });
      } else {
        this.snackBar.open(`${response.message}`, 'dismiss', { duration: 8000 });
      }

      this.loading = false;

    });
  }

}
