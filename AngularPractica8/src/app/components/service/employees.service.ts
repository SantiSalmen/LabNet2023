import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { enviroment } from '../../enviroments/enviroment';
import { Observable } from 'rxjs/internal/Observable';
import {employeeDto} from '../../Core/Models/employeeDto';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  apiUrl: string = enviroment.apiLab;
  constructor(private http: HttpClient) { }

  public getEmployees():Observable<Array<employeeDto>> {
    let url =`${this.apiUrl}employees`
    return this.http.get<Array<employeeDto>>(url);
  }

  public postEmployee(employeeRequest: employeeDto):Observable<any>{
    let url =`${this.apiUrl}employees`
    return this.http.post(url, employeeRequest);
  }

  public deleteEployee(id: number): Observable<any>{
    let url =`${this.apiUrl}employees/${id}`
    return this.http.delete(url);
  }

  public putEmployee(employeeRequest: employeeDto): Observable<any>{
    let url =`${this.apiUrl}employees/`
    return this.http.put(url, employeeRequest);
  }

};


