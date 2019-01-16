using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadD.Api
{
    public class InterestCalculator
    {
        public LoanInfo CalculateInterest(double beginMoney, int yearsRange, double interestRate)
        {
            var remain = beginMoney;
            var result = new LoanInfo();

            for (int i = 0; i < yearsRange; i++)
            {
                var yearInterest = (remain * interestRate) + remain;
                result.LoanYears.Add(new LoanYear
                {
                    RemainAmount = remain,
                    Year = i + 1,
                    PaidAmount = yearInterest
                });

                remain = yearInterest;
            }
            return result;
        }
    }
}
