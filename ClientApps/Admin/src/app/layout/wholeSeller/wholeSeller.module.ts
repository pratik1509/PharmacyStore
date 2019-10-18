import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { TranslateModule } from '@ngx-translate/core';
import { WholeSellerRoutingModule } from './wholeSeller-routing.module';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { WholeSellerComponent } from './wholeSeller.component';
import { ListComponent } from './list/list.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material-module';

@NgModule({
  declarations: [WholeSellerComponent, CreateComponent, UpdateComponent, ListComponent],
  imports: [CommonModule, WholeSellerRoutingModule, FlexLayoutModule, ReactiveFormsModule, MaterialModule]
})
export class WholeSellerModule {}
