import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';


import { TranslateModule } from '@ngx-translate/core';
import { DoctorRoutingModule } from './doctor-routing.module';
import { CreateComponent } from './create/create.component';
import {  UpdateComponent } from './update/update.component';
import { DoctorComponent } from './doctor.component';
import { ListComponent } from './list/list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material-module';

@NgModule({
  declarations: [DoctorComponent, CreateComponent, UpdateComponent, ListComponent],
  imports: [
    CommonModule,
    DoctorRoutingModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class DoctorModule {}
