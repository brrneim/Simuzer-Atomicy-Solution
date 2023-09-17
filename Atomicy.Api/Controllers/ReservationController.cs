using Atomicy.Application.Features.Reservations.Commands.CreateReservation;
using Atomicy.Application.Features.Reservations.Queries.GetReservationList;
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
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllReservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ReservationListVm>>> GetAllReservations(bool isUser, Guid id)
        {
            var dtos = await _mediator.Send(new GetReservationListQuery() { Id= id, IsUser= isUser });
            return Ok(dtos);
        }

        [HttpPost("AddReservation", Name = "AddReservation")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReservationCommand createReservationCommand)
        {
            var id = await _mediator.Send(createReservationCommand);
            return Ok(id);
        }
    }
}
