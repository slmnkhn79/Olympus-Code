import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Dashboard';
   baseUrl: string = 'http://localhost:11137/api/';
  queryUrl: string = '?search=';
  employeeList: EmployeeBasicInfo[];

  constructor(http: HttpClient) {
    http.get<EmployeeBasicInfo[]>(this.baseUrl + 'E360DataService/GetEmployeeList').subscribe(result => {
      this.employeeList = result;
      console.log("Data loaded");
    }, error => console.error(error));
}
}
interface EmployeeBasicInfo {
  Email: string,
  Id: number,
  Name: string,
  Gpmvid: string,
  Location: string
}

