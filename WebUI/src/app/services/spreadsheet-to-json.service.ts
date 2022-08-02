import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import * as XLSX from 'xlsx';
import { ImportedSolicitudesRawData } from '../models/ImportedSolicitudesRawData'

@Injectable({
  providedIn: 'root'
})
export class SpreadsheetToJsonService {
  arrayBuffer: any;
  filelist: any[] = [];
  headers: any[] = [];
  contents: any[] = [];

  constructor() { }

  transform(file: File): Observable<ImportedSolicitudesRawData> {
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(file);
    return new Observable(subscriber => {
      fileReader.onloadend = (e) => {
        this.arrayBuffer = fileReader.result;
        var data = new Uint8Array(this.arrayBuffer);
        var arr = new Array();
        for(var i = 0; i != data.length; ++i) arr[i] = String.fromCharCode(data[i]);
        var bstr = arr.join("");
        var workbook = XLSX.read(bstr, { type: "binary" });
        var first_sheet_name = workbook.SheetNames[0];
        var woorksheet = workbook.Sheets[first_sheet_name];
        var arraylist = XLSX.utils.sheet_to_json(woorksheet, { raw: true });
        this.filelist = arraylist;
        this.headers = Object.keys(this.filelist[0]);
        this.contents = this.filelist;
        let rawData = { headers: this.headers, data: this.contents };
        subscriber.next(rawData);
      }
    });
  }
}
