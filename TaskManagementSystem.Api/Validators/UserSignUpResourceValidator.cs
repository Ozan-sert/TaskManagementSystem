namespace TaskManagementSystem.Api.Validators;

using FluentValidation;
using TaskManagementSystem.Api.Resources;

public class UserSignUpResourceValidator : AbstractValidator<UserSignUpResource>
{
    public UserSignUpResourceValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Must(ContainNonAlphanumeric).WithMessage("Password must contain at least one non-alphanumeric character.")
            .Must(ContainUppercase).WithMessage("Password must contain at least one uppercase letter.");
    }

    private static bool ContainNonAlphanumeric(string password)
    {
        return password.Any(char.IsLetterOrDigit) && !password.All(char.IsLetterOrDigit);
    }

    private static bool ContainUppercase(string password)
    {
        return password.Any(char.IsUpper);
    }
}
