using FluentValidation;
using FluentValidation.Validators;
using lawyerSystem.api.Core.Dtos.Role;

namespace lawyerSystem.api.Core.Validators;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name is required.")
            .MinimumLength(3).WithMessage("Role name must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.");
    }
}
