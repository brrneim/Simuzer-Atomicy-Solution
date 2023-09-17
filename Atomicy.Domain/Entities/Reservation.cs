using Atomicy.Domain.Common;
using System;

namespace Atomicy.Domain.Entities
{
    public class Reservation : AuditableEntity
    {
        public Guid ReservationId { get; set; }
        public Guid DemandId { get; set; }
        public Guid UserId { get; set; }
        public Guid FirmId { get; set; }
        public string Note { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool Completed { get; set; }
        public DateTime CarryDate { get; set; }
        public Demand Demand { get; set; }
        public Firm Firm { get; set; }

    }
}
