using FluentValidation;

namespace IAgro.Application.Features.CropsData.Delete;

public class DeleteCropDataValidator : AbstractValidator<DeleteCropDataRequest>
{
    public DeleteCropDataValidator()
    {
        RuleFor(cd => cd.Id);
    }
}