//using Atomicy.Application.Features.Categories.Commands.CreateCateogry;
using Atomicy.Application.Features.Firms.Queries.GetFirmDetail;
using Atomicy.Application.Features.Firms.Queries.GetFirmList;
//using Atomicy.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
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
    public class FirmController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FirmController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("FirmDetail", Name = "GetFirmDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FirmDetailVm>> GetFirmDetail(Guid firmId)
        {
            GetFirmDetailQuery getDemandWithConversationsQuery = new GetFirmDetailQuery() { Id = firmId };
            var dtos = await _mediator.Send(getDemandWithConversationsQuery);
            return Ok(dtos);
        }

        [HttpGet("all", Name = "GetAllFirms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FirmVm>>> GetAllFirms()
        {
            var dtos = await _mediator.Send(new GetFirmListQuery());
            return Ok(dtos);
        }
    }
}
