using SalaryCalc.Interfaces;
using System;
using System.Globalization;

namespace SalaryCalc.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISocialSecurityCalculator socialSecurityCalculator = new SocialSecurityCalculator();
            IIncomeTaxCalculator incomeTaxCalculator = new IncomeTaxCalculator();
            ISalaryCalculator salaryCalculator = new SalaryCalculator(socialSecurityCalculator, incomeTaxCalculator);

            do
            {
                System.Console.Write("Input your salary (like 1200.00): ");

                try
                {
                    var salary = System.Console.ReadLine();
                    var salaryDecimal = decimal.Parse(salary, CultureInfo.InvariantCulture);

                    var salaryDetails = salaryCalculator.CalculateDetails(salaryDecimal);

                    System.Console.WriteLine(salaryDetails.ToString());
                    System.Console.WriteLine();
                }
                catch (Exception)
                {
                    return;
                }
            }
            while (true);           
        }
    }
}
