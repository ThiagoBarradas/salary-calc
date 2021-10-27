using Moq;
using SalaryCalc.Interfaces;
using System;
using Xunit;

namespace SalaryCalc.UnitTests
{
    public class SalaryCalculatorTests
    {
        [Theory]
        [InlineData(1000, 10, 990,  100, 890)]
        [InlineData(1000, 0,  1000, 20,  980)]
        [InlineData(2000, 50, 1950, 900, 1050)]
        public void CalculateDetails_Should_Calculates_Details_For_Positive_Values(
            decimal salary, 
            decimal expectedSocialSecurity,
            decimal expectedBaseForIncomeTax,
            decimal expectedIncomeTax,
            decimal expectedNetSalary)
        {
            // arrange
            Mock<ISocialSecurityCalculator> socialSecurityCalculatorMock = new Mock<ISocialSecurityCalculator>();
            socialSecurityCalculatorMock
                .Setup(m => m.CalculateTax(salary))
                .Returns(expectedSocialSecurity);

            Mock<IIncomeTaxCalculator> incomeTaxCalculatorMock = new Mock<IIncomeTaxCalculator>();
            incomeTaxCalculatorMock
                .Setup(m => m.CalculateTax(expectedBaseForIncomeTax))
                .Returns(expectedIncomeTax);

            var salaryCalculator = new SalaryCalculator(
                socialSecurityCalculatorMock.Object,
                incomeTaxCalculatorMock.Object);

            // act
            var details = salaryCalculator.CalculateDetails(salary);

            // assert
            Assert.NotNull(details);
            Assert.Equal(salary, details.Salary);
            Assert.Equal(expectedSocialSecurity, details.SocialSecurityTax);
            Assert.Equal(expectedIncomeTax, details.IncomeTax);
            Assert.Equal(expectedBaseForIncomeTax, details.BaseSalaryToCalculateIncomeTax);
            Assert.Equal(expectedNetSalary, details.NetSalary);
            incomeTaxCalculatorMock.Verify(m => m.CalculateTax(expectedBaseForIncomeTax), Times.Once);
            socialSecurityCalculatorMock.Verify(m => m.CalculateTax(salary), Times.Once);
        }

        [Fact]
        public void CalculateDetails_Should_Throws_Exception_When_Salary_Is_Not_Greater_Than_Zero()
        {
            // arrange
            Mock<ISocialSecurityCalculator> socialSecurityCalculatorMock = new Mock<ISocialSecurityCalculator>();
            socialSecurityCalculatorMock
                .Setup(m => m.CalculateTax(It.IsAny<decimal>()))
                .Returns(100);

            Mock<IIncomeTaxCalculator> incomeTaxCalculatorMock = new Mock<IIncomeTaxCalculator>();
            incomeTaxCalculatorMock
                .Setup(m => m.CalculateTax(It.IsAny<decimal>()))
                .Returns(150);

            var salaryCalculator = new SalaryCalculator(
                socialSecurityCalculatorMock.Object, 
                incomeTaxCalculatorMock.Object);
            
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => salaryCalculator.CalculateDetails(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => salaryCalculator.CalculateDetails(-1));
        }
    }
}
