import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { MedicineCategoryRoutingModule } from './medicineCategory-routing.module';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { MedicineCategoryComponent } from './medicineCategory.component';
import { ListComponent } from './list/list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material-module';

@NgModule({
  declarations: [MedicineCategoryComponent, CreateComponent, UpdateComponent, ListComponent],
  imports: [CommonModule, MedicineCategoryRoutingModule, FlexLayoutModule, ReactiveFormsModule, MaterialModule]
})
export class MedicineCategoryModule {}
