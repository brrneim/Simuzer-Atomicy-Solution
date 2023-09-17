using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atomicy.Persistence.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AtomicyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Reservation>> GetReservations(Guid Id, bool IsUser)
        {
          return await _dbContext.Reservations.Where(x => !x.Completed 
          && (!IsUser || x.UserId == Id) 
          && (IsUser || x.FirmId == Id))
               .OrderBy(x => x.ReservationDate).AsNoTracking().ToListAsync();
        }
    }
}
