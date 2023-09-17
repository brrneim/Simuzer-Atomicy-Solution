using Atomicy.Application.Features.Demands.Commands.CreateDemand;
using Atomicy.Application.Features.Demands.Queries.GetDemandList;
using Atomicy.Application.Features.DemandTypes.Queries.GetDemandTypeList;
using Atomicy.Application.Features.Firms.Queries.GetFirmDetail;
using Atomicy.Application.Features.Reservations.Queries.GetReservationList;
//using Atomicy.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

using Atomicy.Domain.Entities;
using AutoMapper;

namespace Atomicy.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<DemandType, DemandTypeListVm>();
            CreateMap<Reservation, ReservationListVm>();
            CreateMap<Firm, FirmDetailVm>();
            CreateMap<Demand, DemandListVm>();
            CreateMap<Demand, CreateDemandCommand>();
            CreateMap<Demand, CreateDemandDto>();
        }
    }
}
