using Atomicy.Domain.Common;
using System;

namespace Atomicy.Domain.Entities
{
    public class FirmVehicle : AuditableEntity
    {
        public Guid FirmVehicleId { get; set; }
        public Guid FirmId { get; set; }
        public string Plate { get; set; }
        public string DriverName { get; set; }
        public int DriverExperience { get; set; }
        public string DriverNote { get; set; }
        public Firm Firm { get; set; }
    }
}
