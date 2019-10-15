import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import {
  MatButtonModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatSidenavModule,
  MatToolbarModule
} from '@angular/material';
import { TranslateModule } from '@ngx-translate/core';
import { DoctorRoutingModule } from './doctor-routing.module';

@NgModule({
  imports: [CommonModule, NgModule, DoctorRoutingModule],
  declarations: [NgModule, DoctorRoutingModule]
})
export class DoctorModule {}
