
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { employeeDto } from 'src/app/Core/Models/employeeDto';
import { EmployeesService } from '../../service/employees.service';
import { Router } from '@angular/router';
import { SharedInfoService } from '../../service/shared-info.service';


@Component({
  selector: 'app-create-edit-employee',
  templateUrl: './create-edit-employee.component.html',
  styleUrls: ['./create-edit-employee.component.css']
})

export class CreateEditEmployeeComponent 
{
  selectedEmployee: employeeDto | undefined;
  selectedId: number | null = null;
  form: FormGroup;
  constructor(private fb: FormBuilder, 
              private _employeesService: EmployeesService, 
              private router: Router, 
              private _sharedInfoService: SharedInfoService) 
  {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(20)]],
      lastname: ['', [Validators.required, Validators.maxLength(20)]],
      homePhone: ['',[ Validators.minLength(10), Validators.maxLength(15),Validators.pattern(/^[0-9]+$/)]]
    })
  }

  ngOnInit(){

    this.selectedEmployee = this._sharedInfoService.getSelectedEmployee();
    this.selectedId = this.selectedEmployee != null ? this._sharedInfoService.getSelectedEmployee().id : null;
    if (this.selectedEmployee) {
      this.form.patchValue({
        name: this.selectedEmployee.firstName,
        lastname: this.selectedEmployee.lastName,
        homePhone: this.selectedEmployee.homePhone

  });
 
  }

  }


  addEdit()
  {
    this.selectedEmployee  = {
      id: this.selectedEmployee?.id,
      firstName: this.form.value.name,
      lastName: this.form.value.lastname,
      homePhone: this.form.value?.homePhone,
    };
    if (this.selectedId == null) 
    {
      this._employeesService.postEmployee(this.selectedEmployee).subscribe
      ({
        next:()=>{
          alert('El empleado se agregó correctamente');
          this.resetForm();
          this.router.navigate(['/table-employees'])
        },
        error:()=>{
          alert("No se pudo agregar el empleado");
        }
      });
    }
    else
    {
      this._employeesService.putEmployee(this.selectedEmployee).subscribe
      ({
        next:()=>
        {
          alert('El empleado se actualizó correctamente');
          this.resetForm();
          this.router.navigate(['/table-employees'])
        },
        error:()=>{
          alert("No se pudo actualizar el empleado");
        }
      });
    }

  }
  resetForm() {
    this.form.reset();
  }

}