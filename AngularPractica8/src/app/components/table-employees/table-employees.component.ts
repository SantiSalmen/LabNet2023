import { Component, ViewChild } from '@angular/core';
import { EmployeesService } from '../service/employees.service';
import { employeeDto } from 'src/app/Core/Models/employeeDto';
import { SharedInfoService } from '../service/shared-info.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';



let ELEMENT_DATA: employeeDto[] = [];
@Component({
  selector: 'app-table-employees',
  templateUrl: './table-employees.component.html',
  styleUrls: ['./table-employees.component.css']
})


export class TableEmployeesComponent {
  displayedColumns: string[] = ['id', 'FirstName', 'LastName', 'homePhone'];
  dataSource = new MatTableDataSource<employeeDto>(ELEMENT_DATA);;
  selectedEmployee: employeeDto | null = null;
  selectedId: number | null = null;

  constructor(private _employeesService: EmployeesService, private _sharedInfoService: SharedInfoService, private _snackBar: MatSnackBar){
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
          this._snackBar.open('Se eliminó correctamente el empleado','',{
            duration: 5000,
            horizontalPosition: 'center',
            verticalPosition: 'bottom'
          })
          this.selectedId = null;
          this.getAllEmployees();
        },
        error:()=>{
          alert("No existe el empleado");
        }

    });
    }
  }
}
