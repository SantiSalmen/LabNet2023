import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableEmployeesComponent } from './components/table-employees/table-employees.component';
import { CreateEditEmployeeComponent } from './components/table-employees/create-edit-employee/create-edit-employee.component';

const routes: Routes = [ 
{path:'', pathMatch: 'full', redirectTo:'table-employees'},
{path:'table-employees', component: TableEmployeesComponent},
{
  path:'create-edit-employee', component: CreateEditEmployeeComponent
  // loadChildren:() => import('./components/dashboard/dashboard.module')
  //   .then(x=>x.DashboardModule), 
},
{path:'**', pathMatch: 'full', redirectTo:'table-employees'},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
