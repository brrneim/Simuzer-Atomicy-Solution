using Atomicy.Domain.Entities;

namespace Atomicy.Application.Contracts.Persistence
{
    public interface IFirmRepository : IAsyncRepository<Firm>
    {
      //  Task<List<Firm>> GetFirmWithVehiclesAndComments(Guid firmId);        
    }
}
