using Atomicy.Application.Contracts.Persistence;
using Atomicy.Application.Exceptions;
using Atomicy.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Atomicy.Application.Features.Firms.Queries.GetFirmList
{
    public class GetFirmListQueryHandler : IRequestHandler<GetFirmListQuery, List<FirmVm>>
    {
        private readonly IAsyncRepository<Firm> _firmRepository;
        private readonly IMapper _mapper;

        public GetFirmListQueryHandler(IMapper mapper, IAsyncRepository<Firm> firmRepository)
        {
            _mapper = mapper;
            _firmRepository = firmRepository;
        }

        public async Task<List<FirmVm>> Handle(GetFirmListQuery request, CancellationToken cancellationToken)
        {
            var firms = (await _firmRepository.ListAllAsync());
            var firmListVm = new List<FirmVm>();
            foreach (var firm in firms)
            {
                firmListVm.Add(new FirmVm()
                {
                    FirmId = firm.FirmId,
                    FirmName = firm.FirmName
                });
            }
            return firmListVm;
        }        
    }
}
