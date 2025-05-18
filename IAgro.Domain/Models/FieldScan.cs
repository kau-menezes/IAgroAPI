namespace IAgro.Domain.Models;

public class FieldScan : BaseModel
{
    public required Guid FieldId;
    public required Field Field;

    public List<CropDisease> CropDiseases { get; } = [];
}