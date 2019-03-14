import { Injectable , Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { map } from 'rxjs/operator/map';

@Injectable()
export class SearchEmployee {
  baseUrl: string = 'https://api.cdnjs.com/libraries';
  queryUrl: string = '?search=';
  employeeList: EmployeeBasicInfo[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<EmployeeBasicInfo[]>(baseUrl + 'api/E360DataService/GetEmployeeList').subscribe(result => {
      this.employeeList = result;
      console.log("Data loaded");
    }, error => console.error(error));
  }


  getEmployeeList() {
    return this.employeeList;
  }

  search(terms: Observable<string>) {
    console.log("Search Hit");
    return terms.debounceTime(400)
      .distinctUntilChanged()
      .switchMap(term => this.searchEntries(term));
  }

  searchEntries(term) {
    console.log(term);

    let x = this.getEmployeeList();
    let returnArray = [];
    if (x) {
      return x.filter((employee) => {
        if (employee.name.indexOf(term) !== -1 || employee.email.indexOf(term) !== -1)
          return employee;
      });
    }
    return returnArray;
  }
}

  interface EmployeeBasicInfo {
  email: string,
  tcsID: number,
  name: string,
  gpmVid: string,
  location: string
}
