import { Component, OnInit } from '@angular/core';
import { ImportedSolicitudesRawData } from '../models/ImportedSolicitudesRawData';
import { SpreadsheetToJsonService } from '../services/spreadsheet-to-json.service';

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
  isTableVisible = false;
  // public columns: string[] = ['folio', 'modalidad'];

  constructor(private sptojsonservice: SpreadsheetToJsonService) { }

  ngOnInit(): void {
    this.rawData = undefined;
  }

  addFile(event: any) {
    this.rawData = undefined;
    this.file = event.target.files[0];
    this.sptojsonservice.transform(this.file).subscribe(rawData => {
      this.rawData = rawData;
    });
  }

  showRawData() {
    this.isTableVisible = true;
    console.log(this.rawData);
    this.headers = this.rawData!['headers'];
    this.data = this.rawData!['data'];
  }

}
