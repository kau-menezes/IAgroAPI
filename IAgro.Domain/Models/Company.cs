namespace IAgro.Domain.Models;

public class Company : BaseModel
{
    public required string Name { get; set; }
    public required string CNPJ { get; set; }
    public required string Country { get; set; }
    public required string TimeZone { get; set; }

    public List<CropData> CropsData { get; } = [];
}
