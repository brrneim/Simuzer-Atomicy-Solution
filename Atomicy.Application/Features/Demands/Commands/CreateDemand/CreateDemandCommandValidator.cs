using FluentValidation;

namespace Atomicy.Application.Features.Demands.Commands.CreateDemand
{
    public class CreateDemandCommandValidator : AbstractValidator<CreateDemandCommand>
    {
        public CreateDemandCommandValidator()
        {
            RuleFor(p => p.To)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.From)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        }
    }
}
