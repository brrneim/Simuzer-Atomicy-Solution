using Atomicy.Application.Contracts.Persistence;
using Atomicy.Application.Features.DemandTypes.Queries.GetDemandTypeList;
using Atomicy.Application.Profiles;
using Atomicy.Domain.Entities;
using AutoMapper;
using Moq;
using Shouldly;
using Simuzer.Atomicy.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Simuzer.Atomicy.Application.UnitTests.DemandTypes.Queries
{
    public class GetDemandTypesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<DemandType>> _mockDemandTypeRepository;

        public GetDemandTypesListQueryHandlerTests()
        {
            _mockDemandTypeRepository = RepositoryMocks.GetDemandTypeRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetDemandTypeListTest()
        {
            var handler = new GetDemandTypeListQueryHandler(_mapper, _mockDemandTypeRepository.Object);

            var result = await handler.Handle(new GetDemandTypeListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<DemandTypeListVm>>();

            result.Count.ShouldBe(3);
        }
    }
}
