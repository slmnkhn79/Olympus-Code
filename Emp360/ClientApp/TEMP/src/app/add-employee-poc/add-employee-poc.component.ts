import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';
import { SearchEmployee } from './employee-search.service';
import { debug } from 'util';


@Component({
  selector: 'add-employee-poc',
  templateUrl: './add-employee-poc.component.html',
  styleUrls: ['./add-employee-poc.component.css'],
  providers: [SearchEmployee]
})
export class addEmployeePOC {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public employeeList: EmployeeBasicInfo[];

  /*constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeBasicInfo[]>(baseUrl + 'api/E360DataService/GetEmployeeList').subscribe(result => {
      this.employeeList = result;
      console.log(result);
    }, error => console.error(error));
  }*/

  results: EmployeeBasicInfo[];
  searchTerm$ = new Subject<string>();
  selectedEmployee: EmployeeBasicInfo;
  selectedEmployeeName: string = "";

  searchQuery(term) {
    this.searchTerm$.next(term)
    this.results = [];
  }

  selectEmployeefromList(employee: EmployeeBasicInfo) {
    this.selectedEmployee = employee;
    this.selectedEmployeeName =  this.selectedEmployee.name;
    this.results = [];
  }


  constructor(private searchEmployeeService: SearchEmployee) {
    this.searchEmployeeService.search(this.searchTerm$)
      .subscribe(results => {
        this.results.push(results);
        //debugger;
        //console.log(results);
      });
  }

}

interface EmployeeBasicInfo {
  email:string,
  tcsID:number,
  name:string,
  gpmVid: string,
  location: string
}
