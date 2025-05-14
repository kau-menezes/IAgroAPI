namespace IAgro.Domain.Models;

public class Company : BaseModel
{
    public required string Name { get; set; }

    public List<CropData> CropsData { get; } = [];
}
