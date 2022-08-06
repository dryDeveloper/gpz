import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ImportDataComponent } from './import-data/import-data.component';
import { PrintTemplateComponent } from './print-template/print-template.component';

const routes: Routes = [
  { path: 'import-data', component: ImportDataComponent },
  { path: 'print', component: PrintTemplateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
