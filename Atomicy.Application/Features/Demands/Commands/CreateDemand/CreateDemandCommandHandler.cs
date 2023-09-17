using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Atomicy.Application.Features.Demands.Commands.CreateDemand
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, CreateDemandCommandResponse>
    {

        private readonly IAsyncRepository<Demand> _demandRepository;
        private readonly IMapper _mapper;

       
        public CreateDemandCommandHandler(IAsyncRepository<Demand> demandRepository, IMapper mapper)
        {
            _demandRepository = demandRepository;
            _mapper = mapper;
        }

        public async Task<CreateDemandCommandResponse> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            var createDemandCommandResponse = new CreateDemandCommandResponse();

            var validator = new CreateDemandCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createDemandCommandResponse.Success = false;
                createDemandCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDemandCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createDemandCommandResponse.Success)
            {
                Demand demand = new Demand
                {
                    UserId = request.UserId,
                    Completed = request.Completed,
                    DemandTypeId = request.DemandTypeId,
                    DemandDate = request.DemandDate,
                    From = request.From,
                    To = request.To,
                    Note = request.Note
                };

                @demand = await _demandRepository.AddAsync(demand);
                createDemandCommandResponse.Demand = new CreateDemandDto() { DemandId = @demand.DemandId };
            }

            return createDemandCommandResponse;           
        }
    }
}
