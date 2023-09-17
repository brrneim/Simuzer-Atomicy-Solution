using Atomicy.Domain.Entities;
using System;

namespace Atomicy.Application.Features.Reservations.Queries.GetReservationList
{
    public class ReservationListVm
    {
        public Guid ReservationId { get; set; }
        public Guid DemandId { get; set; }
        public Guid UserId { get; set; }
        public Guid FirmId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Note { get; set; }

        public Firm Firm { get; set; }
        public Demand Demand { get; set; }
    }
}
