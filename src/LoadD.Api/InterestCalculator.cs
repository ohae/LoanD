using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadD.Api
{
    public static class InterestCalculator
    {
        public static LoanInfo CalculateInterest(double beginMoney, int yearsRange, double interestRate)
        {
            var remain = beginMoney;
            var result = new LoanInfo();
            result.InterestRate =  (interestRate * 100).ToString();

            for (int i = 0; i < yearsRange; i++)
            {
                var interestAmount = (remain * interestRate);
                var yearInterest = interestAmount + remain;
                result.LoanYears.Add(new LoanYear
                {
                    RemainAmount = remain,
                    Year = i + 1,
                    PaidAmount = yearInterest,
                    InterestAmount = interestAmount
                });

                remain = yearInterest;
            }
            return result;
        }
    }
}
