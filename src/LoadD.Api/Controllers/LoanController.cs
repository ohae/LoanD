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
            var engine = new InterestCalculator();
            return engine.CalculateInterest(beginMoney, yearsRange, interestRate);
        }

        [HttpGet]
        public ActionResult<double> GetInterestRate()
        {
            return interestRate;
        }

        // PUT api/values/5
        [HttpPut(Name = "SetInterestRate")]
        public void SetInterestRate([FromBody] string myInterestRate)
        {
            interestRate = double.Parse(myInterestRate) / 100;
        }
    }
}
