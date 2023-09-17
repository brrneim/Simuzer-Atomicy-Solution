import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DemandCreateComponent } from './demand-create/demand-create.component';
import { DemandDetailComponent } from './demand-detail/demand-detail.component';
import { DemandComponent } from './demand.component';
import { DemandsListComponent } from './demands-list/demands-list.component';

const routes: Routes = [
  {
    path: '',
    component: DemandComponent,
    children: [
      {
        path: '',
        redirectTo: 'demand',
        pathMatch: 'full'
      },
      {
        path: 'demands',
        component: DemandsListComponent,
      },
      {
        path: 'demandDetail/:id',
        component: DemandDetailComponent,
      },
      {
        path: 'demand-create',
        component: DemandCreateComponent
      },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DemandRoutingModule { }
