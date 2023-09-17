using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Demands.Queries.GetDemandList
{
    public class GetDemandListQuery : IRequest<List<DemandListVm>>
    {
        public Guid Id { get; set; }
        public bool IsCustomer { get; set; }
    } 
}
