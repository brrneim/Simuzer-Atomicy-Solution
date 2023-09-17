using Atomicy.Domain.Entities;
using Atomicy.Persistence;
using System;

namespace Simuzer.Atomicy.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(AtomicyDbContext context)
        {
            var homeGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var furnitureGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var officeGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            context.DemandTypes.Add(new DemandType
            {
                DemandTypeId = homeGuid,
                Name = "Evimi Taşı"
            });
            context.DemandTypes.Add(new DemandType
            {
                DemandTypeId = furnitureGuid,
                Name = "Parça Eşyamı Taşı"
            });
            context.DemandTypes.Add(new DemandType
            {
                DemandTypeId = officeGuid,
                Name = "Ofisimi Taşı"
            });
          
            context.SaveChanges();
        }
    }
}
