namespace IAgro.Domain.Models;

public class Device : BaseModel
{
    public required Guid CompanyId { get; set; }

    public required Company Company { get; set; }

    public string? Nickname { get; set; }

    public string? Code { get; set; }
}