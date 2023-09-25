import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../_models/Employee';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) { }

    public addEmployee(employee: Employee) {
        return this.http.post(this.baseUrl + 'Employees', employee);
    }

    public updateEmployee(id: number, employee: Employee) {
        return this.http.put(this.baseUrl + 'employees/' + id, employee);
    }

    public getEmployees(): Observable<Employee[]> {
        return this.http.get<Employee[]>(this.baseUrl + `employees`);
    }

    public getEmployeeById(id: number): Observable<Employee> {
        return this.http.get<Employee>(this.baseUrl + 'employees/' + id);
    }

    public deleteEmployee(id: number) {
        return this.http.delete(this.baseUrl + 'employees/' + id);
    }

    public search(name: string): Observable<Employee[]> {
        return this.http.get<Employee[]>(`${this.baseUrl}employees/search/${name}`);
    }
}