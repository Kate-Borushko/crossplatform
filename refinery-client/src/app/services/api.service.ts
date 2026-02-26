import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee, CreateEmployeeRequest } from '../models/employee.models';
import { Facility, CreateFacilityRequest } from '../models/facility.models';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:7247/api'; 

  constructor(private http: HttpClient) { }

  // --- Employees ---
  getEmployees(params?: any): Observable<Employee[]> {
    let httpParams = new HttpParams();
    if (params) {
      Object.keys(params).forEach(key => {
        if (params[key] !== null && params[key] !== undefined) {
          httpParams = httpParams.append(key, params[key]);
        }
      });
    }
    return this.http.get<Employee[]>(`${this.baseUrl}/employee`, { params: httpParams });
  }

  getEmployeeById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.baseUrl}/employee/${id}`);
  }

  createEmployee(data: CreateEmployeeRequest): Observable<Employee> {
    return this.http.post<Employee>(`${this.baseUrl}/employee`, data);
  }

  updateEmployee(id: number, data: CreateEmployeeRequest): Observable<Employee> {
    return this.http.put<Employee>(`${this.baseUrl}/employee/${id}`, data);
  }
  // Получить одну установку
  getFacilityById(id: number): Observable<Facility> {
    return this.http.get<Facility>(`${this.baseUrl}/facility/${id}`);
  }

  // Обновить установку (согласно твоему бэкенду [HttpPut("{id:int}")])
  updateFacility(id: number, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/facility/${id}`, data);
  }

  deleteEmployee(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/employee/${id}`);
  }

  // --- Facilities ---
  getFacilities(params?: any): Observable<Facility[]> {
    let httpParams = new HttpParams();
    if (params) {
      Object.keys(params).forEach(key => {
        if (params[key]) httpParams = httpParams.append(key, params[key]);
      });
    }
    return this.http.get<Facility[]>(`${this.baseUrl}/facility`, { params: httpParams });
  }

  // В контроллере Facility метод Create требует employeeId в Route: [HttpPost("{employeeId:int}")]
  createFacility(employeeId: number, data: CreateFacilityRequest): Observable<any> {
    return this.http.post(`${this.baseUrl}/facility/${employeeId}`, data);
  }

  deleteFacility(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/facility/${id}`);
  }
  // --- Users ---
  getUsers(params?: any): Observable<any[]> {
    let httpParams = new HttpParams();
    if (params) {
      Object.keys(params).forEach(key => {
        if (params[key]) httpParams = httpParams.append(key, params[key]);
      });
    }
    return this.http.get<any[]>(`${this.baseUrl}/Users`, { params: httpParams });
  }

  // Создание пользователя требует EmployeeID в URL
  createUser(employeeId: number, data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/Users/${employeeId}`, data);
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/Users/${id}`);
  }
}
