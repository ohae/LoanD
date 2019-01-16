using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadD.Api
{
    public class LoanInfo
    {
        public List<LoanYear> LoanYears { get; set; }

        public LoanInfo()
        {
            this.LoanYears = new List<LoanYear>();
        }
    }

    public class LoanYear
    {
        public double RemainAmount { get; set; }
        public int Year { get; set; }
        public double PaidAmount { get; set; }
    }
}
