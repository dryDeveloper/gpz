import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/Response';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'})
}

@Injectable({
  providedIn: 'root'
})
export class SolicitudesService {

  // private baseEndPoint: string = "https://localhost:7220/api/Solicitud/";

  constructor(private http: HttpClient) { }

  getSolicitudes(captureDay: string): Observable<Response> {
    const endPoint = `https://localhost:7220/api/Solicitud/${captureDay}`
    return this.http.get<Response>(endPoint, httpOptions);
  }
}
