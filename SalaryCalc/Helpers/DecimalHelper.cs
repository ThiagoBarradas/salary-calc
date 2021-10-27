using System;

namespace SalaryCalc.Helpers
{
    public static class DecimalHelper
    {
        public static decimal RoundUpWithTwoPlaces(this decimal input)
        {
            decimal multiplier = (decimal) Math.Pow(10, 2); // 2 = 2 places
            return decimal.Ceiling(input * multiplier) / multiplier;
        }
    }
}
