using FluentValidation;
using TaskManagementSystem.Api.Resources;
using TaskManagementSystem.Core.Models;

namespace TaskManagementSystem.Api.Validators;

public class SaveQuoteResourceValidator : AbstractValidator<SaveQuoteResource>
{
    public SaveQuoteResourceValidator()
    {
        RuleFor(resource => resource.QuoteType)
            .NotEmpty()
            .WithMessage("QuoteType is required.")
            .Must(quoteTypeString => Enum.TryParse(typeof(QuoteType), quoteTypeString, true, out _))
            .WithMessage("Invalid QuoteType.");

        RuleFor(resource => resource.Description)
            .MaximumLength(1000)
            .WithMessage("Description must not exceed 1000 characters.");

        RuleFor(resource => resource.DueDate)
            .NotEmpty()
            .Must(date => date >= DateTime.Today)
            .WithMessage("DueDate is required and must be a future date.");

        RuleFor(resource => resource.Premium)
            .GreaterThan(0)
            .WithMessage("Premium must be greater than 0.");

        RuleFor(resource => resource.Sales)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Sales must be a non-negative number.");
    }
}
