namespace IAgro.Domain.Objects;

public class LocationPoint(double latitude, double longitude)
{
    public double Latitude { get; } = latitude;
    public double Longitude { get; } = longitude;
}
