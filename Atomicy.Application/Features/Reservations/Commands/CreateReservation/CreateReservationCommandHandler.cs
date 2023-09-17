using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Atomicy.Application.Features.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
    {

        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateReservationCommandHandler> _logger;
        public CreateReservationCommandHandler(IMapper mapper, IReservationRepository reservationRepository, ILogger<CreateReservationCommandHandler> logger)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateDemandCommandValidator(_eventRepository);
            //var validationResult = await validator.ValidateAsync(request);

            //if (validationResult.Errors.Count > 0)
            //    throw new Exceptions.ValidationException(validationResult);
            Reservation reservation = new Reservation
            {
                DemandId = request.DemandId,
                UserId  = request.UserId,
                FirmId = request.FirmId,
                Note  = request.Note,
                ReservationDate = request.ReservationDate, 
                Completed = request.Completed,
                CarryDate = request.CarryDate                      
            };

            @reservation = await _reservationRepository.AddAsync(reservation);

            return @reservation.ReservationId;
        }
    }
}
