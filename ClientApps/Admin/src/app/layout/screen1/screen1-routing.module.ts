import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Screen1Component } from './screen1.component';

const routes: Routes = [
  {
    path: '',
    component: Screen1Component,
    children: [
      {
        path: 'screen1_list'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Screen1RoutingModule {}
