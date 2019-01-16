using LoadD.Api;
using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LoadD.Test
{
    public class LoadDTest
    {
        [Theory]
        [MemberData(nameof(CalculateInterestData))]
        public void CalculateInterest(double beginMoney, int yearRange, double interestRate, LoanInfo expected)
        {
            var result = InterestCalculator.CalculateInterest(beginMoney, yearRange, interestRate);
            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> CalculateInterestData = new List<object[]>
        {
            new object[] { 10000, 3, 0.12,
                new LoanInfo
                {
                    LoanYears = new List<LoanYear>
                    {
                        new LoanYear { RemainAmount = 10000, Year = 1, PaidAmount = 11200 },
                        new LoanYear { RemainAmount = 11200, Year = 2, PaidAmount = 12544 },
                        new LoanYear { RemainAmount = 12544, Year = 3, PaidAmount = 14049.28 },
                    }
                },
            },
            new object[] { 10000.5, 2, 0.10,
                new LoanInfo
                {
                    LoanYears = new List<LoanYear>
                    {
                        new LoanYear { RemainAmount = 10000.5, Year = 1, PaidAmount = 11000.55 },
                        new LoanYear { RemainAmount = 11000.55, Year = 2, PaidAmount = 12100.605 },
                    }
                },
            },
        };
    }
}
