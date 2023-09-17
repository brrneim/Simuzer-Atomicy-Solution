using Atomicy.Application.Contracts;
using Atomicy.Domain.Entities;
using Atomicy.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace Simuzer.Atomicy.Persistence.IntegrationTests
{
    public class AtomicyDbContextTests
    {
        private readonly AtomicyDbContext _atomicyDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public AtomicyDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<AtomicyDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _atomicyDbContext = new AtomicyDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var demand = new Demand() { DemandId = Guid.NewGuid(), DemandTypeId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"), CreatedBy = "00000000-0000-0000-0000-000000000000" };

            _atomicyDbContext.Demands.Add(demand);
            await _atomicyDbContext.SaveChangesAsync();

            demand.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
