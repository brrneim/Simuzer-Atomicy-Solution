using AutoMapper;
using Atomicy.Application.Contracts.Persistence;
using Atomicy.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Atomicy.Application.Features.Reservations.Queries.GetReservationList
{
    public class GetReservationListQueryHandler : IRequestHandler<GetReservationListQuery, List<ReservationListVm>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationListQueryHandler(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<List<ReservationListVm>> Handle(GetReservationListQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservations(request.Id, request.IsUser);
            var reservationList = new List<ReservationListVm>();
            foreach (var reservation in reservations)
            {
                reservationList.Add(new ReservationListVm()
                {
                    Note = reservation.Note,
                    ReservationDate = reservation.ReservationDate,
                    FirmId = reservation.FirmId,
                    UserId = reservation.UserId,
                    DemandId = reservation.DemandId,
                    ReservationId = reservation.ReservationId
                });
            }
            return reservationList;
        }
    }

}