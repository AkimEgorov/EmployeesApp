import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/_services/employee.service';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogService } from 'src/app/_services/confirmation-dialog.service';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  public employees: any;
  public listComplet: any;
  public searchTerm!: string;
  public searchValueChanged: Subject<string> = new Subject<string>();

  constructor(private router: Router,
              private service: EmployeeService,
              private toastr: ToastrService,
              private confirmationDialogService: ConfirmationDialogService) { }

  ngOnInit() {
    this.getValues();

    // this.searchValueChanged.pipe(debounceTime(1000))
    // .subscribe(() => {
    //   this.search();
    // });
  }

  private getValues() {

    this.service.getEmployees().subscribe(employees => {
      this.employees = employees;
      this.listComplet = employees;
    });
  }

  public addEmployee() {
    this.router.navigate(['/employee']);
  }

  public editEmployee(employeeId: number) {
    this.router.navigate(['/employee/' + employeeId]);
  }

  public deleteEmployee(employeeId: number) {
    this.confirmationDialogService.confirm('Внимание!', 'Вы действительно хотите удалить данного сотрудника?')
      .then(() =>
        this.service.deleteEmployee(employeeId).subscribe(() => {
          this.toastr.success('Сотрудник удален');
          this.getValues();
        },
          err => {
            this.toastr.error('Не удалось удалить сотрудника');
          }))
      .catch(() => '');
  }

  // Use the code below if you want to filter only using the front end;
  // public search() {
  //   const value = this.searchTerm.toLowerCase();
  //   this.books = this.listComplet.filter(
  //     book => book.name.toLowerCase().startsWith(value, 0) ||
  //       book.author.toLowerCase().startsWith(value, 0) ||
  //       book.description.toString().startsWith(value, 0) ||
  //       book.value.toString().startsWith(value, 0) ||
  //       book.publishDate.toString().startsWith(value, 0));
  // }

  // public searchEmployees() {
  //   this.searchValueChanged.next();
  // }

  // private search() {
  //   if (this.searchTerm !== '') {
  //     this.service.searchBooksWithCategory(this.searchTerm).subscribe(employee => {
  //       this.employees = employee;
  //     }, error => {
  //       this.employees = [];
  //     });
  //   } else {
  //     this.service.getEmployees().subscribe(employees => this.employees = employees);
  //   }
  // }
}