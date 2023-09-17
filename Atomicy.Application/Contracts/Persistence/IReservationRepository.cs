using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.Application.Contracts.Persistence
{
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
        Task<List<Reservation>> GetReservations(Guid Id, bool IsUser);        
    }
}
