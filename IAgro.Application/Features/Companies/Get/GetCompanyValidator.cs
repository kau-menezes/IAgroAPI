namespace IAgro.Application.Features.Companies.Get;

using FluentValidation;

public sealed class GetCompanyValidator : AbstractValidator<GetCompanyRequest>
{
    public GetCompanyValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}