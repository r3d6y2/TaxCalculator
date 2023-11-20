namespace TaxCalculator.Domain.Services.Interfaces;

public interface ICommandHandler<in TCommand, TResult>
{
    Task<TResult> Handle(TCommand command);
}