using Atomicy.Domain.Common;
using System;

namespace Atomicy.Domain.Entities
{
    public class FirmComment : AuditableEntity
    {
        public Guid FirmCommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid FirmId { get; set; }
        public string Comment { get; set; }
        public Firm Firm { get; set; }
      
    }
}

