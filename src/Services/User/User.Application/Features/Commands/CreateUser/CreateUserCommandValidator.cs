using FluentValidation;

namespace User.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
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
