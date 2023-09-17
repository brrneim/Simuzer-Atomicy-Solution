using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Firms.Queries.GetFirmDetail
{
    public class GetFirmDetailQuery : IRequest<FirmDetailVm>
    {
        public Guid Id { get; set; }
    }
}
