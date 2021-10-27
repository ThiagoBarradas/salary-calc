using System;
using Xunit;

namespace SalaryCalc.UnitTests
{
    public class SocialSecurityCalculatorTests
    {
        [Theory]
        [InlineData(1000, 110)]
        [InlineData(2000, 220)]
        [InlineData(10000, 707.70)]
        public void CalculateTax_Should_Calculates_Tax_For_Positive_Values(decimal salary, decimal expected)
        {
            // arrange
            var socialSecurityCalculator = new SocialSecurityCalculator();

            // act
            var result = socialSecurityCalculator.CalculateTax(salary);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateTax_Should_Throws_Exception_When_Salary_Is_Not_Greater_Than_Zero()
        {
            // arrange
            var socialSecurityCalculator = new SocialSecurityCalculator();
            
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => socialSecurityCalculator.CalculateTax(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => socialSecurityCalculator.CalculateTax(-1));
        }
    }
}
