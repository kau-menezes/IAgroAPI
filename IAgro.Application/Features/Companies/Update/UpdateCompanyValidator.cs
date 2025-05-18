using FluentValidation;

namespace IAgro.Application.Features.Companies.Update;

public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRequest>
{
    public UpdateCompanyValidator()
    {
        RuleFor(c => c.Props.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(35);

        RuleFor(c => c.Props.CNPJ)
            .NotEmpty()
            .Length(14);

        RuleFor(c => c.Props.Country)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(35);
    }
}