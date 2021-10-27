using SalaryCalc.Helpers;
using Xunit;

namespace SalaryCalc.UnitTests.Helpers
{
    public class DecimalHelperTests
    {
        [Theory]
        [InlineData(123.00,  123.00)]
        [InlineData(123.10,  123.10)]
        [InlineData(123.11,  123.11)]
        [InlineData(123.111, 123.12)]
        [InlineData(123.119, 123.12)]
        [InlineData(123.11000001, 123.12)]
        [InlineData(123.11999999, 123.12)]
        public void RoundUpWithTwoPlaces_Should_Round_Result_Always_To_Up_With_2_Places(decimal input, decimal expected)
        {
            // arrange & act
            var result = input.RoundUpWithTwoPlaces();

            // assert
            Assert.Equal(expected, result);
        }
    }
}
