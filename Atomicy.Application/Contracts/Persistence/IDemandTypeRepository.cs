using Atomicy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.Application.Contracts.Persistence
{
    public interface IDemandTypeRepository : IAsyncRepository<DemandType>
    {
        Task<List<DemandType>> GetDemandTypes();
    }
}
