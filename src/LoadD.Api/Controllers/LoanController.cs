using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private static double interestRate = 0.1; //default 10%

        // GET api/values
        [HttpGet("{beginMoney}/{yearsRange}", Name = "CalculateInterest")]
        public ActionResult<LoanInfo> CalculateInterest(double beginMoney, int yearsRange)
        {
            return InterestCalculator.CalculateInterest(beginMoney, yearsRange, interestRate);
        }

        [HttpGet]
        public ActionResult<double> GetInterestRate()
        {
            return interestRate * 100;
        }

        // PUT api/values/5
        [HttpPut(Name = "SetInterestRate")]
        public SetInterestRateRequest SetInterestRate([FromBody] SetInterestRateRequest myInterestRate)
        {
            interestRate = double.Parse(myInterestRate.InterestRate) / 100;
            return myInterestRate;
        }
    }
}
