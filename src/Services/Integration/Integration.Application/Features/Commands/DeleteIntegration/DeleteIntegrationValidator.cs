using FluentValidation;

namespace Integration.Application.Features.Commands.DeleteIntegration
{
    public class DeleteIntegrationValidator : AbstractValidator<DeleteIntegrationCommand>
    {
        public DeleteIntegrationValidator()
        {
            RuleFor(p => p.Id)
             .NotEmpty().WithMessage("{Id} is required.");
        }
    }
}
