using FluentValidation;

namespace User.Application.Features.Commands.UpdateUser
{
    class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.Id)
              .NotEmpty().WithMessage("{Id} is required.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(80).WithMessage("{Name} must not exceed 80 characters.");

            RuleFor(p => p.EmailAddress)
              .NotEmpty().WithMessage("{EmailAddress} is required.")
              .EmailAddress().WithMessage("A valid email is required");

            RuleFor(p => p.Age)
               .NotEmpty().WithMessage("{Age} is required.");

        }
    }
}
