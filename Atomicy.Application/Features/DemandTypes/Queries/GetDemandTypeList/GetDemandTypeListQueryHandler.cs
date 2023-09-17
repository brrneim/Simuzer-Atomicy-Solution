using AutoMapper;
using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Atomicy.Application.Features.DemandTypes.Queries.GetDemandTypeList
{
    public class GetDemandTypeListQueryHandler : IRequestHandler<GetDemandTypeListQuery, List<DemandTypeListVm>>
    {
        private readonly IAsyncRepository<DemandType> _demandTypeRepository;
        private readonly IMapper _mapper;

        public GetDemandTypeListQueryHandler(IMapper mapper, IAsyncRepository<DemandType> demandTypeRepository)
        {
            _mapper = mapper;
            _demandTypeRepository = demandTypeRepository;
        }

        public async Task<List<DemandTypeListVm>> Handle(GetDemandTypeListQuery request, CancellationToken cancellationToken)
        {
            var demandTypes = (await _demandTypeRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<DemandTypeListVm>>(demandTypes);
        }
    }
}
