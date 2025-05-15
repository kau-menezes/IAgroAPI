using FluentValidation;

namespace IAgro.Application.Features.CropsData.Update;

public class UpdateCropDataValidator : AbstractValidator<UpdateCropDataRequest>
{
    public UpdateCropDataValidator()
    {
        RuleForEach(cd => cd.DiseaseCoords);
    }
}