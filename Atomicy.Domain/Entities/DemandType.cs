using Atomicy.Domain.Common;
using System;
using System.Collections.Generic;

namespace Atomicy.Domain.Entities
{
    public class DemandType : AuditableEntity
    {
        public Guid DemandTypeId { get; set; }
        public string Name { get; set; }

      //  public ICollection<Demand> Demands { get; set; }
    }
}
