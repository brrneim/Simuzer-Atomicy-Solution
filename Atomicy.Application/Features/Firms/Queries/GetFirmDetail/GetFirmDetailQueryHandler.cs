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

namespace Atomicy.Application.Features.Firms.Queries.GetFirmDetail
{
    public class GetFirmDetailQueryhandler : IRequestHandler<GetFirmDetailQuery, FirmDetailVm>
    {
        private readonly IAsyncRepository<Firm> _firmRepository;
        private readonly IAsyncRepository<FirmComment> _firmCommentRepository;
        private readonly IAsyncRepository<FirmVehicle> _firmVehicleRepository;
        private readonly IMapper _mapper;

        public GetFirmDetailQueryhandler(IMapper mapper, IAsyncRepository<Firm> firmRepository,
            IAsyncRepository<FirmComment> firmCommentRepository,
            IAsyncRepository<FirmVehicle> firmVehicleRepository)
        {
            _mapper = mapper;
            _firmRepository = firmRepository;
            _firmCommentRepository = firmCommentRepository;
            _firmVehicleRepository = firmVehicleRepository;
        }

        public async Task<FirmDetailVm> Handle(GetFirmDetailQuery request, CancellationToken cancellationToken)
        {
            var firm = await _firmRepository.GetByIdAsync(request.Id);

            var firmDetailDto = new FirmDetailVm()
            {
                FirmId = firm.FirmId,
                Name = firm.FirmName,
                VanCount = firm.VanCount,
                TruckCount = firm.TruckCount,
                BigTruckCount = firm.BigTruckCount,
                Note = firm.Note,
            };

            var firmComments = (await _firmCommentRepository.ListAllAsync()).Where(x=>x.FirmId == request.Id);
            
            if (firmComments == null)
            {
                throw new NotFoundException(nameof(Firm), request.Id);
            }
            firmDetailDto.FirmCommentDtos = ConvertToFirmCommentDto(firmComments.ToList());

            var firmVehicles = (await _firmVehicleRepository.ListAllAsync()).Where(x => x.FirmId == request.Id);
            if (firmVehicles == null)
            {
                throw new NotFoundException(nameof(Firm), request.Id);
            }
            firmDetailDto.FirmVehicleDtos = ConvertToFirmVehicleDto(firmVehicles.ToList());

            return firmDetailDto;
        }

        private ICollection<FirmVehicleDto> ConvertToFirmVehicleDto(List<FirmVehicle> firmVehicles)
        {
            List<FirmVehicleDto> vehicles = new List<FirmVehicleDto>();
            foreach (var vehicle in firmVehicles)
            {
                vehicles.Add(new FirmVehicleDto()
                {
                    FirmVehicleId = vehicle.FirmVehicleId,
                    DriverName = vehicle.DriverName,
                    DriverExperience = vehicle.DriverExperience,
                    DriverNote = vehicle.DriverNote,
                    Plate = vehicle.Plate                    
                });
            }
            return vehicles;
        }

        private ICollection<FirmCommentDto> ConvertToFirmCommentDto(List<FirmComment> firmComments)
        {
            List<FirmCommentDto> comments = new List<FirmCommentDto>();
             foreach (var comment in firmComments)
            {
                comments.Add(new FirmCommentDto() { 
                 FirmCommentId = comment.FirmCommentId,
                 Comment = comment.Comment,
                 FirmId = comment.FirmId,
                 UserId = comment.UserId
                });
            }
            return comments;
        }
    }
}
