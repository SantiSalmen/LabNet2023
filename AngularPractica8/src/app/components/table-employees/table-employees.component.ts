import { Component, ViewChild } from '@angular/core';
import { EmployeesService } from '../service/employees.service';
import { employeeDto } from 'src/app/Core/Models/employeeDto';
import { SharedInfoService } from '../service/shared-info.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';



let ELEMENT_DATA: employeeDto[] = [];
@Component({
  selector: 'app-table-employees',
  templateUrl: './table-employees.component.html',
  styleUrls: ['./table-employees.component.css']
})


export class TableEmployeesComponent {
  displayedColumns: string[] = ['id', 'FirstName', 'LastName', 'homePhone'];
  dataSource = new MatTableDataSource<employeeDto>(ELEMENT_DATA);
;
  selectedEmployee: employeeDto | null = null;
  selectedId: number | null = null;

  constructor(private _employeesService: EmployeesService, private _sharedInfoService: SharedInfoService, router: Router){
  };
  
  ngOnInit(): void{
    this.getAllEmployees();
  }
  
  ngOnChanges(): void{
    this.getAllEmployees();

  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;


  selectRow(employee: any): void {
    this.selectedId = employee.id;
    this.selectedEmployee = {
      id: employee.id,
      firstName: employee.firstName,
      lastName: employee.lastName,
      homePhone: employee.homePhone
    };
  }
  
  goCreate(){
    console.log('entro3');
    if (this.selectedEmployee != null) 
    {
      console.log('entro');
      this.selectedEmployee = null;
      this.sendInfo(this.selectedEmployee)
    }
      else {
        console.log('entro2');
        this.sendInfo(this.selectedEmployee);
      }

  }

  callsSend(){
    if (this.selectedEmployee !== null) {
      this.sendInfo(this.selectedEmployee);
    }
  }

  sendInfo(employee: employeeDto | null){
     this._sharedInfoService.setSelectedEmployee(employee);
  }
  
  getAllEmployees(){
    this._employeesService.getEmployees().subscribe({
      next:(result)=>{
        this.dataSource.data = result;
      },
      error:(error)=>{
        console.log(error);
      } 
    });
  }
  
  deleteButton(): void {
    if (this.selectedId !== null) {
      this._employeesService.deleteEployee(this.selectedId).subscribe({
        next:()=>{
          this.selectedId = null;
          this.getAllEmployees();
        },
        error:()=>{
          console.log("No existe el usuario");
          alert("No existe el usuario");
        }

    });
    }
  }
}

