using System;

namespace Atomicy.Application.Features.Demands.Queries.GetDemandList
{
    public class DemandListVm
    {
        public Guid DemandId { get; set; }
        public Guid DemandTypeId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }
        public DateTime DemandDate { get; set; }
        public bool Completed { get; set; }

    }
}
