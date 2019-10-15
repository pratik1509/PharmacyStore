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
        path: 'screen1',
        loadChildren: './screen1/screen1.module#Screen1Module'
      },
      // {
      //   path: 'doctor',
      //   component: DoctorComponent

      // }
      {
        path: 'doctor',
        loadChildren: './doctor/doctor.module#DoctorModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule {}
