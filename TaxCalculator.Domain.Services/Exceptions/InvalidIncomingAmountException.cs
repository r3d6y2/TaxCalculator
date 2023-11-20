namespace TaxCalculator.Domain.Services.Exceptions;

public class InvalidIncomingAmountException : Exception
{
    public InvalidIncomingAmountException(double incomingAmount)
        : base($"IncomingAmount cannot be less than 1. Current IncomingAmount {incomingAmount}")
    {
        IncomingAmount = incomingAmount;
    }
    
    public double IncomingAmount { get; }
}