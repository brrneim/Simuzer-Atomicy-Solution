using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.Application.Contracts.Persistence
{
    public interface IDemandRepository : IAsyncRepository<Demand>
    {
        Task<List<Demand>> GetDemandWithConversations(Guid demandId);
        Task<List<Demand>> GetDemands();
    }
}
