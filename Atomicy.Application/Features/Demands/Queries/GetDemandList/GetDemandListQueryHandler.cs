using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Atomicy.Application.Features.Demands.Queries.GetDemandList
{
    public class GetDemandListQueryHandler : IRequestHandler<GetDemandListQuery, List<DemandListVm>>
    {
        private readonly IAsyncRepository<Demand> _demandRepository;
        private readonly IMapper _mapper;

        public GetDemandListQueryHandler(IMapper mapper, IAsyncRepository<Demand> demandRepository)
        {
            _mapper = mapper;
            _demandRepository = demandRepository;
        }

        public async Task<List<DemandListVm>> Handle(GetDemandListQuery request, CancellationToken cancellationToken)
        {
            var demands = (await _demandRepository.ListAllAsync())
                    .Where(x => !x.Completed && (!request.IsCustomer || x.UserId == request.Id))
                    .OrderBy(x => x.DemandDate);
            var demandList = new List<DemandListVm>();
            foreach (var demand in demands)
            {
                demandList.Add(new DemandListVm()
                {
                     Note = demand.Note,
                     From = demand.From,
                     To = demand.To,
                     UserId = demand.UserId,
                     DemandDate = demand.DemandDate,
                     DemandId = demand.DemandId,
                     DemandTypeId = demand.DemandTypeId,
                     Completed = demand.Completed
                });
            }
            return demandList;
        }
    }
}
