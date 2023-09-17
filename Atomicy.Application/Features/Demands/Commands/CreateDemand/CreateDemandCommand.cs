using MediatR;
using System;

namespace Atomicy.Application.Features.Demands.Commands.CreateDemand
{
    public class CreateDemandCommand : IRequest<CreateDemandCommandResponse>
    {
        public Guid DemandTypeId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Note { get; set; }
        public Guid UserId { get; set; }
        public DateTime DemandDate { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"DemandTypeId: {DemandTypeId}; From: {From}; To: {To}; DemandDate: {DemandDate.ToShortDateString()}; Note: {Note}";
        }


    }
}
