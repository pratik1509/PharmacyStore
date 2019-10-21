import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { ScheduleCategoryRoutingModule } from './scheduleCategory-routing.module';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { ScheduleCategoryComponent } from './scheduleCategory.component';
import { ListComponent } from './list/list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material-module';

@NgModule({
  declarations: [ScheduleCategoryComponent, CreateComponent, UpdateComponent, ListComponent],
  imports: [CommonModule, ScheduleCategoryRoutingModule, FlexLayoutModule, ReactiveFormsModule, MaterialModule]
})
export class ScheduleCategoryModule {}
