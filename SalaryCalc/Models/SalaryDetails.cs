namespace SalaryCalc.Models
{
    public class SalaryDetails
    {
        public decimal Salary { get; set; }

        public decimal NetSalary { get; set; }

        public decimal SocialSecurityTax { get; set; }

        public decimal BaseSalaryToCalculateIncomeTax { get; set; }

        public decimal IncomeTax { get; set; }

        public override string ToString()
        {
            return
                $"Salary: {this.Salary:0.00} \n" +
                $"  SocialSecurityTax: {this.SocialSecurityTax:0.00} \n" +
                $"  BaseSalaryToCalculateIncomeTax: {this.BaseSalaryToCalculateIncomeTax:0.00} \n" +
                $"  IncomeTax: {this.IncomeTax:0.00} \n" +
                $"  NetSalary: {this.NetSalary:0.00}";
        }
    }
}
