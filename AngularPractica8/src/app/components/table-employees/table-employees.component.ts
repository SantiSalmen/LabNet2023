import { Component } from '@angular/core';
import { EmployeesService } from '../service/employees.service';
import { employeeDto } from 'src/app/Core/Models/employeeDto';
import { SharedInfoService } from '../service/shared-info.service';



let ELEMENT_DATA: employeeDto[] = [];
@Component({
  selector: 'app-table-employees',
  templateUrl: './table-employees.component.html',
  styleUrls: ['./table-employees.component.css']
})


export class TableEmployeesComponent {
  displayedColumns: string[] = ['id', 'FirstName', 'LastName', 'homePhone'];
  dataSource = ELEMENT_DATA;
  selectedEmployee: employeeDto | null = null;
  selectedId: number | null = null;

  constructor(private _employeesService: EmployeesService, private _sharedInfoService: SharedInfoService){
  };
  ngOnInit(): void{
    this.getAllEmployees();
  }
  
  ngOnChanges(): void{
    this.getAllEmployees();

  }

  getAllEmployees(){
    this._employeesService.getEmployees().subscribe({
      next:(result)=>{
        this.dataSource = result;
      },
      error:(error)=>{
        console.log(error);
      } 
    });
  }
  
  selectRow(employee: any): void {
    this.selectedId = employee.id;
    this.selectedEmployee = {
      id: employee.id,
      firstName: employee.firstName,
      lastName: employee.lastName,
      homePhone: employee.homePhone
    };
    console.log( this.selectedId );
  }
  
  callsSend(){
    if (this.selectedEmployee !== null) {
    this.sendInfo(this.selectedEmployee);
    }
  }

  sendInfo(employee: employeeDto){
     this._sharedInfoService.setSelectedEmployee(employee);
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
