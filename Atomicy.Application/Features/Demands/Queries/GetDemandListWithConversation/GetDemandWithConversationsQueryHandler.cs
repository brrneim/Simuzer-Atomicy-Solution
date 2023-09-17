using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Atomicy.Application.Features.Demands.Queries.GetDemandListWithConversation
{
    public class GetDemandWithConversationsQueryHandler : IRequestHandler<GetDemandWithConversationsQuery, DemandConversationListVm>
    {
        private readonly IDemandRepository  _demandRepository;
        private readonly IMapper _mapper;

        public GetDemandWithConversationsQueryHandler(IMapper mapper, IDemandRepository demandRepository)
        {
            _mapper = mapper;
            _demandRepository = demandRepository;
        }

        public async Task<DemandConversationListVm> Handle(GetDemandWithConversationsQuery request, CancellationToken cancellationToken)
        {
            var list = await _demandRepository.GetDemandWithConversations(request.DemandId);
            if(list.Count> 0)
            {
                var demand = list.FirstOrDefault();
                DemandConversationListVm demandConversationListVm = new DemandConversationListVm()
                {
                    DemandId = request.DemandId,
                    DemandTypeId = demand.DemandTypeId,
                    Completed = demand.Completed,
                    DemandDate = demand.DemandDate,
                    From = demand.From,
                    Note = demand.Note,
                    To = demand.To,
                    UserId = demand.UserId//,

                   // Conversations = ConvertDto(demand.DemandConversations) 
                };
                return demandConversationListVm;
            }
            else
            {
                return new DemandConversationListVm();
            }
        }

        private ICollection<DemandConversationDto> ConvertDto(ICollection<DemandConversation> demandConversations)
        {
            var conversations = new List<DemandConversationDto>();
            foreach (var conversation in demandConversations)
            {
                conversations.Add(new DemandConversationDto()
                {
                    UserId = conversation.UserId,
                    CustomerMessage = conversation.CustomerMessage,
                    Date = conversation.Date,
                    DemandConversationId = conversation.DemandConversationId,
                    DemandId = conversation.DemandId,
                    FirmMessage = conversation.FirmMessage,
                    FirmId = conversation.FirmId,
                    Read = conversation.Read
                });
            }
            return conversations;
        }
    }
}
