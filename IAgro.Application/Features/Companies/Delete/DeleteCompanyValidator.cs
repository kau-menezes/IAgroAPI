using FluentValidation;

namespace IAgro.Application.Features.Companies.Delete;

public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyRequest>
{
    public DeleteCompanyValidator()
    {
        RuleFor(c => c.Id);
    }
}