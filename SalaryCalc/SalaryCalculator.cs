using SalaryCalc.Interfaces;
using SalaryCalc.Models;
using System;

namespace SalaryCalc
{
    public class SalaryCalculator : ISalaryCalculator
    {
        private readonly ISocialSecurityCalculator SocialSecurityCalculator;

        private readonly IIncomeTaxCalculator IncomeTaxCalculator;

        public SalaryCalculator(
            ISocialSecurityCalculator socialSecurityCalculator,
            IIncomeTaxCalculator incomeTaxCalculator)
        {
            this.SocialSecurityCalculator = socialSecurityCalculator;
            this.IncomeTaxCalculator = incomeTaxCalculator;
        }

        public SalaryDetails CalculateDetails(decimal salary)
        {
            if (salary <= 0)
            {
                throw new ArgumentOutOfRangeException("salary must be a positive value - greater than zero");
            }

            var socialSecurityDiscount = this.SocialSecurityCalculator.CalculateTax(salary);
            var baseSalaryToCalculateIncomeTax = salary - socialSecurityDiscount;
            var incomeTaxDiscount = this.IncomeTaxCalculator.CalculateTax(baseSalaryToCalculateIncomeTax);
            var netSalary = salary - socialSecurityDiscount - incomeTaxDiscount;

            return new SalaryDetails
            {
                Salary = salary,
                NetSalary = netSalary,
                IncomeTax = incomeTaxDiscount,
                SocialSecurityTax = socialSecurityDiscount,
                BaseSalaryToCalculateIncomeTax = baseSalaryToCalculateIncomeTax
            };
        }
    }
}
