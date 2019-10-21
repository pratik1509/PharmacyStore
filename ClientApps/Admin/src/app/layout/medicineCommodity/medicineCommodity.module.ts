import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { MedicineCommodityRoutingModule } from './medicineCommodity-routing.module';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { MedicineCommodityComponent } from './medicineCommodity.component';
import { ListComponent } from './list/list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material-module';

@NgModule({
  declarations: [MedicineCommodityComponent, CreateComponent, UpdateComponent, ListComponent],
  imports: [CommonModule, MedicineCommodityRoutingModule, FlexLayoutModule, ReactiveFormsModule, MaterialModule]
})
export class MedicineCommodityModule {}
