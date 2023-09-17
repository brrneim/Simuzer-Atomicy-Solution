using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Atomicy.Application.Features.Demands.Queries.GetDemandListWithConversation;

namespace Atomicy.Persistence.Repositories
{
    public class DemandRepository : BaseRepository<Demand>, IDemandRepository
    {
        public DemandRepository(AtomicyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Demand>> GetDemands()
        {
            var allDemands = await _dbContext.Demands.ToListAsync();
            return allDemands;
        }

        public async Task<List<Demand>> GetDemandWithConversations(Guid demandId)
        {
            var demandWithConversation = await _dbContext.Demands.Include(x => x.DemandConversations).ToListAsync();
            return demandWithConversation.Where(p => p.DemandId == demandId).ToList();
        }
    }
}
