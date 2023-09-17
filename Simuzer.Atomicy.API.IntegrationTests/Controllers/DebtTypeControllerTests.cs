using Atomicy.Api;
using Atomicy.Application.Features.DemandTypes.Queries.GetDemandTypeList;
using Newtonsoft.Json;
using Simuzer.Atomicy.API.IntegrationTests.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Simuzer.Atomicy.API.IntegrationTests.Controllers
{

    public class DebtTypeControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DebtTypeControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/DemandType/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<DemandTypeListVm>>(responseString);
            
            Assert.IsType<List<DemandTypeListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
