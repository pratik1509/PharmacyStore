import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedicineCommodityComponent } from './medicineCommodity.component';
import { CreateComponent } from './create/create.component';
import { UpdateComponent } from './update/update.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [
  {
    path: '',
    component: MedicineCommodityComponent,
    children: [
      {
        path: '',
        redirectTo: 'list'
      },
      {
        path: 'list',
        component: ListComponent
      },
      {
        path: 'create',
        component: CreateComponent
      },
      {
        path: 'update/:id',
        component: UpdateComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MedicineCommodityRoutingModule {}
