namespace IAgro.Domain.Models;

public class Field : BaseModel
{
    public required string Name { get; set; }
    public required double Area { get; set; }
    public required double[] Coords { get; set; }
    public required string Crop { get; set; }
    public required string State { get; set; }
}