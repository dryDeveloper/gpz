import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MaterialModule } from './material/material.module';
import { ImportDataComponent } from './import-data/import-data.component';
import { PrintTemplateComponent } from './print-template/print-template.component';
import { SolicitudModule } from './solicitud/solicitud.module';
import { FormsModule } from '@angular/forms';
import { WarningAlertComponent } from './shared/warning-alert/warning-alert.component'

@NgModule({
  declarations: [
    AppComponent,
    MainMenuComponent,
    ImportDataComponent,
    PrintTemplateComponent,
    WarningAlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MaterialModule,
    HttpClientModule,
    SolicitudModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
