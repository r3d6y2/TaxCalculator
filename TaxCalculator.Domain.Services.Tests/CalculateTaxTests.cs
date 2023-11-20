using TaxCalculator.Domain.Services.Interfaces.Repositories;
using Moq;
using TaxCalculator.Domain.Models;
using TaxCalculator.Domain.Services.Commands;
using TaxCalculator.Domain.Services.Commands.Handlers;
using TaxCalculator.Domain.Services.Exceptions;
using TaxCalculator.Domain.Services.Interfaces;

namespace TaxCalculator.Domain.Services.Tests;

public class Tests
{
    private Mock<ITaxBandRepository> _taxBandRepositoryMock;
    private IList<TaxBand> _taxBands;
    
    [SetUp]
    public void Setup()
    {
        _taxBandRepositoryMock = new Mock<ITaxBandRepository>();
        _taxBands = new List<TaxBand>
        {
            new TaxBand("Tax Band A", 0, 5000, 0),
            new TaxBand("Tax Band B", 5000, 20000, 20),
            new TaxBand("Tax Band C", 20000, int.MaxValue, 40)
        };
    }

    [Test]
    public async Task TaxCalculatesSuccessfully()
    {
        // Arrange
        var incomingSalary = 40000d;
        var expectedNetAnnualSalary = 29000m;
        var expectedNetMonthlySalary = 2416.666m;
        var expectedAnnualTax = 11000m;
        var expectedMonthlyTax = 916.666m;
        _taxBandRepositoryMock.Setup(repo => repo.Get())
            .ReturnsAsync(_taxBands);
        var taxCalculationCommand = new CalculateTaxCommand(incomingSalary);
        ICommandHandler<CalculateTaxCommand, CalculateTaxCommand.Reply> handler = new CalculateTaxHandler(_taxBandRepositoryMock.Object);
        
        // Act
        var taxCalculationResult = await handler.Handle(taxCalculationCommand);
        
        // Assert
        Assert.That(taxCalculationResult.GrossAnnualSalary, Is.EqualTo(incomingSalary));
        Assert.That(taxCalculationResult.GrossMonthlySalary, Is.EqualTo((decimal)incomingSalary / 12).Within(0.001m));
        Assert.That(taxCalculationResult.NetAnnualSalary, Is.EqualTo(expectedNetAnnualSalary).Within(0.001m));
        Assert.That(taxCalculationResult.NetMonthlySalary, Is.EqualTo(expectedNetMonthlySalary).Within(0.001m));
        Assert.That(taxCalculationResult.AnnualTax, Is.EqualTo(expectedAnnualTax).Within(0.001m));
        Assert.That(taxCalculationResult.MonthlyTax, Is.EqualTo(expectedMonthlyTax).Within(0.001m));
    }
    
    [Test]
    public async Task TaxCalculatesThrowsInvalidIncomingSalary()
    {
        // Arrange
        _taxBandRepositoryMock.Setup(repo => repo.Get())
            .ReturnsAsync(_taxBands);
        var taxCalculationCommand = new CalculateTaxCommand(0);
        ICommandHandler<CalculateTaxCommand, CalculateTaxCommand.Reply> handler = new CalculateTaxHandler(_taxBandRepositoryMock.Object);
        
        // Act
        var invalidIncomingAmountException = Assert.ThrowsAsync<InvalidIncomingAmountException>(() => handler.Handle(taxCalculationCommand));
        
        // Assert
        Assert.IsNotNull(invalidIncomingAmountException);
    }
}