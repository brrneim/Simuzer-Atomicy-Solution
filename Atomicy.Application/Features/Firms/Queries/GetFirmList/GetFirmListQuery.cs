using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Firms.Queries.GetFirmList
{
    public class GetFirmListQuery : IRequest<List<FirmVm>>
    {
    }
}
