import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SolicitudComponent } from './solicitud/solicitud.component';
import { SolicitudListComponent } from './solicitud-list/solicitud-list.component';
import { MaterialModule } from '../material/material.module';



@NgModule({
  declarations: [
    SolicitudComponent,
    SolicitudListComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    SolicitudComponent,
    SolicitudListComponent
  ]
})
export class SolicitudModule { }
