using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomicy.Application.Contracts.Persistence
{
    public interface IDemandConversationRepository : IAsyncRepository<DemandConversation>
    {
        Task<List<DemandConversation>> GetDemandConversation();
    }
    
}
