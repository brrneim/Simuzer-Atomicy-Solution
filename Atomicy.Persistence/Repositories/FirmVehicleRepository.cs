using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Persistence.Repositories
{
    public class FirmVehicleRepository : BaseRepository<FirmVehicle>, IFirmVehicleRepository
    {
        public FirmVehicleRepository(AtomicyDbContext dbContext) : base(dbContext)
        {

        }

    }
}
