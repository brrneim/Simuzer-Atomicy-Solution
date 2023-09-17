using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomicy.Persistence.Repositories
{
    public class FirmRepository : BaseRepository<Firm>, IFirmRepository
    {
        public FirmRepository(AtomicyDbContext dbContext) : base(dbContext)
        {

        }
      
    }
}
