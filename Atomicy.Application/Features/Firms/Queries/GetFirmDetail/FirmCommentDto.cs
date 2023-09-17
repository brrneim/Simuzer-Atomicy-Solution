using Atomicy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomicy.Application.Features.Firms.Queries.GetFirmDetail
{
    public class FirmCommentDto
    {
        public Guid FirmCommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid FirmId { get; set; }
        public string Comment { get; set; }

        public Firm Firm { get; set; }
    }
}
