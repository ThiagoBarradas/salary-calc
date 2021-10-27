using SalaryCalc.Helpers;
using SalaryCalc.Interfaces;
using System;

namespace SalaryCalc
{
    public class SocialSecurityCalculator : ISocialSecurityCalculator
    {
        private static decimal SOCIAL_SECURITY_TAX_PERCENT = 11.0m;

        private static decimal SOCIAL_SECURITY_MAX_SALARY = 6433.57m;

        public decimal CalculateTax(decimal salary)
        {
            if (salary <= 0)
            {
                throw new ArgumentOutOfRangeException("salary must be a positive value - greater than zero");
            }

            var baseSalary = (salary < SOCIAL_SECURITY_MAX_SALARY)
                ? salary
                : SOCIAL_SECURITY_MAX_SALARY;
        
            return (baseSalary * (SOCIAL_SECURITY_TAX_PERCENT / 100)).RoundUpWithTwoPlaces();
        }
    }
}
