using FluentValidation;

namespace IAgro.Application.Features.CropsData.Create;

public class CreateCropDataValidator : AbstractValidator<CreateCropDataRequest>
{
    public CreateCropDataValidator()
    {
        RuleForEach(cd => cd.DiseaseCoords);
    }
}