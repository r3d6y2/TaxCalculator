namespace TaxCalculator.Domain.Services.Commands;

public class CalculateTaxCommand
{
    public CalculateTaxCommand(double incoming)
    {
        Incoming = incoming;
    }
    
    public double Incoming { get; }
    
    public class Reply
    {
        public Reply(double grossAnnualSalary, 
            decimal grossMonthlySalary, 
            decimal netAnnualSalary, 
            decimal netMonthlySalary, 
            decimal annualTax, 
            decimal monthlyTax)
        {
            GrossAnnualSalary = grossAnnualSalary;
            GrossMonthlySalary = grossMonthlySalary;
            NetAnnualSalary = netAnnualSalary;
            NetMonthlySalary = netMonthlySalary;
            AnnualTax = annualTax;
            MonthlyTax = monthlyTax;
        }

        public double GrossAnnualSalary { get;}
        public decimal GrossMonthlySalary { get;}
        public decimal NetAnnualSalary { get;}
        public decimal NetMonthlySalary { get;}
        public decimal AnnualTax { get;}
        public decimal MonthlyTax { get;}
    }
}