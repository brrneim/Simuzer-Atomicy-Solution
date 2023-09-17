using Atomicy.Domain.Common;
using System;
using System.Collections.Generic;

namespace Atomicy.Domain.Entities
{
    public class Demand : AuditableEntity
    {

        public Guid DemandId { get; set; }
        public Guid DemandTypeId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }
        public DateTime DemandDate { get; set; }
        public bool Completed { get; set; }

        //public DemandType DemandType { get; set; }
       // public Customer Customer { get; set; }
        public ICollection<DemandConversation> DemandConversations { get; set; }

    }
}
