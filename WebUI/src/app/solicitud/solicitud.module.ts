import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SolicitudComponent } from './solicitud/solicitud.component';
import { SolicitudListComponent } from './solicitud-list/solicitud-list.component';



@NgModule({
  declarations: [
    SolicitudComponent,
    SolicitudListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SolicitudModule { }
