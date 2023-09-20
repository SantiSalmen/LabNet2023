import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TableEmployeesComponent } from './components/table-employees/table-employees.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './components/shared/shared.module';
import { CreateEditEmployeeComponent } from './components/table-employees/create-edit-employee/create-edit-employee.component';




@NgModule({
  declarations: [
    AppComponent,
    TableEmployeesComponent,
    CreateEditEmployeeComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
