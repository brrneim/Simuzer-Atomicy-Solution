using Atomicy.Application.Features.DemandTypes.Queries.GetDemandTypeList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DemandTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("all", Name = "GetAllDemandTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]       
        public async Task<ActionResult<List<DemandTypeListVm>>> GetAllDemandTypes()
        {
            var dtos = await _mediator.Send(new GetDemandTypeListQuery());
            return Ok(dtos);
        }    
    }
}
