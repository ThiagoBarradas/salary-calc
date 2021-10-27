using System;
using Xunit;

namespace SalaryCalc.UnitTests
{
    public class IncomeTaxCalculatorTests
    {
        [Theory]
        [InlineData(1000, 0)]
        [InlineData(2000, 7.2)]
        [InlineData(3000, 95.2)]
        [InlineData(4000, 263.87)]
        [InlineData(5000, 505.64)]
        public void CalculateTax_Should_Calculates_Tax_For_Positive_Values(decimal salary, decimal expected)
        {
            // arrange
            var incomeTaxCalculator = new IncomeTaxCalculator();

            // act
            var result = incomeTaxCalculator.CalculateTax(salary);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateTax_Should_Throws_Exception_When_Salary_Is_Not_Greater_Than_Zero()
        {
            // arrange
            var incomeTaxCalculator = new IncomeTaxCalculator();
            
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => incomeTaxCalculator.CalculateTax(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => incomeTaxCalculator.CalculateTax(-1));
        }
    }
}
