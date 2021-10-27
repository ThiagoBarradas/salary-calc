using SalaryCalc.Models;

namespace SalaryCalc.Interfaces
{
    public interface ISalaryCalculator
    {
        SalaryDetails CalculateDetails(decimal salary);
    }
}
