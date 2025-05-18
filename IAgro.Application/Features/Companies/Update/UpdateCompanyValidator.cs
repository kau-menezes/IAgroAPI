using FluentValidation;

namespace IAgro.Application.Features.Companies.Update;

public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRequest>
{
    public UpdateCompanyValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(35);

        RuleFor(c => c.CNPJ)
            .NotEmpty()
            .Length(14);

        RuleFor(c => c.Country)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(35);
    }
}