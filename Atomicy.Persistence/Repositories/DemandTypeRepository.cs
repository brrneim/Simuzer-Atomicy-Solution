using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.Persistence.Repositories
{
    public class DemandTypeRepository : BaseRepository<DemandType>, IDemandTypeRepository
    {
        public DemandTypeRepository(AtomicyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<DemandType>> GetDemandTypes()
        {
            var allDemandTypes = await _dbContext.DemandTypes.ToListAsync();
            return allDemandTypes;
        }
    }
}
