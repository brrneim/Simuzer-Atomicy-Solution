using Atomicy.Application.Responses;


namespace Atomicy.Application.Features.Demands.Commands.CreateDemand
{
    public class CreateDemandCommandResponse: BaseResponse
    {
        public CreateDemandCommandResponse(): base()
        {

        }

        public CreateDemandDto Demand { get; set; }
    }
}