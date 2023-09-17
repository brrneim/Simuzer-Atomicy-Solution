using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simuzer.Atomicy.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<DemandType>> GetDemandTypeRepository()
        {
            var homeGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var furnitureGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var officeGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");            

            var demandTypes = new List<DemandType>
            {
                new DemandType
                {
                    DemandTypeId = homeGuid,
                    Name ="Evimi Taşı"
                },
                new DemandType
                {
                    DemandTypeId = furnitureGuid,
                    Name = "Parça Eşyamı Taşı"
                },
                new DemandType
                {
                    DemandTypeId = officeGuid,
                    Name = "Ofisimi Taşı"
                }
            };

            var mockDemandTypeRepository = new Mock<IAsyncRepository<DemandType>>();
            mockDemandTypeRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(demandTypes);

            mockDemandTypeRepository.Setup(repo => repo.AddAsync(It.IsAny<DemandType>())).ReturnsAsync(
                (DemandType demandType) =>
                {
                    demandTypes.Add(demandType);
                    return demandType;
                });

            return mockDemandTypeRepository;
        }
    }
}
