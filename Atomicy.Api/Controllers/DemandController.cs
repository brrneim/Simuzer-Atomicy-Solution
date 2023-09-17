using Atomicy.Application.Features.Demands.Commands.CreateDemand;
using Atomicy.Application.Features.Demands.Queries.GetDemandList;
using Atomicy.Application.Features.Demands.Queries.GetDemandListWithConversation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomicy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DemandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllDemands")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DemandListVm>>> GetAllDemands(bool isCustomer, Guid id)
        {
            GetDemandListQuery getDemandListQuery  = new GetDemandListQuery(){ Id = id, IsCustomer = isCustomer };
            var dtos = await _mediator.Send(getDemandListQuery);
            return Ok(dtos);
        }

        [HttpPost("AddDemand", Name = "AddDemand")]
        public async Task<ActionResult<CreateDemandCommandResponse>> Create([FromBody] CreateDemandCommand createDemandCommand)
        {
            var id = await _mediator.Send(createDemandCommand);
            return Ok(id);
        }

        [HttpGet("DemandDetail",Name = "GetDemandWithConversation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DemandConversationListVm>> GetDemandWithConversations(Guid demandId)
        {
            GetDemandWithConversationsQuery getDemandWithConversationsQuery = new GetDemandWithConversationsQuery() { DemandId = demandId};
            var dtos = await _mediator.Send(getDemandWithConversationsQuery);
            return Ok(dtos);
        }
    }
}
