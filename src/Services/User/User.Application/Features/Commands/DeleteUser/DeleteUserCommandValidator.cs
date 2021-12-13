using FluentValidation;

namespace User.Application.Features.Commands.DeleteUser
{
    class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(p => p.Id)
             .NotEmpty().WithMessage("{Id} is required.");
        }
    }
}
