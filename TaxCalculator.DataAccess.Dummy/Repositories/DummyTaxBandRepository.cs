using TaxCalculator.Domain.Models;
using TaxCalculator.Domain.Services.Interfaces.Repositories;

namespace TaxCalculator.DataAccess.Dummy.Repositories;

public class DummyTaxBandRepository : ITaxBandRepository
{
    public async Task<IEnumerable<TaxBand>> Get()
    {
        return new[]
        {
            new TaxBand("Tax Band A", 0, 5000, 0),
            new TaxBand("Tax Band B", 5000, 20000, 20),
            new TaxBand("Tax Band C", 20000, int.MaxValue, 40)
        };
    }
}