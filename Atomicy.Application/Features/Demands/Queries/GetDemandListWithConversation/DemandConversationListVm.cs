using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Demands.Queries.GetDemandListWithConversation
{
    public class DemandConversationListVm
    {
        public Guid DemandId { get; set; }
        public Guid DemandTypeId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }
        public DateTime DemandDate { get; set; }
        public bool Completed { get; set; }
        public ICollection<DemandConversationDto> Conversations { get; set; }
    }
}

