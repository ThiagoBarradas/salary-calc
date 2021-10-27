using SalaryCalc.Helpers;
using SalaryCalc.Interfaces;
using System;
using System.Linq;

namespace SalaryCalc
{
    public class IncomeTaxCalculator : IIncomeTaxCalculator
    {
        private static IncomeTaxLevel[] IncomeTaxLevels = new IncomeTaxLevel[] 
            {
                new IncomeTaxLevel(1903.98m, 0, 0),
                new IncomeTaxLevel(2826.65m, 7.5m,  142.80m),
                new IncomeTaxLevel(3751.05m, 15.0m, 354.80m),
                new IncomeTaxLevel(4664.68m, 22.5m, 636.13m),
                new IncomeTaxLevel(decimal.MaxValue, 27.5m, 869.36m),
            };

        public decimal CalculateTax(decimal salary)
        {
            if (salary <= 0)
            {
                throw new ArgumentOutOfRangeException("salary must be a positive value - greater than zero");
            }

            var rule = IncomeTaxLevels.First(r => salary <= r.MaxSalary);

            if (rule.DiscountPercent == 0)
            {
                return 0;
            }

            return ((salary * (rule.DiscountPercent / 100)) - rule.DeductiblePortion).RoundUpWithTwoPlaces();
        }

        private class IncomeTaxLevel
        {
            public IncomeTaxLevel(
                decimal maxSalary, 
                decimal discountPercent, 
                decimal deductiblePortion)
            {
                this.MaxSalary = maxSalary;
                this.DiscountPercent = discountPercent;
                this.DeductiblePortion = deductiblePortion;
            }

            public decimal MaxSalary { get; set; }

            public decimal DiscountPercent { get; set; }

            public decimal DeductiblePortion { get; set; }
        }
    }
}
