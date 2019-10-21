import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutComponent } from './layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        redirectTo: 'doctor'
      },
      {
        path: 'dashboard',
        loadChildren: './dashboard/dashboard.module#DashboardModule'
      },
      {
        path: 'doctor',
        loadChildren: './doctor/doctor.module#DoctorModule'
      },
      {
        path: 'wholeseller',
        loadChildren: './wholeSeller/wholeSeller.module#WholeSellerModule'
      },
      {
        path: 'medicinecategory',
        loadChildren: './medicineCategory/medicineCategory.module#MedicineCategoryModule'
      },
      {
        path: 'schedulecategory',
        loadChildren: './scheduleCategory/scheduleCategory.module#ScheduleCategoryModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule {}
