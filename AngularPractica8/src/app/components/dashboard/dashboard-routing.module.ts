import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateEditEmployeeComponent } from '../table-employees/create-edit-employee/create-edit-employee.component';


const routes: Routes = [{
  path:"create-edit-employee", component: CreateEditEmployeeComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
