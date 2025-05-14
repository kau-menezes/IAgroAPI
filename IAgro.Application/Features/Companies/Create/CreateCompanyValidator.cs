using FluentValidation;

namespace IAgro.Application.Features.Companies.Create;

public class CreateCompanyValidator : AbstractValidator<CreateCompanyRequest>
{
    public CreateCompanyValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2).MaximumLength(35);
    }
}