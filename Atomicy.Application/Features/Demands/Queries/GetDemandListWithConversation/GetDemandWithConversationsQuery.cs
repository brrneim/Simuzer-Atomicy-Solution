using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Demands.Queries.GetDemandListWithConversation
{
    public class GetDemandWithConversationsQuery : IRequest<DemandConversationListVm>
    {
        public Guid DemandId { get; set; }
    } 
}
