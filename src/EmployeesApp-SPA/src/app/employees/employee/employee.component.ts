import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Employee } from 'src/app/_models/Employee';
import { EmployeeService } from 'src/app/_services/employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  public formData: Employee | undefined;

  constructor(public service: EmployeeService,
              private router: Router,
              private route: ActivatedRoute,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    let id;
    this.route.params.subscribe(params => {
      id = params['id'];
    });

    if (id != null) {
      this.service.getEmployeeById(id).subscribe(employee => {
        this.formData = employee;
        const birthDate =  new Date(employee.birthDate);
        this.formData.birthDate = { year: birthDate.getFullYear(), month: birthDate.getMonth(), day: birthDate.getDay() };
        const employmentDate =  new Date(employee.employmentDate);
        this.formData.employmentDate = { year: employmentDate.getFullYear(), month: employmentDate.getMonth(), day: employmentDate.getDay() };
      }, err => {
        this.toastr.error('Ошибка при получении записи');
      });
    } else {
      this.resetForm();
    }
  }

  public onSubmit(form: NgForm) {
    form.value.birthDate = this.convertStringToDate(form.value.birthDate);
    form.value.employmentDate = this.convertStringToDate(form.value.employmentDate);
    if (form.value.id === 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  public insertRecord(form: NgForm) {
    this.service.addEmployee(form.form.value).subscribe(() => {
      this.toastr.success('Успешно');
      this.resetForm(form);
      this.router.navigate(['/employees']);
    }, () => {
      this.toastr.error('Ошибка при добавлении записи');
    });
  }

  public updateRecord(form: NgForm) {
    this.service.updateEmployee(form.form.value.id, form.form.value).subscribe(() => {
      this.toastr.success('Запись успешно обновлена');
      this.resetForm(form);
      this.router.navigate(['/books']);
    }, () => {
      this.toastr.error('Ошибка при обновлении записи');
    });
  }

  public cancel() {
    this.router.navigate(['/employees']);
  }

  private resetForm(form?: NgForm) {
    if (form != null) {
      form.form.reset();
    }

    this.formData = {
      id: 0,
      fullName: '',
      department: '',
      salary: null,
      birthDate: null,
      employmentDate: null
    };
  }

  private convertStringToDate(date: { year: any; month: any; day: any; }) {
    return new Date(`${date.year}-${date.month}-${date.day}`);
  }
}