using MediatR;
using System.Collections.Generic;

namespace Atomicy.Application.Features.DemandTypes.Queries.GetDemandTypeList
{
    public class GetDemandTypeListQuery : IRequest<List<DemandTypeListVm>>
    {
    }
}
