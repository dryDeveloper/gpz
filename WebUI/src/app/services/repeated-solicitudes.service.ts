import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Solicitud } from '../models/Solicitud'; 
import { SolicitudesService } from './solicitudes.service';

@Injectable({
  providedIn: 'root'
})
export class RepeatedSolicitudesService {

  constructor(private solicitudService: SolicitudesService) { }

  async filterOutRepeatedSolicitudes(Solicitudes: Solicitud[]) {
    let filteredSolicitudes: Solicitud[] = [];
    let repeatedFolios: number[] = [];
    const foliosResponse = await lastValueFrom(this.solicitudService.getAllFolios());
    const currentFolios = foliosResponse.data as number[];

    Solicitudes.forEach(s => {
      currentFolios.forEach(f => {
        if (f == parseInt(s.folio)) repeatedFolios.push(f);
      }); 
    });

    // Indexing array by folio number in order to remove repeated folios
    const indexedSolicitudes = Solicitudes.reduce((acc, el) => ({
      ...acc,
      [el.folio]: el,
    }), {});

    const mappedSolicitudes = Solicitudes.map(sol => {
      return {
        [sol.folio]: sol
      }
    })


    // const result = Solicitudes.filter(function(n) {
    //   if (repeatedFolios.indexOf(parseInt(n.folio)) == -1)
    //     return n;
    // });

    // const result = Solicitudes.filter(s => { 
    //   if (repeatedFolios.indexOf(parseInt(s.folio)) == -1) return s;
    // });

    // console.log(result);

  }

}
