using TaxCalculator.Domain.Services.Exceptions;
using TaxCalculator.Domain.Services.Interfaces;
using TaxCalculator.Domain.Services.Interfaces.Repositories;

namespace TaxCalculator.Domain.Services.Commands.Handlers;

public class CalculateTaxHandler : ICommandHandler<CalculateTaxCommand, CalculateTaxCommand.Reply>
{
    private readonly ITaxBandRepository _taxBandRepository;
    
    public CalculateTaxHandler(ITaxBandRepository taxBandRepository)
    {
        _taxBandRepository = taxBandRepository;
    }
    
    public async Task<CalculateTaxCommand.Reply> Handle(CalculateTaxCommand command)
    {
        if (command.Incoming < 1)
        {
            throw new InvalidIncomingAmountException(command.Incoming);
        }

        var taxBands = await _taxBandRepository.Get();
        decimal totalTaxAmount = 0;
        foreach (var taxBand in taxBands)
        {
            if (command.Incoming > taxBand.LowRange)
            {
                var taxableBase = Math.Min((decimal) taxBand.HighRange - taxBand.LowRange, (decimal) command.Incoming - taxBand.LowRange);
                totalTaxAmount += taxableBase * ((decimal)taxBand.Range / 100);   
            }
        }

        var grossMonthlySalary = (decimal)command.Incoming / 12;
        var netAnnualSalary = (decimal) command.Incoming - totalTaxAmount;
        var netMonthlySalary = netAnnualSalary / 12;
        var monthlyTax = totalTaxAmount / 12;
        
        return new CalculateTaxCommand.Reply(command.Incoming,
            grossMonthlySalary,
            netAnnualSalary,
            netMonthlySalary,
            totalTaxAmount,
            monthlyTax);
    }
}