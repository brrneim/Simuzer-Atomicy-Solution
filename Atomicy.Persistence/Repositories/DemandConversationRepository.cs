using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomicy.Persistence.Repositories
{
    public class DemandConversationRepository : BaseRepository<DemandConversation>, IDemandConversationRepository
    {
        public DemandConversationRepository(AtomicyDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<DemandConversation>> GetDemandConversation()
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Demand>> GetDemands()
        //{
        //    var allDemands = await _dbContext.Demands.ToListAsync();
        //    return allDemands;
        //}
    }
    
}
