using TaxCalculator.Domain.Models;

namespace TaxCalculator.Domain.Services.Interfaces.Repositories;

public interface ITaxBandRepository
{
    Task<IEnumerable<TaxBand>> Get();
}