namespace IAgro.Domain.Models;

public class CropData : BaseModel
{
    public required Guid CompanyId { get; set; }
    public required Company Company { get; set; }

    public List<string> DiseaseCoords { get; } = [];
}