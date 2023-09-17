using System;

namespace Atomicy.Application.Features.Demands.Queries.GetDemandListWithConversation
{
    public class DemandConversationDto
    {
        public Guid DemandId { get; set; }
        public Guid DemandConversationId { get; set; }
        public Guid UserId { get; set; }
        public Guid FirmId { get; set; }
        public string CustomerMessage { get; set; }
        public string FirmMessage { get; set; }
        public DateTime Date { get; set; }
        public bool Read { get; set; }

    }
}
