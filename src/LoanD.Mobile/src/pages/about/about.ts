import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {
  LoanYears: LoanYear[];
  BeginMoney: number;
  YearRange: number;
  InterestRate: string;

  constructor(public navCtrl: NavController, public http: HttpClient) {
    
  }

  CalculateInterest()
  {
    this.http.get<any>("https://localhost:44363/api/Loan/" + this.BeginMoney + "/" + this.YearRange).subscribe(
      it => {
          // SUCCESS: Do something
          this.LoanYears = it.loanYears;
          this.InterestRate = it.interestRate;
      }, 
      error => {
          // ERROR: Do something
      });
  }
}

export class LoanYear {
  public remainAmount: number;
  public year: number;
  public paidAmount: number;
}