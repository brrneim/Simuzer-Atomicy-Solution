using MediatR;
using System;

namespace Atomicy.Application.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<Guid>
    {
        public Guid DemandId { get; set; }
        public Guid UserId { get; set; }
        public Guid FirmId { get; set; }
        public string Note { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CarryDate { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"DemandId: {DemandId}; Note: {Note}; UserId: {UserId}; ReservationDate: {ReservationDate.ToShortDateString()}; FirmId: {FirmId}";
        }

    }
}
