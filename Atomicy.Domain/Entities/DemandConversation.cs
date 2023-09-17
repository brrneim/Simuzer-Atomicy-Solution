using Atomicy.Domain.Common;
using System;

namespace Atomicy.Domain.Entities
{
    public class DemandConversation : AuditableEntity
    {
        public Guid DemandConversationId { get; set; }
        public Guid DemandId { get; set; }
        public Guid FirmId { get; set; }
        public Guid UserId { get; set; }
        public string FirmMessage { get; set; }
        public string CustomerMessage { get; set; }
        public bool Read { get; set; }
        public DateTime Date { get; set; }
    }
}
