using FluentValidation;
using TaskManagementSystem.Api.Resources;

namespace TaskManagementSystem.Api.Validators;

public class UserLoginResourceValidator : AbstractValidator<UserLoginResource>
{
    public UserLoginResourceValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}