using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain.Models;
using TaxCalculator.Domain.Services.Interfaces.Repositories;

namespace TaxCalculator.DataAccess.SqlDb.Repositories
{
    public class TaxBandSqlRepository : ITaxBandRepository
    {
        private readonly TaxDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaxBandSqlRepository(TaxDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaxBand>> Get()
        {
            var taxEntities = await _dbContext.TaxBands
                .Where(b => b.IsActive)
                .ToListAsync();
            
            return _mapper.Map<List<DbModels.TaxBand>, List<TaxBand>>(taxEntities);
        }
    }
}
