using MediatR;
using System;
using System.Collections.Generic;

namespace Atomicy.Application.Features.Reservations.Queries.GetReservationList
{
    public class GetReservationListQuery : IRequest<List<ReservationListVm>>
    {
        public Guid Id { get; set; }
        public bool IsUser { get; set; }
    }
}
