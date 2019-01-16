import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  MyInterestRate: string;
  DefaultInterestRate: string = '12';
  constructor(public navCtrl: NavController,public http: HttpClient) {
    this.http.get<string>("https://localhost:44363/api/Loan").subscribe(
      it => {
          // SUCCESS: Do something
          this.DefaultInterestRate = it
      }, 
      error => {
          // ERROR: Do something
      });
  }
  SetInterestRate()
  {
    this.http.put<any>("https://localhost:44363/api/Loan",
    {
      interestRate: this.MyInterestRate,
    }).subscribe(
        it => {
            // SUCCESS: Do something
            this.DefaultInterestRate = it.interestRate
            alert("Updated");
        }, 
        error => {
            // ERROR: Do something
        });
  }
}
