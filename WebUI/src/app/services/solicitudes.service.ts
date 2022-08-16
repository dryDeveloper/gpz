import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/Response';
import { Solicitud } from '../models/Solicitud';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class SolicitudesService {

  // prod
  private baseEndPoint: string = "http://localhost:5187/api/Solicitud/";
  // dev
  // private baseEndPoint: string = "https://localhost:7220/api/Solicitud/";

  constructor(private http: HttpClient) { }

  getAllFolios() {
    return this.http.get<Response>(this.baseEndPoint, httpOptions);
  }

  getSolicitudes(captureDay: string): Observable<Response> {
    const endPoint = `${this.baseEndPoint}${captureDay}`
    return this.http.get<Response>(endPoint, httpOptions);
  }

  bulkInsertSolicitudes(importedSolicitudes: Solicitud[]) {
    return this.http.post<Response>(this.baseEndPoint, importedSolicitudes, httpOptions);
  }
}
