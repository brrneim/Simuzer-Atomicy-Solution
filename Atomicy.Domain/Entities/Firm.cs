using Atomicy.Domain.Common;
using System;

namespace Atomicy.Domain.Entities
{
    public class Firm : AuditableEntity
    {       
        public Guid FirmId { get; set; }
        public string FirmName { get; set; }
        public int VanCount{ get; set; }
        public int TruckCount { get; set; }
        public int BigTruckCount { get; set; }
        public string Note { get; set; }
    }
}
