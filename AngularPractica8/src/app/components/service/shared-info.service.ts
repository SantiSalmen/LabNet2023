import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedInfoService {

  private selectedEmployee: any;

  setSelectedEmployee(employee: any) {
    this.selectedEmployee = employee;
  }

  getSelectedEmployee() {
    return this.selectedEmployee;
  }
}
