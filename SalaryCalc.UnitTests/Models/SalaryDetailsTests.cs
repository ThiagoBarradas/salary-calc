using SalaryCalc.Models;
using System.Globalization;
using System.Threading;
using Xunit;

namespace SalaryCalc.UnitTests.Models
{
    public class SalaryDetailsTests
    {
        [Fact]
        public void ToString_Should_Return_A_String_With_All_Values()
        {
            // arrange
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            var salaryDetails = new SalaryDetails
            {
                Salary = 10.123m,
                BaseSalaryToCalculateIncomeTax = 10m,
                IncomeTax = 1.123m,
                NetSalary = 1.98m,
                SocialSecurityTax = 6789.2m
            };  

            var expected = "Salary: 10.12 \n  SocialSecurityTax: 6789.20 \n  BaseSalaryToCalculateIncomeTax: 10.00 \n  IncomeTax: 1.12 \n  NetSalary: 1.98";

            // act
            var result = salaryDetails.ToString();
            
            // assert
            Assert.Equal(expected, result);
        }
    }
}
